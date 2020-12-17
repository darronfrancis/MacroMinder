using MacroMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Data
{
    public class IngredientList
    {
        public enum IngredientMeasurementUnit { teaspoon = 1, tablespoon, cup, ounce, pint, quart, gallon, pound }

        public int IngredientListID { get; set; }
        public Recipe RecipeID { get; set; }
        public Ingredient IngredientID { get; set; }
        public double IngredientMeasurement { get; set; }
        public IngredientMeasurementUnit IngredientUnit { get; set; }

    }
}
