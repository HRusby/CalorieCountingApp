<template>
  <select v-model="selectedIngredientId">
    <option disabled :value="NaN" v-text="'Meal'" />
    <option
      v-for="meal in meals"
      :key="meal.id"
      :value="meal.id"
      v-text="meal.name"
    />
  </select>
</template>

<script>
import ConfigData from "../../config/config.json";
export default {
  name: "MealSelect",
  props: {
    // Value representing the inital Ingredient Id (for updating an ingredient)
    modelValue: {
      required: true,
      type: Number,
    },
  },
  data() {
    return {
      meals: [],
    };
  },
  methods: {
    selectNewIngredient(newIngredient) {
      this.ingredients.push(newIngredient);
      this.selectedIngredientId = newIngredient.id;
    },
  },
  computed: {
    selectedIngredientId: {
      get() {
        return this.modelValue;
      },
      set(newIngredientId) {
        this.$emit("update:modelValue", newIngredientId);
      },
    },
  },
  created() {
    fetch(ConfigData.backendUrl + "Meal/GetMealsForUser", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(this.$store.getters.selectedUser),
    })
      .then((resp) => resp.json())
      .then((data) => (this.meals = data));
  },
};
</script>

<style scoped>
</style>