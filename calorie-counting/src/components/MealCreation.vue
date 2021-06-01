<template>
  <div class="flex space-x-4 grid grid-cols-1">
    <h1 class="mb-2">Meal Creation</h1>
    <br />
    <button
      href="#"
      v-if="mode !== ''"
      @click="mode = ''"
      class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto"
    >
      Change Mode
    </button>
    <div v-else>
      <button
        href="#"
        @click="mode = 'addMeal'"
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto"
      >
        Add Meal
      </button>
      <button
        href="#"
        @click="mode = 'updateMeal'"
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto"
      >
        Update Meal
      </button>
    </div>
    <p>Mode = {{ mode }}</p>
  </div>
</template>

<script>
export default {
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