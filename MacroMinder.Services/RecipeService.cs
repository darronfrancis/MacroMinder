using MacroMinder.Data;
using MacroMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MacroMinder.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userID)
        {
            _userId = userID;
        }

        private IngredientService CreateIngredientService()
        {
            var ingredientService = new IngredientService(_userId);
            return ingredientService;
        }

        public IEnumerable<RecipeList> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.RecipeShared == true || e.RecipeOwner == _userId)
                        .Select(
                            e =>
                                new RecipeList
                                {
                                    RecipeID = e.RecipeID,
                                    RecipeName = e.RecipeName,
                                    RecipeOwner = e.RecipeOwner,
                                    RecipeShared = e.RecipeShared,
                                    RecipeDescription = e.RecipeDescription,
                                    RecipeSteps = e.RecipeSteps,
                                    RecipeIngredients = e.RecipeIngredients
                                }
                        );
                List<RecipeStep> steps = new List<RecipeStep>();
                foreach (var step in steps)
                {
                    ctx.RecipeSteps.Add(step);
                }

                List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
                foreach (var ingredient in ingredients)
                {
                    ctx.RecipeIngredients.Add(ingredient);
                }

                return query.ToArray();
            }
        }

        public bool CreateRecipe(RecipeCreate recipe)
        {
            using (var ctx = new ApplicationDbContext())
            {
            var entity =
                new Recipe()
                {
                    RecipeOwner = _userId,
                    RecipeName = recipe.RecipeName,
                    RecipeShared = recipe.RecipeShared,
                    RecipeDescription = recipe.RecipeDescription,
                    RecipeID = recipe.RecipeID
                };
                ctx.Recipes.Add(entity);

                string[] lines = recipe.RecipeSteps.Split('\n');
                int stepNumber = 1;
                foreach (var step in lines)  
                    {
                    entity.RecipeSteps.Add(new RecipeStep() {
                        RecipeID = entity.RecipeID, StepNumber = stepNumber, StepInstruction = step });
                    stepNumber++;
                    };

                var ingredients = recipe.SelectedIngredientIDs;
                var service = CreateIngredientService();
                foreach (var ingredient in ingredients)
                {
                    var selected = service.GetRecipeIngredientById(ingredient);
                    entity.RecipeIngredients.Add(new RecipeIngredient()
                    {
                        IngredientID = selected.IngredientID,
                        RecipeID = selected.RecipeID
                    });
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public MultiSelectList GetIngredientList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // Nick's Create;
                var ingredients = ctx.Ingredients.Select(ingredient => new
                {
                    IngredientID = ingredient.IngredientID.ToString(),
                    Ingredient = ingredient.IngredientName
                }).ToList();

                var multiselect = new MultiSelectList(ingredients, "IngredientID", "Ingredient");

                return multiselect;
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeID == id && e.RecipeShared == true || e.RecipeID == id && e.RecipeOwner == _userId);
                        return
                            new RecipeDetail
                            {
                                RecipeID = entity.RecipeID,
                                RecipeName = entity.RecipeName,
                                RecipeShared = entity.RecipeShared,
                                RecipeDescription = entity.RecipeDescription,
                                RecipeSteps = entity.RecipeSteps
                            };
            }
        }

        public RecipeDelete DeleteRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeID == id && e.RecipeShared == true || e.RecipeID == id && e.RecipeOwner == _userId);
                return
                    new RecipeDelete
                    {
                        RecipeID = entity.RecipeID,
                        RecipeName = entity.RecipeName,
                        RecipeShared = entity.RecipeShared,
                        RecipeDescription = entity.RecipeDescription,
                        RecipeSteps = entity.RecipeSteps
                    };
            }
        }

        public ICollection<RecipeStep> GetRecipeSteps(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RecipeSteps
                        .Where(e => e.RecipeID == id)
                        .Select(
                            e =>
                                new RecipeStep
                                {
                                    StepNumber = e.StepNumber,
                                    StepInstruction = e.StepInstruction
                                }
                        );

                return query.ToList();
            }
        }

        public bool Edit(RecipeEdit recipe)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Recipe()
                    {
                        RecipeOwner = _userId,
                        RecipeName = recipe.RecipeName,
                        RecipeShared = recipe.RecipeShared,
                        RecipeDescription = recipe.RecipeDescription,
                        RecipeID = recipe.RecipeID
                    };

                ICollection<RecipeStep> steps = entity.RecipeSteps;
                foreach (var step in steps)
                {
                    if (step != null)
                    {
                        entity.RecipeSteps.Add(step);
                    }
                };

/*
                var ingredients = recipe.SelectedIngredientIDs;
                var service = CreateIngredientService();
                foreach (var ingredient in ingredients)
                {
                    var selected = service.GetRecipeIngredientById(ingredient);
                    ctx.RecipeIngredients.Add(new RecipeIngredient()
                    {
                        IngredientID = selected.IngredientID
                    });
                }*/

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeID == id && e.RecipeOwner == _userId);

                var entity2 =
                    ctx
                        .RecipeSteps
                        .Where(e => e.RecipeID == entity.RecipeID);

                ctx.Recipes.Remove(entity);

                foreach (var step in entity2)
                {
                    ctx.RecipeSteps.Remove(step);
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
