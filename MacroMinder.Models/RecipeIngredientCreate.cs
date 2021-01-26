using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.UnitOfMeasurement;

namespace MacroMinder.Models
{
    public class RecipeIngredientCreate
    {
        public int IngredientListID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public double IngredientMeasurement { get; set; }
        public IngredientMeasurementUnit IngredientUnit { get; set; }
    }
}
