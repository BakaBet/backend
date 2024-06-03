using BakaBack.Infrastructure.Interfaces;

namespace BakaBack.Infrastructure.Test
{
    public class FakeMailer : IMailer
    {
        public bool IsSent { get; private set; } = false;
        public string? Email { get; private set; } = null;


        public void SendMail(string content)
        {
            IsSent = true;
            Email = content;
        }
    }
}
