namespace BakaBack.Domain.Test.Fixtures
{
    public class FakeClock: IClock
    {
        private readonly DateTime fakeDateTime;

        public FakeClock(DateTime fakeDateTime)
        {
            this.fakeDateTime = fakeDateTime;
        }

        public DateTime Now => fakeDateTime;
    }
}
