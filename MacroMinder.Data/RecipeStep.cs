using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class RecipeStep
    {
        [Key]
        public int StepID { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int StepNumber { get; set; }
        public string StepInstruction { get; set; }
    }
}
