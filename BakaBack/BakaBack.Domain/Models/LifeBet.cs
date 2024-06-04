using BakaBack.Domain.Models;

namespace BakaBack.Domain.Models
{
    public class LifeBet
    {
        public int Id { get; set; }
        public Proposal Proposal { get; set; }
        public List<Participation> Participants { get; set; } = new List<Participation>();

        public LifeBet() { }

        public LifeBet(Proposal proposal)
        {
            Proposal = proposal;
        }

        public void AddParticipant(Participation participant)
        {
            Participants.Add(participant);
        }
    }
}