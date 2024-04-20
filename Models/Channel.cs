namespace HumanDesign.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<CircuitChannel> CircuitChannels { get; set; } = [];
    }
}
