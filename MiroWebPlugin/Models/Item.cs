namespace MiroWebPlugin.Models
{
    public class CreatedBy
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Data
    {
        public string content { get; set; }
        public string shape { get; set; }
        public string title { get; set; }
    }

    public class Geometry
    {
        public double width { get; set; }
        public double height { get; set; }
    }

    public class Item
    {
        public Item()
        {
            links = new Links();
            data = new Data();
            position = new Position();
            style = new Style();
        }

        public string id { get; set; }
        public string type { get; set; }
        public Links links { get; set; }
        public DateTime createdAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public Data data { get; set; }
        public Geometry geometry { get; set; }
        public DateTime modifiedAt { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public Position position { get; set; }
        public Style style { get; set; }
        public Parent Parent { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
    }

    public class ModifiedBy
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
        public string origin { get; set; }
        public string relativeTo { get; set; }
    }

    public class Style
    {
        public string fillColor { get; set; }
        public string fillOpacity { get; set; }
        public string fontFamily { get; set; }
        public string fontSize { get; set; }
        public string borderColor { get; set; }
        public string borderWidth { get; set; }
        public string borderOpacity { get; set; }
        public string borderStyle { get; set; }
        public string textAlign { get; set; }
        public string textAlignVertical { get; set; }
        public string color { get; set; }
    }

    public class Parent
    {
        public Parent(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }

}
