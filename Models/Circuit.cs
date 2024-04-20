using System.ComponentModel.DataAnnotations.Schema;

namespace HumanDesign.Models
{
    public class Circuit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Theme { get; set; }
        public string? Note { get; set; }

        // Navigation Property for many-to-many relation
        public List<CircuitChannel> CircuitChannels { get; set; } = [];
        [NotMapped]
        public int[]? SelectedChannelIds { get; set; }
    }
}
