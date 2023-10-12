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

        public RecipesController(RecipesService recipesService, Auth0Provider auth0)
        {
            _recipesService = recipesService;
            _auth0 = auth0;
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






    }
}