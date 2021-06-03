<template>
  <div>
    <h1>Update Meal</h1>
    <p>{{ meal.id }}</p>
    <p>{{ meal.name }}</p>
    <p>{{meal.cookedWeight}}</p>
    <metric-select :modelValue="meal.cookedWeightMetricId" @update:modelValue="(val) => {updateMeal('cookedWeightMetricId', val)}" ></metric-select>
    <p>{{meal.remainingWeight}}</p>
    <p>{{meal.cookedOn}}</p>
  </div>
</template>

<script>
import ConfigData from "../config/config.json";
import MetricSelect from './MetricSelect.vue';
export default {
  name: "UpdateMeal",
  components: { MetricSelect },
  props: {
    mealToUpdate: {
      required: true,
      type: Object
    }
  },
  methods: {
    updateMeal(propertyName, newValue){
      this.meal[propertyName] = newValue
      this.$emit('updatedMeal', this.meal)
      this.pushToApi()
    },
    pushToApi(){
      fetch(ConfigData.backendUrl + "Meal/UpdateMeal", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.meal)
      })
      .then((resp) => resp.json())
      .then((data) => console.log('data: '+data));
    }
  },
  computed: {
    meal() {
      return this.mealToUpdate
    }
  }
};
</script>

<style scoped>
</style>