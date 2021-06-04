<template>
    <div>
        <h1>Ingredients</h1>
        <meal-ingredient v-for="ingredient in mealIngredients" :key="ingredient.id" :value="ingredient" />
        <new-meal-ingredient :mealId="mealId" @addIngredient="addMealIngredient"/>
    </div>
</template>

<script>
import ConfigData from "../../config/config.json";
import MealIngredient from "./MealIngredient.vue";
import NewMealIngredient from "./NewMealIngredient.vue";
export default {
    name: "MealIngredients",
    components: {MealIngredient, NewMealIngredient},
    props:{
        mealId: {
            required: true,
            type: Number
        }
    },
    data(){
        return {
            mealIngredients: []
        }
    },
    methods: {
      addMealIngredient(newMealIngredient){
        // Push the new Ingredient to the API endpoint
        fetch(ConfigData.backendUrl + "MealIngredient/AddNewMealIngredient",
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(newMealIngredient)
        })
        .then(resp => resp.json())
        .then(data => console.log(data))

        // Refresh the Meal Ingredient List
        this.retrieveMealIngredients();
      },
      retrieveMealIngredients(){
        fetch(ConfigData.backendUrl + "MealIngredient/GetMealIngredientsForMealId",
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: this.mealId
        })
        .then(resp => resp.json())
        .then(data => this.mealIngredients = data)
      }
    },
    created() {
      // Get MealIngredients
      this.retrieveMealIngredients()
    }
}
</script>

<style scoped>
</style>