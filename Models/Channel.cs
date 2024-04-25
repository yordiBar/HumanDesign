namespace HumanDesign.Models
{
    public class Channel
    {
        public int Id { get; set; }

        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Theme { get; set; }
        public string? Location { get; set; }
        public string? Note { get; set; }
        

        // Foreign keys
        public int? CircuitId { get; set; }

        // Navigation properties
        public Circuit? Circuit { get; set; }

        public List<CircuitChannel> CircuitChannels { get; set; } = [];
    }
}
