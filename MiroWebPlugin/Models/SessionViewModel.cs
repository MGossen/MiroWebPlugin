namespace MiroWebPlugin.Models
{
    public class SessionViewModel
    {
        public string SessionId { get; set; }
        public List<Item> InputFields { get; set; }

        public SessionViewModel()
        {
            SessionId = string.Empty;
            InputFields = new List<Item>();
        }

    }
}
