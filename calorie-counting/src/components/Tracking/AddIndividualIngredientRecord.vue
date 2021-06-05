<template>
    <div>
        <h1>Add Individual Ingredient Record</h1>
        <form @submit.prevent="submitForm">
            <ingredient-select v-model="mealOrIngredientId" />
            <input type="number" min="0.0" step="0.01" v-model="quantity" title="quantity" placeholder="quantity" />
            <input type="datetime" v-model="dateTime" title="Date Time" placeholder="datetime" />
            <button type="submit" v-text="'Submit'"/>
        </form>
    </div>
</template>

<script>
import ConfigData from '../../config/config.json';
import IngredientSelect from '../Ingredient/IngredientSelect.vue'
export default {
  components: { IngredientSelect },
    name: "AddIndividualIngredientRecord",
    data(){
        return {
            mealOrIngredientId: NaN,
            quantity: NaN,
            dateTime: new Date().toISOString()
        }
    },
    methods:{
        submitForm(){
            let record = {
                mealOrIngredientId: this.mealOrIngredientId,
                userId: this.$store.getters.selectedUser,
                typeId: 2,
                quantity: this.quantity,
                dateTime: this.dateTime
            }

            fetch(ConfigData.backendUrl + "Tracking/AddNewRecord", {
                method: "POST",
                headers: {
                "Content-Type": "application/json",
                },
                body: JSON.stringify(record),
            })
            .then((resp) => resp.json())
            .then((data) => console.log("data: " + data));

            //this.$emit('addRecord', record)
        }
    }
}
</script>

<style scoped>

</style>