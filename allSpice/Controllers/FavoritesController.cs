using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth0;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
        {
            _favoritesService = favoritesService;
            _auth0 = auth0;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite newFavorite = _favoritesService.CreateFavorite(favoriteData);
                return newFavorite;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }





    }
}