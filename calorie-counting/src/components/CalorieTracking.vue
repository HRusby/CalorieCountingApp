<template>
    <div>
        <h1>Calorie Tracking</h1>
        <input type="date" title="Tracking Date" :value="trackingDate" />
        <tracking-record v-for="trackingRecord in trackingRecords" :record="trackingRecord" :key="trackingRecord.id" />
    </div>
</template>

<script>
import ConfigData from "../config/config.json";
import TrackingRecord from './Tracking/TrackingRecord.vue';
export default {
  components: { TrackingRecord },
    name: "CalorieTracking",
    data(){
        return {
            trackingDate: new Date().toISOString().substr(0,10),
            trackingRecords: []
        }
    },
    methods: {
        getTrackingData(){
            // Fetch tracking data from api for the given date and user
            let trackingRequest = {
                userId: this.$store.getters.selectedUser,
                date: this.trackingDate
            }
            fetch(ConfigData.backendUrl + "Tracking/GetTrackingDataForDateAndUser", {
                method: "POST",
                headers: {
                "Content-Type": "application/json",
                },
                body: JSON.stringify(trackingRequest),
            })
            .then(resp => resp.json())
            .then(data => this.trackingRecords = data);
        }
    },
    created(){
        this.getTrackingData()
    }
}
</script>

<style scoped>

</style>
