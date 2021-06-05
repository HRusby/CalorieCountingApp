<template>
  <div>
    <h1>Calorie Tracking</h1>
    <input
      type="date"
      title="Tracking Date"
      v-model="trackingDate"
      @change="getTrackingData"
    />
    <tracking-record
      v-for="trackingRecord in trackingRecords"
      :record="trackingRecord"
      :key="trackingRecord.id"
    />
    <button type="button" @click="showAddRecord = true">Add Record</button>
    <button type="button" @click="showAddServing = true">
      Add Meal Serving
    </button>
    <modal-dialogue v-model="showAddRecord">
      <add-tracking-record @addRecord="addRecord" />
    </modal-dialogue>
    <modal-dialogue v-model="showAddServing">
      <add-meal-serving @addMealServing="addMealServing" />
    </modal-dialogue>
  </div>
</template>

<script>
import ConfigData from "../config/config.json";
import ModalDialogue from "./ModalDialogue.vue";
import AddMealServing from "./Tracking/AddMealServing.vue";
import AddTrackingRecord from "./Tracking/AddTrackingRecord.vue";
import TrackingRecord from "./Tracking/TrackingRecord.vue";
export default {
  name: "CalorieTracking",
  components: {
    TrackingRecord,
    ModalDialogue,
    AddTrackingRecord,
    AddMealServing,
  },
  data() {
    return {
      trackingDate: new Date().toISOString().substr(0, 10),
      trackingRecords: [],
      showAddRecord: false,
      showAddServing: false,
    };
  },
  methods: {
    getTrackingData() {
      // Fetch tracking data from api for the given date and user
      let trackingRequest = {
        userId: this.$store.getters.selectedUser,
        date: this.trackingDate,
      };
      fetch(ConfigData.backendUrl + "Tracking/GetTrackingDataForDateAndUser", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(trackingRequest),
      })
        .then((resp) => resp.json())
        .then((data) => (this.trackingRecords = data));
    },
    addRecord(record){
        console.log(record)
    },
    addMealServing(mealServing){
        console.log(mealServing)
    }
  },
  created() {
    this.getTrackingData();
  },
};
</script>

<style scoped>
</style>
