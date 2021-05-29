<template>
  <div>
    <p v-for="user in users" :key="user.id" @click="setUser(user.id)">
      {{ user.name }}
    </p>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {},
  data() {
    return {
      users: [],
    };
  },
  methods: {
      setUser(id){
          console.log(id)
      }
  },
  created(){
      this.users = [
          {name: "harry", id: 1},
          {name: "max", id: 2}
      ]
  }
};
</script>

<style scoped>
</style>
