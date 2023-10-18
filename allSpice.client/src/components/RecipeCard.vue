<template>
    <div class="container">

        <section class="card elevation-5" @click="getRecipeDetails()" data-bs-toggle="modal" data-bs-target="#allspice">
            <div  class="selectable coverImg"  :style="`background-image: url(${recipe.img})`">
                <div class="col-12 col-md-4 background-color text-white">
                    {{ recipe.category }}
                </div>
                <div class="col-12 col-md-4">
                    <p class="mdi mdi-heart"></p>
                </div>
                <div class="text-center text-white background-color col-12 margin-top ">
                    {{ recipe.title }}
                </div>
                
            </div>
        </section>
    </div>
    </template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';



export default {
    props: {recipe: {type: Recipe, required: true}},
setup(props) {
  return {
    async getRecipeDetails(){
        try {
            logger.log(props.recipe.id)
            const recipeId = props.recipe.id
            await recipesService.getRecipesById(recipeId)
        } catch (error) {
            Pop.error(error)
        }
    }
  };
},
};
</script>


<style>
.coverImg{
    height: 30vh;
    width: 100%;
    background-position: center;
    background-size: cover;
}

.background-color{
    background-color: rgba(0, 0, 0, 0.263);
    backdrop-filter: blur(10px);
}

.margin-top{
    margin-top: 151px;
}

</style>