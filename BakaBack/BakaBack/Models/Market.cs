using System.ComponentModel.DataAnnotations;

namespace BakaBack.Models
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; }
        public int BookmakerId { get; set; }
        public virtual Bookmaker Bookmaker { get; set; }
    }
}
