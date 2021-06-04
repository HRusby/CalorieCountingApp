<template>
    <form @submit.prevent="submitForm">
        <ingredient-select title="Ingredient" v-model="ingredientId"/>
        <metric-select title="Metric" v-model="metricId"/>
        <input type="number" min="0.0" step="0.01" placeholder="Quantity" title="Quantity" v-model="quantity"/>
        <button type="submit">Submit</button>
    </form>
</template>

<script>

import IngredientSelect from '../Ingredient/IngredientSelect.vue'
import MetricSelect from '../MetricSelect.vue'
export default {
  components: { MetricSelect, IngredientSelect },
    name: "NewMealIngredient",
    props: {
        mealId: {
            required: true,
            type: Number
        }
    },
    data(){
        return {
            ingredientId: NaN,
            metricId: NaN,
            quantity: null
        }
    },
    methods:{
        submitForm(){
            let ingredient={
                mealId: this.mealId,
                ingredientId: this.ingredientId,
                metricId: this.metricId,
                quantity: this.quantity
            }

            this.$emit("addIngredient", ingredient)
        }
    }
}
</script>