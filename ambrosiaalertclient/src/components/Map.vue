<script setup>
import ambrosiaImgPath from '@/assets/ambrosia.svg';
import atmImgPath from '@/assets/atm.svg';
import { getFindings } from '@/assets/getFindings.js';
import { ref, watch, onMounted, computed } from "vue";
import { GoogleMap, Marker } from "vue3-google-map";

const props=defineProps({
  isMapClickable: false
});

const reactiveIsMapClickable=ref(props.isMapClickable);

const userCenter = ref(
  { lat: 45.749578, lng: 21.243070 },
);
let initialFindings = await getFindings();
const findings = ref(initialFindings);


function getCurrentLocation() {
  navigator.geolocation.getCurrentPosition((position) => {
    userCenter.value.lat = position.coords.latitude;
    userCenter.value.lng = position.coords.longitude;
  })
};

const windowWidth = computed(() => window.innerWidth);
console.log(windowWidth);
onMounted(() =>
  getCurrentLocation()
);

const ambrosiaIcon = {
  url: ambrosiaImgPath,
  size: {
    width: 64,
    height: 64
  }
};
const atmIcon = {
  url: atmImgPath,
  size: {
    width: 120,
    height: 120
  }
};
const atmMarkerOption = {
  position: {
    lat: userCenter.value.lat,
    lng: userCenter.value.lng
  },
  title: "me",
  icon: atmIcon
};
const reactiveAtmMarkerOption = ref(atmMarkerOption);

const markersOptions = await ref({
  ...findings.value.map((f) => {
    const markerOption = {
      position: {
        lat: f.latitude,
        lng: f.longitude
      },
      title: f.plantId,
      icon: ambrosiaIcon
    }
    return markerOption;
  }),
  atmMarkerOption
});

async function refreshLocation() {
  getCurrentLocation;
  atmMarkerOption = {
    position: {
      lat: userCenter.value.lat,
      lng: userCenter.value.lng
    },
    title: "me",
    icon: atmIcon,
  };
};
async function refreshFindings() {
  findings.value = await getFindings();
};

function handleClickMap(event) {
  if (reactiveIsMapClickable.value) {
    console.log("click lat:", event.latLng.lat());
    console.log("click lat:", event.latLng.lng());
  }


}
const findingToPost = {
  PlantId: "",
  FindingId: "",
  UserId: "",
  Radius: 0.01,
  Latitude: 0,
  Longitude: 0
};

</script>
<template>
  <div class="mapComponent">
    <div style="width:80vw; height:1vh">
      <button @click="refreshLocation">Refresh Location</button>
      <button @click="refreshFindings">Get Latest Findings</button>
      <p>You are here: {{ reactiveAtmMarkerOption.position.lat }} {{ reactiveAtmMarkerOption.position.lng }}</p>
    </div>
    <div id="map">

      <GoogleMap api-key="AIzaSyC9kiuJIxPV4pRd1J4gSZE2mWs5hV_L1Y0" style="width:100%; height:700px" :center="userCenter"
        :zoom="19" :clickableIcons="true" @click="handleClickMap">
        <Marker :options="atmMarkerOptions" />
        <Marker v-for="marker in markersOptions" :options="marker" />
      </GoogleMap>

    </div>
  </div>



</template>