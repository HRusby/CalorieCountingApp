<template>
  <div>
    <div v-if="selectedMode === ''">
      <p @click="setMode('mealCreation')">Meal Creation</p>
      <p @click="setMode('calorieCounting')">Calorie Counting</p>
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