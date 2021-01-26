using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MacroMinder.Models
{
    public class RecipeEdit
    {
        public int RecipeID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Name")]
        public string RecipeName { get; set; }
        [Display(Name = "Public?")]
        public bool RecipeShared { get; set; }
        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }
        [Display(Name = "Directions")]
        public int RecipeStepID { get; set; }
        [DataType(DataType.MultilineText)]
        public ICollection<RecipeStep> RecipeSteps { get; set; }
        public int RecipeIngredientID { get; set; }
        public int IngredientID { get; set; }
        [Display(Name = "Ingredients")]
        public IEnumerable<RecipeIngredient> Ingredient { get; set; }
        public MultiSelectList RecipeIngredientList { get; set; }
        public int[] SelectedIngredientIDs { get; set; }
    }
}
