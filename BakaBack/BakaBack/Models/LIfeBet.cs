using BakaBack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakaBack.Models
{
    public class LifeBet
    {
        [Key]
        public int Id { get; set; }
        public string Terms { get; set; }
        public decimal Odds { get; set; }
        public decimal InitialStake { get; set; }
        public string Status { get; set; } // "pending", "active", "completed"
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public virtual ICollection<LifeBetParticipant> Participants { get; set; }
    }
}

public class LifeBetParticipant
{
    [Key]
    public int Id { get; set; }
    public int LifeBetId { get; set; }
    [ForeignKey("LifeBetId")]
    public LifeBet LifeBet { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
    public decimal Stake { get; set; }
    public decimal NegotiatedOdds { get; set; }
}
