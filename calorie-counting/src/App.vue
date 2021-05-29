<template>
  <user-selection></user-selection>
</template>

<script>
import UserSelection from './components/UserSelection.vue'

export default {
  name: 'App',
  components: {
    UserSelection
  }
}
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
