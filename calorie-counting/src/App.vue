<template>
  <div>
    <app-header ></app-header>
    <div v-if="selectedUser === -1">
      <user-selection></user-selection>
    </div>
    <div v-else>
      <mode-selection></mode-selection>
    </div>
  </div>
</template>

<script>
import ModeSelection from "./components/ModeSelection.vue";
import UserSelection from "./components/UserSelection.vue";
import AppHeader from "./components/AppHeader.vue";

export default {
  name: "App",
  components: {
    UserSelection,
    ModeSelection,
    AppHeader,
  },
  methods: {},
  computed: {
    selectedUser() {
      return this.$store.getters.selectedUser;
    }
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #182836;
}
</style>
