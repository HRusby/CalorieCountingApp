<template>
  <div class="text-center">
    <h1>New Meal</h1>
    <form @submit.prevent="submitForm">
      <input
        type="text"
        title="Meal Name"
        placeholder="Meal Name"
        v-model="mealName"
      />
      <br />
      <input
        type="number"
        title="Weight"
        placeholder="Weight"
        v-model="weight"
      />
      <select title="Metric" v-model="selectedMetric">
        <option disabled :value="null">Metric</option>
        <option v-for="metric in metrics" :key="metric.id" :value="metric.id">
          {{ metric.shortName }}
        </option>
      </select>
      <br />
      <label for="CookedOn">Cooked On: </label>
      <input
        name="CookedOn"
        title="Cooked On"
        type="date"
        v-model="cookedOn"
        :defaultValue="todaysDateString"
      />
      <br />
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<script>
import ConfigData from "../config/config.json";
export default {
  name: "NewMeal",
  data() {
    return {
      metrics: [],
      mealName: "",
      weight: null,
      selectedMetric: null,
      cookedOn: null,
    };
  },
  methods: {
    submitForm() {
      let newMeal = {
        name: this.mealName,
        userId: this.$store.getters.selectedUser,
        cookedWeight: this.weight,
        cookedWeightMetricId: this.selectedMetric,
        remainingWeight: null,
        cookedOn: this.cookedOn,
      };

      fetch(ConfigData.backendUrl + "Meal/AddNewMeal", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newMeal),
      })
        .then((resp) => resp.json())
        .then((mealId) => (newMeal.id = mealId))
        .then(() => this.$emit("mealCreated", newMeal));
      // TODO: Push request to API
    },
  },
  computed: {
    todaysDateString() {
      var date = new Date();
      var year = date.getFullYear();
      var month = date.getMonth() + 1;
      var dt = date.getDate();

      if (dt < 10) {
        dt = "0" + dt;
      }
      if (month < 10) {
        month = "0" + month;
      }

      return year + "-" + month + "-" + dt;
    },
  },
  created() {
    // TODO: Request metrics from API
    fetch(ConfigData.backendUrl + "Metric/GetMetrics", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((resp) => resp.json())
      .then((data) => this.metrics=data);
  },
};
</script>

<style scoped>
</style>