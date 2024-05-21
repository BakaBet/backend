using System.ComponentModel.DataAnnotations;

namespace BakaBack.Models
{
    public class Bookmaker
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Market> Markets { get; set; }
        public string MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
