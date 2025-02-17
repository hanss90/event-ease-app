using EventEaseApp.Models;

namespace EventEaseApp.Services;
public class EventService
{
    private List<Event> events = new List<Event>
        {
            new Event { EventId = 1, EventName = "Corporate Meeting", EventDate = new DateTime(2025, 3, 15), EventLocation = "New York", EventDescription = "Quarterly meeting for all employees." },
            new Event { EventId = 2, EventName = "Annual Conference", EventDate = new DateTime(2025, 4, 20), EventLocation = "San Francisco", EventDescription = "Conference for industry professionals." },
            new Event { EventId = 3, EventName = "Networking Event", EventDate = new DateTime(2025, 5, 10), EventLocation = "Chicago", EventDescription = "Networking event for entrepreneurs." },
            new Event { EventId = 4, EventName = "Product Launch", EventDate = new DateTime(2025, 6, 25), EventLocation = "Los Angeles", EventDescription = "Launch event for new product line." },
            new Event { EventId = 5, EventName = "Charity Gala", EventDate = new DateTime(2025, 7, 30), EventLocation = "Miami", EventDescription = "Fundraising gala for local charity." },
            new Event { EventId = 6, EventName = "Team Building Retreat", EventDate = new DateTime(2025, 8, 15), EventLocation = "Seattle", EventDescription = "Annual team building retreat for employees." }
        };

    public Task<List<Event>> GetEventsAsync()
    {
        return Task.FromResult(events);
    }

    public Task AddEventAsync(Event newEvent)
    {
        newEvent.EventId = events.Max(e => e.EventId) + 1;
        events.Add(newEvent);
        return Task.CompletedTask;
    }

    public Task UpdateEventAsync(Event updatedEvent)
    {
        var existingEvent = events.FirstOrDefault(e => e.EventId == updatedEvent.EventId);
        if (existingEvent != null)
        {
            existingEvent.EventDate = updatedEvent.EventDate;
            existingEvent.EventLocation = updatedEvent.EventLocation;
            existingEvent.EventName = updatedEvent.EventName;
            existingEvent.EventDescription = updatedEvent.EventDescription;
        }
        return Task.CompletedTask;
    }
}