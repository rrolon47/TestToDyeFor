﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestToDyeFor.Data;
using TestToDyeFor.Models;
using TestToDyeFor.ViewModels;

namespace TestToDyeFor.Controllers
{
    public class RecipeController : Controller
    {

        static private List<MXRecipe> MXRecipes = new List<MXRecipe>();

        //get: Recipe
        public IActionResult Index()
        {
           List<MXRecipe> mxRecipes = new List<MXRecipe>(RecipeData.GetAll());

            return View(mxRecipes);
        }

        //retrieves form
        [HttpGet]
        [Route("Recipe/Calculator")]
        public IActionResult Calculator()
        {
            CalculateMXRecipeViewModel calculateMXRecipeViewModel = new CalculateMXRecipeViewModel();
            return View(calculateMXRecipeViewModel);
        }

        //processes form
        [HttpPost]
        [Route("Recipe/Calculator")]
        public IActionResult Calculator(CalculateMXRecipeViewModel calculateMXRecipeViewModel)
        {
            MXRecipe newMXRecipe = new MXRecipe
            {
                Name = calculateMXRecipeViewModel.Name,
                DyeColor = calculateMXRecipeViewModel.DyeColor
            };
            RecipeData.Add(newMXRecipe);
            return Redirect("/Recipe");
        }

        [HttpGet]
        [Route("Recipe/Delete")]
        public IActionResult Delete()
        {
            ViewBag.mxrecipes = RecipeData.GetAll();

            return View();
        }

        [HttpPost]
        [Route("Recipe/Delete")]
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

        //processes form
        [HttpPost]
        [Route("/Recipe/Edit")]
        public IActionResult Edit(int recipeId, string name, string dyeColor)
        {
            MXRecipe recipeById = RecipeData.GetById(recipeId);
            recipeById.Name = name;
            recipeById.DyeColor = dyeColor;
            return Redirect("/Recipe");

        }
    }
}
