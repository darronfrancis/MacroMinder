using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class Recipe
    {

        [Key]
        public int RecipeID { get; set; }
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }
        public virtual ICollection<IngredientList> Ingredients { get; set; }
        public string RecipeName { get; set; }
        //public Image?? MyProperty { get; set; }
    }
}
