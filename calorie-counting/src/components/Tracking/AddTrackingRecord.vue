<template>
    <div>
        <h1>Add Tracking Record</h1>
        <form @submit.prevent="">

        </form>
    </div>
</template>

<script>
export default {
    name: "AddTrackingRecord",
    data(){
        return {

        }
    },
    methods:{
        submitForm(){
            let record = {}
            this.$emit('addRecord', record)
        }
    }
}
</script>

<style scoped>

</style>