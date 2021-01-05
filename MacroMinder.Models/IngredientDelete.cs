using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.RecipeIngredient;

namespace MacroMinder.Models
{
    public class IngredientDelete
    {
        [Display(Name = "Ingredient ID")]
        public int IngredientID { get; set; }
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        [Display(Name = "Public")]
        public bool IngredientShared { get; set; }
        [Display(Name = "Quantity")]
        public int IngredientQuantity { get; set; }
        [Display(Name = "Unit of Measurement")]
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        [Display(Name = "Calories")]
        public double Calories { get; set; }
        [Display(Name = "Protein Grams")]
        public double Protein { get; set; }
        [Display(Name = "Carb Grams")]
        public double Carbohydrates { get; set; }
        [Display(Name = "Dietary Fiber")]
        public double DietaryFiber { get; set; }
        [Display(Name = "Fat Grams")]
        public double Fat { get; set; }
    }
}
