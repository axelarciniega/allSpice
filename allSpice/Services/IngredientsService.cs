using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
            return newIngredient;
        }

        internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
        {
            List<Ingredient> ingredient = _repo.GetIngredientByRecipeId(recipeId);
            return ingredient;
        }

    }
}