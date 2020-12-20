using MacroMinder.Data;
using MacroMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMinder.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;
        private readonly ApplicationUser _user;

        public IngredientService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    IngredientName = model.IngredientName,
                    IngredientOwner = _user,
                    IngredientShared = model.IngredientShared,
                    IngredientQuantity = model.IngredientQuantity,
                    IngredientQuantityUnitOfMeasurement = model.IngredientQuantityUnitOfMeasurement,
                    Protein = model.Protein,
                    Carbohydrates = model.Carbohydrates,
                    Fat = model.Fat,
                    Calories = model.Calories,
                    DietaryFiber = model.DietaryFiber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == id && e.IngredientShared == true || e.IngredientID == id && e.ApplicationUserId == _userId);
                return
                    new IngredientDetail
                    {
                        IngredientName = entity.IngredientName,
                        IngredientQuantity = entity.IngredientQuantity,
                        IngredientQuantityUnitOfMeasurement = entity.IngredientQuantityUnitOfMeasurement,
                        Proteins = entity.Protein,
                        Carbohydrates = entity.Carbohydrates,
                        Fats = entity.Fat,
                        Calories = entity.Calories,
                        DietaryFiber = entity.DietaryFiber
                    };
            }
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == model.IngredientID);

                entity.IngredientName = model.IngredientName;
                    entity.IngredientQuantity = model.IngredientQuantity;
                    entity.IngredientQuantityUnitOfMeasurement = model.IngredientQuantityUnitOfMeasurement;
                    entity.Protein = model.Proteins;
                    entity.Carbohydrates = model.Carbohydrates;
                    entity.Fat = model.Fats;
                    entity.Calories = model.Calories;
                entity.DietaryFiber = model.DietaryFiber;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteIngredient(int ingredientID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == ingredientID && e.ApplicationUserId == _userId);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
