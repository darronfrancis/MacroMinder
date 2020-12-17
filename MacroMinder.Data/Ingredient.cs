using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
        public string IngredientName { get; set; }
        public int Proteins { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Calories { get; set; }
        public int DietaryFiber { get; set; }
    }
}
