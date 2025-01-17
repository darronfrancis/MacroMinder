﻿using MacroMinder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MacroMinder.Data.UnitOfMeasurement;

namespace MacroMinder.Data
{
    public class RecipeIngredient
    {

        [Key]
        public int IngredientListID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public double IngredientMeasurement { get; set; }
        public IngredientMeasurementUnit IngredientUnit { get; set; }
    }
}
