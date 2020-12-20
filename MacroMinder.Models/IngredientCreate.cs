using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.IngredientList;

namespace MacroMinder.Models
{
    public class IngredientCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string IngredientName { get; set; }
        public int IngredientID { get; set; }
        public bool IngredientShared { get; set; }
        public string IngredientOwner { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int IngredientQuantity { get; set; }
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double Protein { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double Carbohydrates { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double Fat { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double Calories { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double DietaryFiber { get; set; }
    }
}
