using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Display(Name = "Activity Description"), Required]
        public string ActivityDescription { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int EventId { get; set; }

        public List<Event> Events { get; set; }

    }
}
