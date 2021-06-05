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
        @click="setMode('calorieTracking')"
      >
        Calorie Tracking
      </button>
    </div>
    <div v-else>
      <meal-creation v-if="selectedMode === 'mealCreation'"></meal-creation>
      <calorie-tracking v-if="selectedMode === 'calorieTracking'"></calorie-tracking>
    </div>
  </div>
</template>

<script>
import MealCreation from "./Meal/MealCreation.vue";
import CalorieTracking from "./Tracking/CalorieTracking.vue";
export default {
  components: { MealCreation, CalorieTracking },
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