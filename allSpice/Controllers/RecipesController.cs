using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth0;
        private readonly IngredientsService _ingredientsService;

        public RecipesController(RecipesService recipesService, Auth0Provider auth0, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _auth0 = auth0;
            _ingredientsService = ingredientsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
        {
            try
            {
                //NOTE Here we are grabbing the userInfo from auth using the bearer token of the request
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                //NOTE Here we assign the creatorId to the id of the authorized user
                recipeData.CreatorId = userInfo.Id;
                Recipe newRecipe = _recipesService.CreateRecipe(recipeData);
                return newRecipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetAll()
        {
            try
            {
                List<Recipe> recipe = _recipesService.GetAll();
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipeById(int recipeId)
        {
            try
            {
                Recipe recipe = _recipesService.GetRecipeById(recipeId);
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientByRecipeId(int recipeId)
        {
            try
            {
                List<Ingredient> ingredient = _ingredientsService.GetIngredientByRecipeId(recipeId);
                return ingredient;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpPut("{recipeId}")]
        public ActionResult<Recipe> EditRecipe([FromBody] Recipe updateData, int recipeId)
        {
            try
            {
                //NOTE we do this so we can just export the one single piece of data together
                updateData.Id = recipeId;
                Recipe recipe = _recipesService.EditRecipe(updateData);
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{recipeId}")]
        public ActionResult<string> DeleteRecipe(int recipeId)
        {
            try
            {
                string message = _recipesService.DeleteRecipe(recipeId);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}