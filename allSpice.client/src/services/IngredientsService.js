import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class IngredientsService{

    async createIngredient(ingredientData){
        const res = await api.post('api/ingredients', ingredientData)
        logger.log(res.data)
        AppState.ingredients.unshift(new Ingredient(res.data))
    }

    

    async getIngredientById(recipeId){
        const res = await api.get(`api/ingredients/${recipeId}`)
        logger.log(res.data)
        AppState.activeIngredient = new Ingredient(res.data)
    }



}


export const ingredientsService = new IngredientsService()