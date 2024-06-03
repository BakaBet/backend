using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


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

        public async Task<IEnumerable<Outcome>> GetOddsByEventIdAsync(string eventId)
        {
            return await _eventRepository.GetOddsByEventIdAsync(eventId);
        }

        public async Task<bool> UpdateOddsAsync(string eventId, string betOption, decimal newOdds)
        {
            return await _eventRepository.UpdateOddsAsync(eventId, betOption, newOdds);
        }
    }
}







