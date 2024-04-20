namespace HumanDesign.Models
{
    public class CircuitChannel
    {
        public int CircuitId { get; set; }
        public Circuit? Circuit { get; set; }

        public int ChannelId { get; set; }
        public Channel? Channel { get; set; }
    }
}
