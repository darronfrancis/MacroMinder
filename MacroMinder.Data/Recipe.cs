﻿using MacroMinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public Guid RecipeOwner { get; set; }
        public bool RecipeShared { get; set; }
        public string RecipeDescription { get; set; }
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        //public Image?? MyProperty { get; set; }
    }
}
