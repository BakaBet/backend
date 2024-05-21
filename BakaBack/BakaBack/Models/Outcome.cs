﻿using System.ComponentModel.DataAnnotations;

namespace BakaBack.Models
{
    public class Outcome
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
    }
}