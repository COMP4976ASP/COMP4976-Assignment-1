using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Event Start Time"), Required]
        public DateTime EventFrom { get; set; }

        [Display(Name = "Event End Time"), Required]
        public DateTime EventTo { get; set; }

        [Display(Name = "Organizer"), Required]
        public string Username { get; set; }

        [Display(Name = "Activity"), Required]
        public int ActivityId { get; set; }

        [Display(Name = "Activity")]
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        [HiddenInput(DisplayValue = false), Required]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is active"), Required]
        public bool IsActive { get; set; }
    }
}
