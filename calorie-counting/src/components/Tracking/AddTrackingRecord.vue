<template>
    <div>
        <h1>
            Add {{ typeId === 1 ? 'Meal Serving' : typeId === 2 ? 'Individual Ingredient' :''}} Record
        </h1>
        <form @submit.prevent="submitForm">
            <ingredient-select v-if="typeId===2" v-model="mealOrIngredientId" />
            <meal-select v-if="typeId===1" v-model="mealOrIngredientId" />
            <input type="number" min="0.0" step="0.01" v-model="quantity" title="quantity" placeholder="quantity" />
            <input type="datetime-local" v-model="dateTime" title="Date Time" placeholder="datetime" />
            <button type="submit" v-text="'Submit'"/>
        </form>
    </div>
</template>

<script>
import ConfigData from '../../config/config.json';
import IngredientSelect from '../Ingredient/IngredientSelect.vue'
import MealSelect from '../Meal/MealSelect.vue'
export default {
  components: { IngredientSelect, MealSelect },
    name: "AddTrackingRecord",
    props: {
        typeId:{
            required: true,
            type: Number
        },
        modelValue: {
            required: true,
            type: String
        }
    },
    data(){
        return {
            mealOrIngredientId: NaN,
            quantity: NaN,
            dateTime: this.modelValue + 'T' + this.currentTime()
        }
    },
    updated(){
        this.dateTime = this.modelValue + 'T' + this.currentTime()
    },
    methods:{
        submitForm(){
            let record = {
                mealOrIngredientId: this.mealOrIngredientId,
                userId: this.$store.getters.selectedUser,
                typeId: this.typeId,
                quantity: this.quantity,
                dateTime: new Date(this.dateTime).toJSON()
            }

            fetch(ConfigData.backendUrl + "Tracking/AddNewRecord", {
                method: "POST",
                headers: {
                "Content-Type": "application/json",
                },
                body: JSON.stringify(record),
            })
            .then((resp) => resp.json())
            .then(data => {
                if(data){
                    this.$emit('addRecord')
                }else{
                    alert('Adding ' + this.typeId === 1 ? 'Meal Serving' : this.typeId === 2 ? 'Individual Ingredient' :'' + 'Unsuccessful')
                }
            })
            .then(()=>this.resetForm());
        },
        currentTime(){
            var curDate = new Date();
            return (curDate.getHours()+':'+curDate.getMinutes())
        },
        resetForm(){
            this.mealOrIngredientId = NaN
            this.quantity = NaN
            this.dateTime = this.modelValue + 'T' + this.currentTime()
        }
    }
}
</script>

<style scoped>
</style>