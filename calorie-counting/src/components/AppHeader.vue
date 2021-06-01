<template>
  <nav class="flex mb-5 py-10 bg-green-600 text-white shadow-lg">
    <span class="mx-auto">Calorie Counting App</span>
    <button class="mx-2" v-if="selectedUser !== -1" @click="unsetUser" title='Change User'>U</button>
    <button class="mx-2" v-if="selectedMode !== ''" @click="unsetMode" title='Change Mode'>M</button>
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