using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakaBack.Domain.Models
{
        public class Negotiation
        {
            public int Id { get; set; }
            public int LifeBetId { get; set; }
            public string InitiatorUserId { get; set; }
            public string RecipientUserId { get; set; }
            public string Message { get; set; }
            public bool IsAccepted { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? LastUpdatedAt { get; set; }
        }
}
