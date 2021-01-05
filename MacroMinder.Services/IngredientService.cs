using MacroMinder.Data;
using MacroMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientList = MacroMinder.Models.IngredientList;

namespace MacroMinder.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userID)
        {
            _userId = userID;
        }

        public IEnumerable<IngredientList> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        //.Where(e => /*e.IngredientShared == true ||*/ e.ApplicationUserId == _userId)
                        .Select(
                            e =>
                                new IngredientList
                                {
                                    IngredientID = e.IngredientID,
                                    IngredientName = e.IngredientName,
                                    IngredientShared = e.IngredientShared,
                                    IngredientQuantity = e.IngredientQuantity,
                                    IngredientQuantityUnitOfMeasurement = e.IngredientQuantityUnitOfMeasurement,
                                    Protein = e.Protein,
                                    Carbohydrates = e.Carbohydrates,
                                    Fat = e.Fat,
                                    Calories = e.Calories,
                                    DietaryFiber = e.DietaryFiber
                                }
                        );

                return query.ToArray();
            }
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            ApplicationUser currentUser = new ApplicationUser();

            var entity =
                new Ingredient()
                {
                    IngredientName = model.IngredientName,
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
                        .Single(e => /*e.IngredientID == id && e.IngredientShared == true ||*/ e.IngredientID == id /*&& e.ApplicationUserId == _userId*/);
                return
                    new IngredientDetail
                    {
                        IngredientID = entity.IngredientID,
                        IngredientName = entity.IngredientName,
                        IngredientShared = entity.IngredientShared,
                        IngredientQuantity = entity.IngredientQuantity,
                        IngredientQuantityUnitOfMeasurement = entity.IngredientQuantityUnitOfMeasurement,
                        Protein = entity.Protein,
                        Carbohydrates = entity.Carbohydrates,
                        Fat = entity.Fat,
                        Calories = entity.Calories,
                        DietaryFiber = entity.DietaryFiber
                    };
            }
        }

        public bool Edit(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == model.IngredientID);

                    entity.IngredientID = model.IngredientID;
                    entity.IngredientName = model.IngredientName;
                    entity.IngredientShared = model.IngredientShared;
                    entity.IngredientQuantity = model.IngredientQuantity;
                    entity.IngredientQuantityUnitOfMeasurement = model.IngredientQuantityUnitOfMeasurement;
                    entity.Protein = model.Protein;
                    entity.Carbohydrates = model.Carbohydrates;
                    entity.Fat = model.Fat;
                    entity.Calories = model.Calories;
                    entity.DietaryFiber = model.DietaryFiber;

                    return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int ingredientID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == ingredientID /*&& e.ApplicationUserId == _userId*/);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
