namespace VoddalmBlazor.Models
{
    public class Agencies
    {
        public int id { get; set; }
        public string name { get; set; }
        public string presentation { get; set; }
        public string logoUrl { get; set; }
        public List<Broker> brokers { get; set; }
    }
}
