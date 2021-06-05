<template>
    <div>
        <h1>Add Individual Ingredient Record</h1>
        <form @submit.prevent="">

        </form>
    </div>
</template>

<script>
export default {
    name: "AddIndividualIngredientRecord",
    data(){
        return {

        }
    },
    methods:{
        submitForm(){
            let record = {}
            this.$emit('addRecord', record)
        }
    }
}
</script>

<style scoped>

</style>