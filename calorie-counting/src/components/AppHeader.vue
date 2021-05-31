<template>
  <nav>
    <span>Calorie Counting App</span>
    <span v-if="selectedUser !== -1" @click="unsetUser">Change User</span>
    <span v-if="selectedMode !== ''" @click="unsetMode">Change Mode</span>
  </nav>
</template>

<script>
export default {
  name: "AppHeader",
  data() {
    return {};
  },
  methods: {
    unsetUser() {
      this.$store.commit("unsetUser");
    },
    unsetMode() {
      this.$store.commit("unsetMode");
    }
  },
  computed: {
    selectedUser() {
      return this.$store.getters.selectedUser;
    },
    selectedMode() {
      return this.$store.getters.selectedMode;
    }
  },
};
</script>

<style scoped>
    nav{
        position: relative;        
        width: 100%;
        padding: 60px;
        text-align: center;
        background: darkgreen;
        color: white;
    }
</style>