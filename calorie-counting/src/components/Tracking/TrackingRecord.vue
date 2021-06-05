<template>
    <div>
        {{record.ingredientName}} - {{record.quantity}}{{record.metricShortName}} {{record.dateTime}}
    </div>
</template>

<script>

/** record has properties:
 *  id, userId, ingredientId, metricId, quantity, dateTime, ingredientName, metricShortName
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