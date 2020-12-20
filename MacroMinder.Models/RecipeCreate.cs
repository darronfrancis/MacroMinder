using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class RecipeCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public virtual ICollection<RecipeStepsCreate> RecipeSteps { get; set; }
        public virtual ICollection<IngredientCreate> Ingredients { get; set; }
        public string RecipeName { get; set; }
    }
}
