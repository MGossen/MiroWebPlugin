using MiroWebPlugin.Models;
using MiroWebPlugin.ServiceWrapper;

namespace MiroWebPlugin.Provider
{
    public interface IInputFieldProvider
    {
        int InitFields(string[] itemIds);
        void AddStickyNote(StickyNoteAddRequest request);
        List<Item> GetLoadedInputFields();
    }
    public class InputFieldProvider : IInputFieldProvider
    {
        private readonly IMiroApiServiceWrapper _miroApiServiceWrapper;

        public InputFieldProvider(IMiroApiServiceWrapper miroApiServiceWrapper)
        {
            _miroApiServiceWrapper = miroApiServiceWrapper;
        }

        private string[] _inputFieldIds = Array.Empty<string>();
        private Dictionary<int, string[]> _sessionCache = new Dictionary<int, string[]>();
        public int InitFields(string[] itemIds)
        {
            var sessionId = new Random().Next(10000, 99999);
            _inputFieldIds = itemIds;
            _sessionCache[sessionId] = itemIds;
            var inputFields = _miroApiServiceWrapper.GetInputFields(itemIds);
            return sessionId;
        }

        public void AddStickyNote(StickyNoteAddRequest request)
        {
            if (_inputFieldIds.Length <= 0)
                throw new Exception("No Input Fields Initialized!");

            if (!_inputFieldIds.Contains(request.ParentId))
                throw new Exception("Selected Input Field no longer available");

            var inputField = _miroApiServiceWrapper.GetInputField(request.ParentId);

            if(inputField != null)
            {
                _miroApiServiceWrapper.AddStickyNote(request, inputField);
            }
            throw new Exception("Referenced Input Field Not Found!");
        }

        public List<Item> GetLoadedInputFields()
        {
            var inputFields = _miroApiServiceWrapper.GetInputFields(_inputFieldIds);
            return inputFields;
        }
    }
}
