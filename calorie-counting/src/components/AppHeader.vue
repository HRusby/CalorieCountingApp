<template>
  <nav class="container mb-5 py-10 bg-green-400 text-white shadow-lg">
    <span>Calorie Counting App</span>
    <a href='#' class="mx-2" v-if="selectedUser !== -1" @click="unsetUser" title='Change User'>U</a>
    <a href='#' class="mx-2" v-if="selectedMode !== ''" @click="unsetMode" title='Change Mode'>M</a>
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
</style>