<template>
  <div>
    <div v-if="selectedUser === -1">
      <user-selection></user-selection>
    </div>
    <div v-else>
      <p @click="unsetUser">Unset User</p>
      <mode-selection></mode-selection>
    </div>
  </div>
</template>

<script>
import ModeSelection from "./components/ModeSelection.vue";
import UserSelection from "./components/UserSelection.vue";

export default {
  name: "App",
  components: {
    UserSelection,
    ModeSelection,
  },
  methods: {
    unsetUser() {
      this.$store.commit("unsetUser");
    },
  },
  computed: {
    selectedUser() {
      return this.$store.getters.selectedUser;
    },
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
