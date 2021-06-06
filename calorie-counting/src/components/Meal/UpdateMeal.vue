<template>
  <div>
    <h1>Update Meal</h1>
    <form @submit.prevent="submitForm">
      <input type="text" title="Name" v-model="meal.name" />
      <input
        type="number"
        title="Cooked Weight"
        min="0"
        step="0.01"
        v-model="meal.cookedWeight"
      />
      <metric-select
        title="Weight Metric"
        v-model="meal.cookedWeightMetricId"
      />
      <input
        type="number"
        title="Remaining Weight"
        min="0"
        step="0.01"
        v-model="meal.remainingWeight"
      />
      <input type="date" title="Cooked On" v-model="meal.cookedOn" />
      <button type="submit">Submit Changes</button>
    </form>
    <meal-ingredients :mealId="meal.id"/>
  </div>
</template>

<script>
import ConfigData from "../../config/config.json";
import MetricSelect from "../MetricSelect.vue";
import MealIngredients from './MealIngredients.vue';
export default {
  name: "UpdateMeal",
  components: { MetricSelect, MealIngredients },
  props: {
    mealToUpdate: {
      required: true,
      type: Object,
    },
  },
  data() {
    return { meal: this.mealToUpdate };
  },
  methods: {
    submitForm() {
      if(this.meal.remainingWeight === null)
        this.meal.remainingWeight = this.meal.cookedWeight
      fetch(ConfigData.backendUrl + "Meal/UpdateMeal", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.meal),
      })
        .then((resp) => resp.json())
        .then(data => data===true ? this.$emit("updatedMeal", this.meal) : console.log('Meal not updated'))
    }
  }
};
</script>

<style scoped>
</style>