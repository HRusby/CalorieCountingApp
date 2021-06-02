<template>
  <div>
    <h1>Update Meal</h1>
    <p>{{ meal.id }}</p>
    <p>{{ meal.name }}</p>
    <p>{{meal.cookedWeight}}</p>
    <p>{{meal.cookedWeightMetricId}}</p>
    <p>{{meal.remainingWeight}}</p>
    <p>{{meal.cookedOn}}</p>
  </div>
</template>

<script>
export default {
  name: "UpdateMeal",
  props: {
    meal: Object,
  },
  data() {
    return {};
  },
  methods: {},
};
</script>

<style scoped>
</style>