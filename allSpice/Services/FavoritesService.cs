using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

        internal List<RecipeFavoritesModel> GetFavoritesByAccount(string accountId)
        {
            List<RecipeFavoritesModel> myFavorites = _repo.GetFavoritesByAccount(accountId);
            return myFavorites;
        }


        internal void RemoveFavorite(int favoriteId, string userId)
        {
            Favorite foundFavorite = _repo.GetById(favoriteId);
            if (foundFavorite == null) throw new Exception("Invalid id");
            if (foundFavorite.AccountId != userId) throw new Exception("Unauthorized");
            int rows = _repo.RemoveFavorite(favoriteId);
            if (rows > 1) throw new Exception("Deleted multiple!");
            if (rows < 1) throw new Exception("Nothing happened!");

        }



    }
}