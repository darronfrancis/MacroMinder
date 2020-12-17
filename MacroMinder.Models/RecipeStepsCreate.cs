using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class RecipeStepsCreate
    {
        public int StepNumber { get; set; }
        [Required]
        public string Step { get; set; }
    }
}
