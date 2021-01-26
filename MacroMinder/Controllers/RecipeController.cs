using MacroMinder.Data;
using MacroMinder.Models;
using MacroMinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacroMinder.Controllers
{
    public class RecipeController : Controller
    {

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }



        // GET: Recipes
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateRecipeService();
            var model = service.GetRecipes();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var recipeService = CreateRecipeService();
            var viewModel = new RecipeCreate();
            viewModel.RecipeIngredientList = recipeService.GetIngredientList();
            //ViewBag.IngredientList = ingredients.

            return View(viewModel);
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeService();
            model.RecipeIngredientList = service.GetIngredientList();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your recipe could not be created.");

            return View(model);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var svc = CreateRecipeService();
            var detail = svc.GetRecipeById(id);
            var model =
                new RecipeEdit
                {
                    RecipeID = detail.RecipeID,
                    RecipeName = detail.RecipeName,
                    RecipeShared = detail.RecipeShared,
                    RecipeDescription = detail.RecipeDescription,
                    RecipeSteps = detail.RecipeSteps,
                    Ingredient = detail.Ingredients
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.Edit(model))
            {
                TempData["SaveResult"] = "Your recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View(model);
        }

        [Authorize]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.DeleteRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            service.Delete(id);

            TempData["SaveResult"] = "Your recipe was deleted";

            return RedirectToAction("Index");
        }
    }
}