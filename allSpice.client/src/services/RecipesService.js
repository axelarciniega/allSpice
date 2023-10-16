import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class RecipesService{
    async getRecipes(){
        const res = await api.get('api/recipes')
        logger.log(res.data)
        AppState.recipes = res.data.map(r => new Recipe(r))
    }

}

export const recipesService = new RecipesService()