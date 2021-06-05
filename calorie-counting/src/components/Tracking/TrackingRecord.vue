<template>
    <tr>
        <td>{{record.mealOrIngredientName}}</td>
        <td>{{record.quantity}}{{record.metricShortName}}</td>
        <td>{{record.calories}}</td>
        <td>{{record.dateTime}}</td>
    </tr>
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