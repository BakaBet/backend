using BakaBack.Contexts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakaBack.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string MatchId { get; set; }
        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }

        public decimal Amount { get; set; }
        public decimal Odds { get; set; }
        public DateTime DatePlaced { get; set; }
    }
}
