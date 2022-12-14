<script setup>
import initMap from '../assets/initMap.js';
// renderMap = () => {
//   loadScript("https://maps.googleapis.com/maps/api/js?key=API_KEY&callback=initMap");
//   window.initMap = this.initMap;
// }

let map;



window.initMap = initMap;
</script>
<template>
    <div id="map"></div>
</template>