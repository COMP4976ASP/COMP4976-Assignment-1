using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ZenithDataLib.Models
{
    public class Event: IValidatableObject
    {
        [Key]
        public int EventId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event Start Time"), Required]
        public DateTime EventFrom { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event End Time"), Required]
        public DateTime EventTo { get; set; }

        [Display(Name = "Organizer")]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Display(Name = "Activity"), Required]
        public int ActivityId { get; set; }

        [Display(Name = "Activity")]
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active"), Required]
        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (EventFrom > EventTo)
            {
                ValidationResult error = new ValidationResult("Event end time should be after event start time");
                result.Add(error);
            }
            if (EventFrom.Date != EventTo.Date)
            {
                ValidationResult error = new ValidationResult("Event must happen on the same day");
                result.Add(error);
            }
            return result;
        }
    }
}
