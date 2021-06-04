<template>
    <p :key="value.id">
        {{value.ingredientName}} - {{value.quantity}}{{value.metricShortName}}
    </p>
</template>

<script>
export default {
    name: "MealIngredient",
    props: {
        /** Value has members:
            int id,
            int mealId,
            string ingredientName,            
            string metricShortName,            
            double quantity
         */
        value:{
            required: true,
            type: Object
        }
    },
}
</script>