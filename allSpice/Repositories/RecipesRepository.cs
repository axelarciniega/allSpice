using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }


        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (title, instructions, img, category, creatorId)
            VALUES
            (@title, @instructions, @img, @category, @creatorId);

            SELECT
            act.*,
            rec.*
            FROM recipes rec
            JOIN accounts act ON act.id = rec.creatorId
            WHERE rec.id = LAST_INSERT_ID()
            
            ;";
            Recipe newRecipe = _db.Query<Account, Recipe, Recipe>(sql, (account, recipe) =>
            {
                recipe.Creator = account;
                return recipe;
            }, recipeData).FirstOrDefault();
            return newRecipe;
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"
            SELECT
            rec.*,
            act.* 
            FROM recipes rec
            JOIN accounts act on act.id = rec.creatorId
            ;";
            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }).ToList();
            return recipes;
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            string sql = @"
            SELECT
            rec.*,
            act.*
            FROM recipes rec
            JOIN accounts act ON rec.creatorId = act.id
            WHERE rec.id = @recipeId
            ;";
            Recipe foundRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }, new { recipeId }).FirstOrDefault();
            return foundRecipe;
        }

        internal Recipe EditRecipe(Recipe updateData)
        {
            string sql = @"
                UPDATE recipes
                SET
                title = @title,
                instructions = @instructions,
                img = @img,
                category = @category
                WHERE id = @id;
                SELECT * FROM recipes WHERE id = @id;
            ;";
            Recipe recipe = _db.Query<Recipe>(sql, updateData).FirstOrDefault();
            return recipe;
        }

        internal void DeleteRecipe(int recipeId)
        {
            string sql = @"
            DELETE FROM recipes WHERE id = @recipeId
            ;";
            int rowsAffected = _db.Execute(sql, new { recipeId });
            //NOTE this is to check if it worked or not
            if (rowsAffected > 1) throw new Exception("Deleted everything!!");
            if (rowsAffected < 1) throw new Exception("Nothing happened");
        }









    }
}