<template>
    <div>
        <h1>Add Meal Serving</h1>
        <form @submit.prevent="addMealServing">

        </form>
    </div>
</template>

<script>
export default {
    name: "AddMealServingRecord",
    data() {
        return {

        }
    },
    methods: {
        submitForm(){
            let mealServing = {}
            this.$emit('addMealServing', mealServing)
        }
    }
}
</script>

<style scoped>

</style>