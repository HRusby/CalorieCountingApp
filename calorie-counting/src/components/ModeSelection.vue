<template>
  <div>
    <div v-if="selectedMode === ''">
      <p @click="setMode('mealCreation')">Meal Creation</p>
      <p @click="setMode('calorieCounting')">Calorie Counting</p>
    </div>
    <div v-else>
      <p @click="unsetMode">Change Mode</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "ModeSelection",
  props: {},
  methods: {
    setMode(mode) {
      this.$store.commit("setMode", mode);
    },
    unsetMode() {
      this.$store.commit("unsetMode");
    },
  },
  computed:{
    selectedMode(){return this.$store.getters.selectedMode}
  }
};
</script>

<style scoped>
</style>