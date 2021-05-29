<template>
  <div>
    <div v-if="this.$store.getters.selectedUser === -1">
      <user-selection></user-selection>
    </div>
    <div v-else @click="this.$store.commit('unsetUser')">user with id {{this.$store.getters.selectedUser}} has been selected</div>
  </div>
</template>

<script>
import UserSelection from "./components/UserSelection.vue";

export default {
  name: "App",
  components: {
    UserSelection,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
