namespace MiroWebPlugin.Models
{
    public class PostRequestItem
    {
        public PostRequestData data { get; set; }
        public PostRequestStyle style { get; set; }
        public PostRequestPosition position { get; set; }
        public PostRequestParent parent { get; set; }
        public PostRequestItem()
        {
            data = new PostRequestData();
            style = new PostRequestStyle();
            position = new PostRequestPosition();
            parent = new PostRequestParent();
        }
    }

    public class PostRequestData
    {
        public string content { get; set; }
        public string shape { get; set; }
    }

    public class PostRequestStyle
    {
        public string fillColor { get; set; }
        public string textAlign { get; set; }
        public string textAlignVertical { get; set; }

    }
    public class PostRequestPosition
    {
        public string origin { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }

    public class PostRequestParent
    {
        public string id { get; set; }
    }
}
