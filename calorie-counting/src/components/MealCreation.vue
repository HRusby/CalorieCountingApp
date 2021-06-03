<template>
  <div class="flex space-y-2 grid grid-cols-1 text-center">
    <h1 class="mx-auto">Meal Creation</h1>
    <br />
    <div v-if="!createNewMeal && selectedMealId===null" class="container">
      <button
        @click="createNewMeal = true; selectedMeal = null"
        class="rounded-full h-10 w-40 flex items-center justify-center bg-green-600 text-lg text-white mx-auto my-2"
      >Add New Meal</button>

      <select v-model="selectedMealId">
        <option disabled :value="null">Select a Meal</option>
        <option v-for="meal in existingMeals" :key="meal.id" :value="meal.id">{{meal.name}}</option>
      </select>      
    </div>
    <div>      
      <new-meal v-if="createNewMeal" @meal-created="mealCreated"></new-meal>
      <update-meal v-else-if="selectedMealId !== null" :meal="selectedMeal"></update-meal>
    </div>
  </div>
</template>

<script>
import NewMeal from './NewMeal.vue';
import UpdateMeal from './UpdateMeal.vue';
import ConfigData from '../config/config.json';

export default {
  components: { NewMeal, UpdateMeal },
  name: "MealCreation",
  data() {
    return {
      createNewMeal: false,
      existingMeals: [],
      selectedMealId: null
    }
  },
  methods:{
    // Take the meal created in NewMeal.vue and add it to the meals retrieved in created()
    // Reset CreateNewMeal to false and set the SelectedMealId to the created meal id so the user can immediately add new ingredient
    mealCreated(meal){
      this.createNewMeal = false
      this.selectedMealId = meal.id
      this.existingMeals.push(meal)
    }
  },
  computed: {
    selectedMeal(){
      console.log('selectedMealId: ' + this.selectedMealId)
      var meal = this.existingMeals.filter(obj => {return obj.id === this.selectedMealId})[0]
      console.log('selectedMeal')
      console.log(meal)
      return meal
    }
  },
  created(){
    // Retrieve and set all of the Meals for the selected user
    fetch(ConfigData.backendUrl + "Meal/GetMealsForUser",
      {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: this.$store.getters.selectedUser
      })
      .then(resp => resp.json())
      .then(data => this.existingMeals = data)
  }
};
</script>

<style scoped>
</style>