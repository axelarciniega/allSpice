using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId, creatorId)
            VALUES
            (@name, @quantity, @recipeId, @creatorId);
            
            SELECT 
            ing.*,
            act.*
            FROM ingredients ing
            JOIN accounts act ON act.id = @creatorId
            WHERE ing.id = LAST_INSERT_ID()
            ;";
            Ingredient newIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
            {
                ingredient.Creator = account;
                return ingredient;
            }, ingredientData).FirstOrDefault();
            return newIngredient;
        }

        internal Ingredient GetIngredientById(int ingredientId)
        {
            string sql = @"
            SELECT
            ing.*,
            act.*
            FROM ingredients ing
            JOIN accounts act ON ing.creatorId = act.id
            WHERE ing.id = @ingredientId
            ;";
            Ingredient foundIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
            {
                ingredient.Creator = account;
                return ingredient;
            }, new { ingredientId }).FirstOrDefault();
            return foundIngredient;
        }

        internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
        {
            string sql = @"
                SELECT
                ing.*,
                act.*
                FROM ingredients ing
                JOIN accounts act ON act.id = ing.creatorId
                WHERE recipeId = @recipeId
            ;";
            List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
            {
                ingredient.Creator = account;
                return ingredient;
            }, new { recipeId }).ToList();
            return ingredients;
        }

        internal void RemoveIngredient(int ingredientId)
        {
            string sql = @"
                DELETE FROM ingredients WHERE id = @ingredientId
            ;";
            int rowsAffected = _db.Execute(sql, new { ingredientId });

            if (rowsAffected > 1) throw new Exception("Deleted multiple");
            if (rowsAffected < 1) throw new Exception("Nothing was deleted");
        }








    }
}