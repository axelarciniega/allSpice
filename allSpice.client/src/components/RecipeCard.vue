<template>
    <div class="container">

        <section class="card elevation-5 ">
            <div class="coverImg" :style="`background-image: url(${recipe.img})`">
                <div class="col-12 col-md-4 background-color text-white">
                    {{ recipe.category }}
                </div>
                <div class="col-12 col-md-4">
                    <p class="mdi mdi-heart"></p>
                </div>
                <div class="text-center background-color col-12 margin-top ">
                    {{ recipe.title }}
                </div>
                
            </div>
        </section>
    </div>
    </template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';


export default {
    props: {recipe: {type: Recipe, required: true}},
setup() {
  return {
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
    margin-top: 150px;
}

</style>