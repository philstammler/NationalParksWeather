using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Temperature
    {
        [Required]
        [Display(Name = "Temp Display")]
        public string TempSettings { get; set; }
        public List<SelectListItem> Options
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem("Fahrenheit", "F"),
                    new SelectListItem("Celsius", "C")
                };
            }
        }
    }
}
