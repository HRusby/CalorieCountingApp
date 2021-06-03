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
      <metric-select :value="selectedMetricId" @input="(newMetric) => {selectedMetricId = newMetric}" />
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
import MetricSelect from './MetricSelect.vue';
export default {
  components: { MetricSelect },
  name: "NewMeal",
  data() {
    return {
      metrics: [],
      mealName: "",
      weight: null,
      selectedMetricId: null,
      cookedOn: null,
    };
  },
  methods: {
    submitForm() {
      let newMeal = {
        name: this.mealName,
        userId: this.$store.getters.selectedUser,
        cookedWeight: this.weight,
        cookedWeightMetricId: this.selectedMetricId,
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
    }
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
};
</script>

<style scoped>
</style>