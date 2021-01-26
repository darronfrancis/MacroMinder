using MacroMinder.Data;
using MacroMinder.Models;
using MacroMinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MacroMinder.Controllers
{

    public class IngredientController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }

        // GET: Ingredients
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateIngredientService();
            var model = service.GetIngredients();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your ingredient could not be created.");

            return View(model);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var svc = CreateIngredientService();
            var detail = svc.GetIngredientById(id);

            var model =
                new IngredientEdit
                {
                    IngredientID = detail.IngredientID,
                    IngredientName = detail.IngredientName,
                    IngredientShared = detail.IngredientShared,
                    IngredientQuantity = detail.IngredientQuantity,
                    IngredientQuantityUnitOfMeasurement = detail.IngredientQuantityUnitOfMeasurement,
                    Protein = int.Parse(detail.Protein.ToString()),
                    Carbohydrates = int.Parse(detail.Carbohydrates.ToString()),
                    Fat = int.Parse(detail.Fat.ToString()),
                    Calories = int.Parse(detail.Calories.ToString()),
                    DietaryFiber = int.Parse(detail.DietaryFiber.ToString())
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IngredientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientService();

            if (service.Edit(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ingredient could not be updated.");
            return View(model);
        }

        [Authorize]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateIngredientService();
            var ingredient = service.GetIngredientById(id);
            var model =
            new IngredientDelete
            {
                IngredientID = ingredient.IngredientID,
                IngredientName = ingredient.IngredientName,
                IngredientShared = ingredient.IngredientShared,
                IngredientQuantity = ingredient.IngredientQuantity,
                IngredientQuantityUnitOfMeasurement = ingredient.IngredientQuantityUnitOfMeasurement,
                Protein = int.Parse(ingredient.Protein.ToString()),
                Carbohydrates = int.Parse(ingredient.Carbohydrates.ToString()),
                Fat = int.Parse(ingredient.Fat.ToString()),
                Calories = int.Parse(ingredient.Calories.ToString()),
                DietaryFiber = int.Parse(ingredient.DietaryFiber.ToString())
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateIngredientService();

            service.Delete(id);

            TempData["SaveResult"] = "Your ingredient was deleted";

            return RedirectToAction("Index");
        }
    }
}