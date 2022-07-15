namespace MiroWebPlugin.Models
{
    public class SessionViewModel
    {
        public int SessionId { get; set; }
        public List<Item> InputFields { get; set; }

        public SessionViewModel()
        {
            SessionId = -1;
            InputFields = new List<Item>();
        }

    }
}
