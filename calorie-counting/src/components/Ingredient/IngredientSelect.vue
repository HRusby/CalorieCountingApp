<template>
  <span>
    <select v-model="selectedIngredientId">
      <option disabled :value="NaN" v-text="'Ingredient'" />
      <option
        v-for="ingredient in ingredients"
        :key="ingredient.id"
        :value="ingredient.id"
        v-text="ingredient.name + ' ('+ingredient.metricShortName+')'"
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
// Todo display metric shortname in option value (in parentheses)
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
    selectNewIngredient(newIngredient) {
      this.ingredients.push(newIngredient);
      this.selectedIngredientId = newIngredient.id;
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
    fetch(ConfigData.backendUrl + "Ingredient/GetIngredients", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((resp) => resp.json())
      .then((data) => (this.ingredients = data));
  },
};
</script>