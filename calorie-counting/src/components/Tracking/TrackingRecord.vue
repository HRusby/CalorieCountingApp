<template>
    <div>
        {{record.mealOrIngredientName}} - {{record.quantity}}{{record.metricShortName}} {{record.dateTime}}
    </div>
</template>

<script>

/** record has properties:
 *  id, mealOrIngredientId, userId, typeId, mealOrIngredientName, metricShortName, quantity, calories, dateTime
 */

// TODO: On clicking div change to an editable form to update data
export default {
    name: "TrackingRecord",
    props: {
        record: {
            required: true,
            type: Object
        }
    }
}
</script>