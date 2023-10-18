<template>
    <div class="modal fade" id="allSpice" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-xl" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="modalTitleId">Modal title</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <!-- NOTE the whole section has a v-if meaning it will only render IF there is an active movie -->
            <section v-if="activeRecipe" class="row">
                {{ activeRecipe.title }}
            </section>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';


export default {
setup() {
  return {
    activeRecipe: computed(() => AppState.activeRecipe)
  };
},
};
</script>


<style>
</style>