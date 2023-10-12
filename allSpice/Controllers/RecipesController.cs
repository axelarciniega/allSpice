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

        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
            _auth0 = auth0;
        }

    }
}