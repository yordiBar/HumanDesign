﻿namespace HumanDesign.Models
{
    public class EnvironmentVariable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LeftFacing { get; set; }
        public string? RightFacing { get; set; }
        public string? Note { get; set; }
        public string? Tips { get; set; }
    }
}
