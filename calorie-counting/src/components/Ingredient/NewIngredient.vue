<template>
  <div>
    <h1>Create a New Ingredient</h1>
    <form @submit.prevent="addNewIngredient">
      <input
        type="text"
        v-model="name"
        title="Name"
        placeholder="Ingredient Name"
      />
      <input
        type="number"
        min="0"
        step="0.001"
        v-model="calories"
        title="Calories"
        placeholder="Calories"
      />
      for every
      <input
        type="number"
        min="0"
        step="0.001"
        v-model="metricQuantity"
        title="Metric Quantity"
        placeholder="Quantity"
      />
      <metric-select v-model="metricId" title="Metric" />
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<script>
import MetricSelect from "../MetricSelect.vue";
import ConfigData from "../../config/config.json";
export default {
  name: "NewIngredient",
  components: { MetricSelect },
  data() {
    return {
      name: "",
      calories: null,
      metricQuantity: null,
      caloriesPerMetric: null,
      metricId: NaN,
    };
  },
  methods: {
    addNewIngredient() {
      this.caloriesPerMetric = this.calories / this.metricQuantity;
      let ingredient = {
        name: this.name,
        caloriesPerMetric: this.caloriesPerMetric,
        metricId: this.metricId,
      };

      fetch(ConfigData.backendUrl + "Ingredient/AddNewIngredient", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(ingredient),
      })
      .then((resp) => resp.json())
      .then((id) => (ingredient["id"] = id))
      .then(() => this.$emit("ingredientCreated", ingredient))
      .then(()=>this.restForm())
    },
    resetForm(){
      this.name = ""
      this.calories = null
      this.metricQuantity = null
      this.caloriesPerMetric = null
      this.metricId = NaN
    }
  },
};
</script>

<style scoped>
</style>