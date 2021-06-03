<template>
  <select title="Metric" v-model="selectedMetric">
    <option disabled :value="null">Metric</option>
    <option v-for="metric in metrics" :key="metric.id" :value="metric.id">
      {{ metric.shortName }}
    </option>
  </select>
</template>

<script>
import ConfigData from "../config/config.json";
export default {
  name: "MetricSelect",
  props: {
    value: {
      required: false,
      type: Number,
    },
  },
  data() {
    return {
      metrics: []
    };
  },
  computed: {
    selectedMetric: {
        get() {return this.value},
        set(newMetric){this.$emit("input", newMetric)}
    }
  },
  created() {
    fetch(ConfigData.backendUrl + "Metric/GetMetrics", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((resp) => resp.json())
      .then((data) => (this.metrics = data));
  },
};
</script>