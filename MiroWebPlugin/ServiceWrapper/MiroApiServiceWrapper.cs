using MiroWebPlugin.Models;
using Newtonsoft.Json;
using System.Net;

namespace MiroWebPlugin.ServiceWrapper
{
    public interface IMiroApiServiceWrapper
    {
        List<Item> GetInputFields(string[] ids);
        Item GetInputField(string id);
        void AddStickyNote(StickyNoteAddRequest request, Item inputField);
    }

    public class MiroApiServiceWrapper : IMiroApiServiceWrapper
    {
        private static readonly string token = "eyJtaXJvLm9yaWdpbiI6ImV1MDEifQ_UNuxX7CoZErAQ7FfF-hyMhfThWU";
        private static readonly string boardId = "uXjVOn0-sLo%3D"; // uXjVOn0-sLo=

        public void AddStickyNote(StickyNoteAddRequest request, Item inputField)
        {
            var url = $"https://api.miro.com/v2/boards/{boardId}/sticky_notes";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);



            //using(var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(url);
            //    client.DefaultRequestHeaders.Add("Bearer", token);

            //}


            httpRequest.Method = "POST";

            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            var item = new Item();
            item.data.content = request.Text;
            item.data.shape = "square";
            item.style.fillColor = "light_yellow";
            item.style.textAlign = "center";
            item.style.textAlignVertical = "top";
            item.position.origin = "center";
            item.position.x = 0;
            item.position.y = 0;
            item.Parent = new Parent(request.ParentId);
            var postRequestItem = ConvertItemToPostRequestItem(item, inputField);

            var jsonItem = JsonConvert.SerializeObject(postRequestItem);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonItem);
            }
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                
            }
        }

        private PostRequestItem ConvertItemToPostRequestItem(Item item , Item inputField)
        {
            var result = new PostRequestItem();
            result.data.content = item.data.content;
            result.data.shape = item.data.shape;
            result.style.fillColor = item.style.fillColor;
            result.style.textAlign = item.style.textAlign;
            result.style.textAlignVertical = item.style.textAlignVertical;
            result.position.origin = item.position.origin;
            result.position.x = item.position.x;
            result.position.y = item.position.y;

            // --- since only a parent of the Type 'frame' is supported,
            // --- the coordinates are determined differently to be in the parent area
            if (inputField.type == "frame")
            {
                result.parent.id = item.Parent.Id;
                DetermineCoordinatesRelativeToSupportedParent(result, inputField);
            }
            else
            {
                DetermineCoordinates(result, inputField);
            }

            return result;
        }

        private void DetermineCoordinatesRelativeToSupportedParent(PostRequestItem result, Item inputField)
        {
            result.position.x = new Random().NextDouble() * inputField.geometry.width;
            result.position.y = new Random().NextDouble() * inputField.geometry.height;
        }

        private void DetermineCoordinates(PostRequestItem result, Item inputField)
        {
            var xMin = inputField.position.x - (inputField.geometry.width / 2);
            var xMax = inputField.position.x + (inputField.geometry.width / 2);

            result.position.x = new Random().NextDouble() * (xMax - xMin) + xMin;
            
            var yMin = inputField.position.y - (inputField.geometry.height / 2);
            var yMax = inputField.position.y + (inputField.geometry.height / 2);

            result.position.y = new Random().NextDouble() * (yMax - yMin) + yMin;
        }

        public Item GetInputField(string id)
        {
            try
            {
                var url = $"https://api.miro.com/v2/boards/{boardId}/items/{id}";
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";

                httpRequest.Headers["Authorization"] = $"Bearer {token}";
                httpRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var myJsonResponse = streamReader.ReadToEnd();
                    Item? item = JsonConvert.DeserializeObject<Item>(myJsonResponse);
                    if (item != null)
                    {
                        return item;

                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Item> GetInputFields(string[] ids)
        {
            var result = new List<Item>();
            try
            {
                foreach (string id in ids)
                {
                    var item = GetInputField(id);
                    if(item != null)
                    {
                        result.Add(item); 
                    }
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
