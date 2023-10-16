using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES 
        (@accountId, @recipeId);
        SELECT LAST_INSERT_ID()
        ;";
            int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = lastInsertId;
            return favoriteData;
        }






    }
}