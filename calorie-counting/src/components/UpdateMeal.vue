<template>
  <div>
    <h1>Update Meal</h1>
    <p>{{ meal.id }}</p>
    <p>{{ meal.name }}</p>
    <p>{{meal.cookedWeight}}</p>
    <metric-select :modelValue="meal.cookedWeightMetricId" @update:modelValue="(val) => {updateMeal('metric', val)}" ></metric-select>
    <p>{{meal.cookedWeightMetricId}}</p>
    <p>{{meal.remainingWeight}}</p>
    <p>{{meal.cookedOn}}</p>
  </div>
</template>

<script>
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
      var m = this.meal
      m[propertyName] = newValue
      this.$emit('updatedMeal', m)
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