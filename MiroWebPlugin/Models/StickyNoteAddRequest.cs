namespace MiroWebPlugin.Models
{
    public class StickyNoteAddRequest
    {
        public string Text { get; set; }
        public string ParentId { get; set; }
        public int SessionId { get; set; }

    }
}
