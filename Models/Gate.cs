namespace HumanDesign.Models
{
    public class Gate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }

        // Foreign keys
        public int? LocationId { get; set; }
        public int? CircuitId { get; set; }
        public int? SiddhiId { get; set; }
        public int? GiftId { get; set; }
        public int? ReactiveId { get; set; }
        public int? RepressiveId { get; set; }
        public int? ShadowId { get; set; }

        // Navigation properties
        public Location? Location { get; set; }
        public Circuit? Circuit { get; set; }
        public Siddhi? Siddhi { get; set; }
        public Gift? Gift { get; set; }
        public Reactive? Reactive { get; set; }
        public Repressive? Repressive { get; set; }
        public Shadow? Shadow { get; set; }
    }

}
