using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.RecipeIngredient;

namespace MacroMinder.Models
{
    public class IngredientCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        [Display(Name = "Ingredient ID")]
        public int IngredientID { get; set; }
        [Display(Name = "Public Ingredient")]
        public bool IngredientShared { get; set; }
        [Display(Name = "Ingredient Owner")]
        public string IngredientOwner { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name = "Ingredient Quantity")]
        public int IngredientQuantity { get; set; }
        [Display(Name = "Unit of Measurement")]
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        [Display(Name = "Calories")]
        public double Calories { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        [Display(Name = "Dietary Fiber")]
        public double DietaryFiber { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        [Display(Name = "Proteins")]
        public double Protein { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        [Display(Name = "Carbs")]
        public double Carbohydrates { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        [Display(Name = "Fats")]
        public double Fat { get; set; }
    }
}
