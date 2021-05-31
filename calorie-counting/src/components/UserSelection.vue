<template>
  <div class="flex justify-center space-x-4">
    <a
      href="#"
      v-for="user in users"
      :key="user.id"
      @click="setUser(user.id)"
      :title="user.name"
      class="rounded-full h-20 w-20 flex items-center justify-center bg-green-600 text-lg text-white"
    >
      {{ user.name.charAt(0).toUpperCase() }}
    </a>
  </div>
</template>

<script>
export default {
  name: "UserSelection",
  props: {},
  data() {
    return {
      users: [],
    };
  },
  methods: {
    setUser(id) {
      this.$store.commit("setUser", id);
    },
  },
  created() {
    // TODO: Make call to backend to retrieve users
    this.users = [
      { name: "harry", id: 1 },
      { name: "max", id: 2 },
    ];
  },
};
</script>

<style scoped>
</style>
