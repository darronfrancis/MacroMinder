using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.IngredientList;

namespace MacroMinder.Models
{
    public class IngredientDetail
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public bool IngredientPrivacy { get; set; }
        public int IngredientQuantity { get; set; }
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public double Calories { get; set; }
        public double DietaryFiber { get; set; }
    }
}
