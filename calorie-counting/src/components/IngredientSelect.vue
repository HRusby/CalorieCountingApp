<template>
    <span>
        <select v-model="selectedIngredient">
        <option disabled :value="NaN">Ingredient</option>
        <option v-for="ingredient in ingredients" :key="ingredient.id" :value="ingredient.id">{{ingredient.name}}</option>
        <option :value="NaN" @click="showNewIngredientModal=!showNewIngredientModal">Add New Ingredient</option>
    </select>
        <modal-dialogue heading="newIngredient" v-model="showNewIngredientModal" >
            <form @submit.prevent="addNewIngredient">
                <button type="submit">Submit</button>
            </form>
        </modal-dialogue>
    </span>
</template>

<script>
import ConfigData from "../config/config.json";
import ModalDialogue from './ModalDialogue.vue';
export default {
  components: { ModalDialogue },
    name: "IngredientSelect",
    props: {
        modelValue: {
            required: true,
            type: Number
        }
    },
    data () {
        return {
            ingredients: [],
            showNewIngredientModal: false
        }
    },
    methods:{
        addNewIngredient(){
            console.log('Submitting Form')
        }
    },
    computed: {
        selectedIngredient: {
            get() {return this.modelValue},
            set(newMetric){this.$emit("update:modelValue", newMetric)}
        }
    },
    created(){
        fetch(ConfigData.backendUrl + "Ingredient/GetIngredients",
      {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        }
      })
      .then(resp => resp.json())
      .then(data => this.ingredients = data)
    }
}
</script>