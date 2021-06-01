<template>
  <div class="container">
    <div class="flex justify-center space-x-4" v-if="selectedMode === ''">
      <button
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white"
        @click="setMode('mealCreation')"
      >
        Meal Creation
      </button>
      <button
        class="rounded-full h-20 w-40 flex items-center justify-center bg-green-600 text-lg text-white"
        @click="setMode('calorieCounting')"
      >
        Calorie Counting
      </button>
    </div>
    <div v-else>
      <meal-creation v-if="selectedMode === 'mealCreation'"></meal-creation>
      <tracking v-if="selectedMode === 'calorieCounting'"></tracking>
    </div>
  </div>
</template>

<script>
import MealCreation from "./MealCreation.vue";
import Tracking from "./Tracking.vue";
export default {
  components: { MealCreation, Tracking },
  name: "ModeSelection",
  props: {},
  methods: {
    setMode(mode) {
      this.$store.commit("setMode", mode);
    },
  },
  computed: {
    selectedMode() {
      return this.$store.getters.selectedMode;
    },
  },
};
</script>

<style scoped>
</style>