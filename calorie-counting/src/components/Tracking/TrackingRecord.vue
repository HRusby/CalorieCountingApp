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