using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;


namespace BakaBack.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<SportEvent>> GetSportsEventsAsync()
        {
            return await _eventRepository.GetSportsEventsAsync();
        }

        public async Task<SportEvent> GetSportsEventByIdAsync(string eventId)
        {
            return await _eventRepository.GetSportsEventByIdAsync(eventId);
        }

        public async Task<bool> UpdateHomeOutcomeAsync(string eventId, decimal value)
        {
            return await _eventRepository.UpdateHomeOutcomeAsync(eventId, value);
        }

        public async Task<bool> UpdateAwayOutcomeAsync(string eventId, decimal value)
        {
            return await _eventRepository.UpdateAwayOutcomeAsync(eventId, value);
        }
    }
}







