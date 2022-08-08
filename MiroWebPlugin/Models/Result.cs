namespace MiroWebPlugin.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Result
    {
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
    }

}
