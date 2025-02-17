using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;
public class User
{
    public List<Event> AttendingEvents { get; set; } = new List<Event>();

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Username can only contain letters and numbers.")]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 30 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9,.§$%&?!]*$", ErrorMessage = "Password can only contain letters, numbers, and the following special characters: .,§$%&?!")]
    public string Password { get; set; }

    // AddEventAsynx
    public async Task AddEventAsync(Event newEvent)
    {
        AttendingEvents.Add(newEvent);
    }

    // RemoveEventAsync
    public async Task RemoveEventAsync(int eventId)
    {
        var eventToRemove = AttendingEvents.Find(e => e.EventId == eventId);
        AttendingEvents.Remove(eventToRemove);
    }

    // IsAttendingEventAsync
    public async Task<bool> IsAttendingEventAsync(int eventId)
    {
        return AttendingEvents.Any(e => e.EventId == eventId);
    }
}