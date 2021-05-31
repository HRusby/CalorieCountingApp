<template>
  <div>
    <p v-for="user in users" :key="user.id" @click="setUser(user.id)">
      {{ user.name }}
    </p>
  </div>
</template>

<script>
export default {
  name: "UserSelection",
  props: {},
  data() {
    return {
      users: [],
    }
  },
  methods: {
      setUser(id){
          this.$store.commit('setUser', id)
      }
  },
  created(){
    // TODO: Make call to backend to retrieve users
      this.users = [
          {name: "harry", id: 1},
          {name: "max", id: 2}
      ]
  }
};
</script>

<style scoped>
</style>
