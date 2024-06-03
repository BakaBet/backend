﻿using System.Text.Json.Serialization;

namespace BakaBack.Domain.Models
{
    public class Outcome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string EventId { get; set; }

        [JsonIgnore]
        public SportEvent SportEvent { get; set; }
    }
}
