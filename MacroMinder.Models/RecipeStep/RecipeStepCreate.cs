using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models.RecipeSteps
{
    public class RecipeStepCreate
    {
        public int StepID { get; set; }
        public int RecipeID { get; set; }
        [Display(Name = "Step Number")]
        public int StepNumber { get; set; }
        [Display(Name = "Direction")]
        public string StepInstruction { get; set; }
    }
}
