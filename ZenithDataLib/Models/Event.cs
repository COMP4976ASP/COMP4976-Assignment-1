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

        [DataType(DataType.DateTime)]
        [Display(Name = "Event Start Time"), Required]
        public DateTime EventFrom { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event End Time"), Required]
        public DateTime EventTo { get; set; }

        [Display(Name = "Organizer"), Required]
        public string Username { get; set; }

        [Display(Name = "Activity"), Required]
        public int ActivityId { get; set; }

        [Display(Name = "Activity")]
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        [DataType(DataType.DateTime)]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active"), Required]
        public bool IsActive { get; set; }
    }
}
