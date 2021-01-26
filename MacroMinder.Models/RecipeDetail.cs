using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class RecipeDetail
    {
        [Display(Name = "ID")]
        public int RecipeID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Name")]
        public string RecipeName { get; set; }
        [Display(Name = "Owner")]
        public Guid RecipeOwner { get; set; }
        [Display(Name = "Public?")]
        public bool RecipeShared { get; set; }
        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }
        [Display(Name = "Steps")]
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; }
        [Display(Name = "Ingredients")]
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
