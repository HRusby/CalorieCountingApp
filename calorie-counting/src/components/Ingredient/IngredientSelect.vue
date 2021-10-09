<template>
  <span>
    <select v-model="selectedIngredientId">
      <option disabled :value="NaN" v-text="'Ingredient'" />
      <option
        v-for="ingredient in ingredients"
        :key="ingredient.id"
        :value="ingredient.id"
        v-text="ingredient.name + ' (' + ingredient.metricShortName + ')'"
      />
      <option
        :value="NaN"
        @click="showNewIngredientModal = !showNewIngredientModal"
        v-text="'Add New Ingredient'"
      />
    </select>
    <modal-dialogue v-model="showNewIngredientModal">
      <new-ingredient @ingredientCreated="selectNewIngredient" />
    </modal-dialogue>
  </span>
</template>

<script>
import ConfigData from "../../config/config.json";
import ModalDialogue from "../ModalDialogue.vue";
import NewIngredient from "./NewIngredient.vue";
export default {
  components: { ModalDialogue, NewIngredient },
  name: "IngredientSelect",
  props: {
    // Value representing the inital Ingredient Id (for updating an ingredient)
    modelValue: {
      required: true,
      type: Number,
    },
  },
  data() {
    return {
      ingredients: [],
      showNewIngredientModal: false,
    };
  },
  methods: {
    getIngredients() {
      fetch(ConfigData.backendUrl + "Ingredient/GetIngredients", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((resp) => resp.json())
        .then((data) => (this.ingredients = data));
    },
    selectNewIngredient(newIngredient) {
      this.getIngredients()
      this.selectedIngredientId = newIngredient.id
      this.showNewIngredientModal = !this.showNewIngredientModal
      // TODO:  Update NewIngredient to also get MetricShortName when adding ingredient 
      //          so the additional lookup isn't necessary. Can be done by updating MetricSelect
      //          to bind a Metric Object rather than metricId then below code can be used instead.
      // this.ingredients.push(newIngredient);
      // this.selectedIngredientId = newIngredient.id;    
    },
  },
  computed: {
    selectedIngredientId: {
      get() {
        return this.modelValue;
      },
      set(newIngredientId) {
        this.$emit("update:modelValue", newIngredientId);
      },
    },
  },
  created() {
    this.getIngredients()
  },
};
</script>