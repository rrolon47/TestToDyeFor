using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestToDyeFor.Data;
using TestToDyeFor.Models;

namespace TestToDyeFor.Controllers
{
    public class RecipeController : Controller
    {

        static private List<MXRecipe> MXRecipes = new List<MXRecipe>();

        //get: Recipe
        public IActionResult Index()
        {
            ViewBag.mxrecipes = RecipeData.GetAll();

            return View();
        }

        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        [Route("Recipe/Calculator")]
        public IActionResult Calculator(MXRecipe newMXRecipe)
        {
            RecipeData.Add(newMXRecipe);
            return Redirect("/Recipe");
        }

        public IActionResult Delete()
        {
            ViewBag.mxrecipes = RecipeData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] recipeIds)
        {
            foreach (int recipeId in recipeIds)
            {
                RecipeData.Remove(recipeId);
            }

            return Redirect("/Events");
        }

        //get: Recipe/edit/eventId
        [HttpGet]
        [Route("/Recipe/Edit/{recipeId}")]
        public IActionResult Edit(int recipeId)
        {
            MXRecipe recipeById = RecipeData.GetById(recipeId);
            ViewBag.editRecipe = recipeById;
            ViewBag.title = $"Edit Event {recipeById.Name}  (id={recipeById.Id})";
            return View();
        }

        //post: events/edit
        [HttpPost]
        [Route("/Recipe/Edit")]
        public IActionResult SubmitEditRecipeForm(int recipeId, string name, string dyeColor)
        {
            MXRecipe recipeById = RecipeData.GetById(recipeId);
            recipeById.Name = name;
            recipeById.DyeColor = dyeColor;
            return Redirect("/Recipe");

        }
    }
}
