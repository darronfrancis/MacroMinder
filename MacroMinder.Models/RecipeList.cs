using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class RecipeList
    {
        [Display(Name = "Recipe ID")]
        public int RecipeID { get; set; }
        [Display(Name = "Name")]
        public string RecipeName { get; set; }
        [Display(Name = "Owner")]
        public Guid RecipeOwner { get; set; }
        [Display(Name = "Public?")]
        public bool RecipeShared { get; set; }
        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
