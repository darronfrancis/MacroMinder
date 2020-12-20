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
    public class IngredientsController : Controller
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
/*            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            var model = service.();*/

            return View(_db.Ingredients.ToList());
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
    }
}