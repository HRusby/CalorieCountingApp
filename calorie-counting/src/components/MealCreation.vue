<template>
  <div class="flex space-y-2 grid grid-cols-1 text-center">
    <h1 class="mx-auto">Meal Creation</h1>
    <br />
    <div class="container" v-if="mode === ''">
      <button
        @click="mode = 'newMeal'"
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto my-2"
      >
        Add Meal
      </button>
      <button
        @click="mode = 'updateMeal'"
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto my-2"
      >
        Update Meal
      </button>
    </div>
    <div v-else>      
      <button
        v-if="mode !== ''"
        @click="mode = ''"
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto my-2"
      >
        Change Mode
      </button>
      <new-meal v-if="mode==='newMeal'"></new-meal>
      <update-meal v-else-if="mode==='updateMeal'"></update-meal>
    </div>
  </div>
</template>

<script>
import NewMeal from './NewMeal.vue';
import UpdateMeal from './UpdateMeal.vue';
export default {
  components: { NewMeal, UpdateMeal },
  name: "MealCreation",
  data() {
    return {
      mode: "",
    };
  },
};
</script>

<style scoped>
</style>