<template>
  <div class="container">

    
    
    
    
    <section class="row g-4 mt-4">
      <div class="col-12 col-md-4" v-for="rec in recipes" :key="rec.id">
        <RecipeCard :recipe="rec"/>
      </div>
    </section>
    
    
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';

export default {
  setup() {
    onMounted(()=> {
      getRecipes();
    });

    async function getRecipes(){
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error)
      }
    }


    return {
      recipes: computed(()=> AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
