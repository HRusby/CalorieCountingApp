<template>
  <div class="flex flex-col center">
    <h1>Calorie Tracking</h1>
    <input
      class="w-1/2 mx-auto"
      type="date"
      title="Tracking Date"
      v-model="trackingDate"
      @change="getTrackingData"
    />
    <table class="table-auto">
      <thead>
        <th>Name</th>
        <th>Quantity</th>
        <th>Calories</th>
        <th>DateTime</th>
      </thead>
      <tbody>
        <!-- Key composed of typeId and tableId to ensure uniqueness -->
        <tracking-record
          v-for="trackingRecord in trackingRecords"
          :record="trackingRecord"          
          :key="trackingRecord.typeId + '.' + trackingRecord.id"
        />
      </tbody>
      <tfoot>
        <td colspan="2">
          <button
            type="button"
            @click="showAddRecord = true"
            v-text="'Add Ingredient Record'"
          />
        </td>
        <td colspan="2">
          <button
            type="button"
            @click="showAddServing = true"
            v-text="'Add Meal Serving'"
          />
        </td>
      </tfoot>
    </table>

    <modal-dialogue v-model="showAddRecord">
      <add-tracking-record :typeId="2" v-model="trackingDate" @addRecord="addRecord" />
    </modal-dialogue>
    <modal-dialogue v-model="showAddServing">
      <add-tracking-record :typeId="1" v-model="trackingDate" @addRecord="addMealServing" />      
    </modal-dialogue>
  </div>
</template>

<script>
import ConfigData from "../../config/config.json";
import ModalDialogue from "../ModalDialogue.vue";
import AddTrackingRecord from "./AddTrackingRecord.vue";
import TrackingRecord from "./TrackingRecord.vue";
export default {
  name: "CalorieTracking",
  components: {
    TrackingRecord,
    ModalDialogue,
    AddTrackingRecord,
  },
  data() {
    return {
      trackingDate: new Date().toISOString().substr(0,10),
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
      .then((data) => (this.trackingRecords = data))
    },
    addRecord() {
      this.showAddRecord = false;
      this.getTrackingData();
    },
    addMealServing() {
      this.showAddServing = false;
      this.getTrackingData();
    },
  },
  created() {
    this.getTrackingData();
  },
};
</script>

<style scoped>
</style>
