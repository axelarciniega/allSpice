using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe newRecipe = _repo.CreateRecipe(recipeData);
            return newRecipe;
        }

        internal List<Recipe> GetAll()
        {
            List<Recipe> recipe = _repo.GetAll();
            return recipe;
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            Recipe foundRecipe = _repo.GetRecipeById(recipeId);
            if (foundRecipe == null) throw new Exception($"unable to find recipe at {recipeId}");
            return foundRecipe;
        }

        internal Recipe EditRecipe(Recipe updateData)
        {
            Recipe original = this.GetRecipeById(updateData.Id);

            original.Title = updateData.Title ?? original.Title;
            original.Instructions = updateData.Instructions ?? original.Instructions;
            original.Img = updateData.Img ?? original.Img;
            original.Category = updateData.Category ?? original.Category;

            Recipe recipe = _repo.EditRecipe(original);
            return recipe;
        }

        internal string DeleteRecipe(int recipeId)
        {

            Recipe recipe = this.GetRecipeById(recipeId);
            _repo.DeleteRecipe(recipeId);
            // if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
            return $"{recipe.Title} was removed";
        }












    }
}