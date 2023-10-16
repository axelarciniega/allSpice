using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth0;

        public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
        {
            _ingredientsService = ingredientsService;
            _auth0 = auth0;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                ingredientData.CreatorId = userInfo.Id;
                Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData);
                return newIngredient;
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }

        [HttpGet("{ingredientId}")]
        public ActionResult<Ingredient> GetIngredientById(int ingredientId)
        {
            try
            {
                Ingredient ingredient = _ingredientsService.GetIngredientById(ingredientId);
                return ingredient;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpDelete("{ingredientId}")]
        public async Task<ActionResult<string>> RemoveIngredient(int ingredientId)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                _ingredientsService.RemoveIngredient(ingredientId);
                string message = "Succes on removing ingredient";
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}