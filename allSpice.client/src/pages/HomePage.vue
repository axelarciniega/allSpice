<template>
  <div class="container">


    <section class="background text-white mt-3">
      <div class="text-center">
        <h1>All-Spice</h1>
      </div>
      <div class="text-center">
        <h4>Cherish Your Family</h4>
      </div>
      <div class="text-center">
        <h4>And Their Cooking</h4>
      </div>

    </section>

    
    
    
    
    <section class="row g-4 mt-4">
      <div class="col-12 col-md-4" v-for="rec in recipes" :key="rec.id">
        <RecipeCard :recipe="rec"/>
      </div>
    </section>
    
    
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';

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

.background{
  background-image: url('https://media.swncdn.com/cms/CW/faith/71848-huseyin-pqj21tertgi-unsplash.1200w.tn.jpg');
  width: 100%;
  height: 40vh;
}
</style>
