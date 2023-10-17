import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class RecipesService{

    async createRecipe(recipeData){
        const res = await api.post('api/recipes', recipeData)
        logger.log('creating a recipe', res.data)
        AppState.recipes.unshift(new Recipe(res.data))
    }
    async getRecipes(){
        const res = await api.get('api/recipes')
        logger.log(('getting recips'), res.data)
        AppState.recipes = res.data.map(r => new Recipe(r))
    }

    async getRecipesById(recipeId){
        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log(res.data, 'getting recipes by id')
        AppState.activeRecipe = new Recipe(res.data)
    }

}

export const recipesService = new RecipesService()