using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.IngredientList;

namespace MacroMinder.Models
{
    public class IngredientEdit
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string IngredientName { get; set; }
        public Guid IngredientOwner { get; set; }
        public int IngredientID { get; set; }
        public int IngredientQuantity { get; set; }
        public IngredientMeasurementUnit IngredientQuantityUnitOfMeasurement { get; set; }
        public int Proteins { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Calories { get; set; }
        public int DietaryFiber { get; set; }
    }
}
