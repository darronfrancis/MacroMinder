using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.IngredientList;

namespace MacroMinder.Models
{
    public class IngredientDelete
    {
        public string IngredientName { get; set; }
        public int IngredientQuantity { get; set; }
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        public int Proteins { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Calories { get; set; }
        public int DietaryFiber { get; set; }
    }
}
