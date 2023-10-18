<template>

    <div class="container">
        
            <!-- STUB recipe card  -->
        <section class="card elevation-5" @click="getRecipeDetails()" data-bs-toggle="modal" data-bs-target="#RecipeModal">
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

            <!-- STUB recipe details MODAL -->
            <div  class="modal fade" id="RecipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl">
                    <div v-if="activeRecipe" class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">{{ activeRecipe.title }}</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                            <div class="modal-body">
                                <section class="row">

                                    <div class="col-12 mb-3">
                                        <h6><i>{{ activeRecipe.category }}</i></h6>
                                    </div>

                                    <div class="col-4">
                                        <img class="img-fluid" :src="activeRecipe.img" alt="">
                                    </div>

                                    
                                    
                                        
                                    <div class="col-4">
                                        <h1>Recipe</h1>
                                        <ul>
                                            <li>{{ activeRecipe.instructions }}</li>
                                        </ul>
                                        <!--TODO FORM WILL GO HERE -->
                                    </div>
                                <div v-if="activeIngredient" class="col-4">
                                    <h1>Ingredients</h1>
                                    <div >
                                        <ul>
                                            <li> {{ activeIngredient.name }}</li>
                                            <li>{{ activeIngredient.quantity }}</li>
                                        </ul>
                                       
                                    </div>
                                </div>

                                
                                
                                
                        </section>
                            </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
    </div>
    </template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import { Modal } from 'bootstrap';
import { useRoute } from 'vue-router';



export default {
    props: {recipe: {type: Recipe, required: true}},
setup(props) {
    const route = useRoute()

  return {
    ingredients: computed (()=> AppState.ingredients),
    activeRecipe: computed(()=> AppState.activeRecipe),
    activeIngredient: computed(() => AppState.activeIngredient),
    async getRecipeDetails(){
        try {
            logger.log(props.recipe.id)
            const recipeId = props.recipe.id
            await recipesService.getRecipesById(recipeId)
            await ingredientsService.getIngredientById(recipeId)
        } catch (error) {
            Pop.error(error)
        }
    },

    async getIngredientDetails(){
         
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