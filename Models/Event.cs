using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;
public class Event
{
    public int EventId { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Event name must be between 3 and 20 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Event Name can only contain letters, numbers, and spaces.")]
    public string EventName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [CustomValidation(typeof(Event), nameof(ValidateDate))]
    public DateTime EventDate { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Event Location must be between 5 and 30 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s,]*$", ErrorMessage = "Event Location can only contain letters, numbers, spaces, and commas.")]
    public string EventLocation { get; set; }

    [StringLength(200, ErrorMessage = "Event Description cannot exceed 200 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s,.]*$", ErrorMessage = "Event Description can only contain letters, numbers, spaces, commas, and periods.")]
    public string EventDescription { get; set; }

    public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
    {
        if (date < DateTime.Now)
        {
            return new ValidationResult("Event Date cannot be in the past.");
        }
        return ValidationResult.Success;
    }
}