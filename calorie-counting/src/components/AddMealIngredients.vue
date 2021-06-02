<template>
    <div>
    </div>
</template>

<script>
export default {
    name: "AddMealIngredients",
    props: {
        mealId: Number
    },
    data () {
        return {
            ingredients: []
        }
    },
    created(){
        this.ingredients = [
            {id: 1, }
        ]
        // TODO: Request API to Get current Ingredients for meal
    },
    methods: {

    },
    computed: {

    }
}
</script>