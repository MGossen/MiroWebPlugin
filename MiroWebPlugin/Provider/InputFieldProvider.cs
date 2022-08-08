using MiroWebPlugin.Models;
using MiroWebPlugin.ServiceWrapper;

namespace MiroWebPlugin.Provider
{
    public interface IInputFieldProvider
    {
        int InitFields(string[] itemIds);
        string AddStickyNote(StickyNoteAddRequest request);
        List<Item> GetLoadedInputFields(int sessionId);
        void DeleteStickyNote(string id);
    }
    public class InputFieldProvider : IInputFieldProvider
    {
        private readonly IMiroApiServiceWrapper _miroApiServiceWrapper;

        public InputFieldProvider(IMiroApiServiceWrapper miroApiServiceWrapper)
        {
            _miroApiServiceWrapper = miroApiServiceWrapper;
        }

        private Dictionary<int, string[]> _sessionCache = new Dictionary<int, string[]>();
        public int InitFields(string[] itemIds)
        {
            var sessionId = new Random().Next(10000, 99999);
            _sessionCache[sessionId] = itemIds;
            var inputFields = _miroApiServiceWrapper.GetInputFields(itemIds);
            return sessionId;
        }

        public string AddStickyNote(StickyNoteAddRequest request)
        {
            if (_sessionCache.TryGetValue(request.SessionId, out var inputFieldIds))
            {
                if (inputFieldIds.Length <= 0)
                    throw new Exception("No Input Fields Initialized!");

                if (!inputFieldIds.Contains(request.ParentId))
                    throw new Exception("Selected Input Field no longer available");

                var inputField = _miroApiServiceWrapper.GetInputField(request.ParentId);

                if (inputField != null)
                {
                   var id =  _miroApiServiceWrapper.AddStickyNote(request, inputField);
                    return id;
                }
                else
                {
                    throw new Exception("Referenced Input Field Not Found!");
                }
            }
            else
            {
                throw new Exception($"Session '{request.SessionId}' not active!");
            }

            
        }

        public List<Item> GetLoadedInputFields(int sessionId)
        {
            if (_sessionCache.TryGetValue(sessionId, out var inputFieldIds))
            {
                var inputFields = _miroApiServiceWrapper.GetInputFields(inputFieldIds);
                return inputFields;
            }
            return new List<Item>();
        }

        public void DeleteStickyNote(string id)
        {
            _miroApiServiceWrapper.DeleteStickyNote(id);
        }
    }
}
