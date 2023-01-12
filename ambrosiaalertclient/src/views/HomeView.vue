<script setup>
import { ref } from 'vue';
import { RouterLink, RouterView } from "vue-router";
import { getPlants } from '../assets/getPlants.js';
import Map from '../components/Map.vue';

defineProps({
    msg: String,
})

const plantId=ref("");

const initialPlants = await getPlants();
const plants = ref(initialPlants);

const isMapClickable = ref(false);

function openNav() {
    isMapClickable.value = true;
    console.log("turnIsMapClickableOn", isMapClickable.value);
    console.log("initialPlants", plants);
    document.getElementById("postFindingSidebar").style.width = "250px";
}
function closeNav() {
    isMapClickable.value = false;
    console.log("turnIsMapClickableOff", isMapClickable.value);
    document.getElementById("postFindingSidebar").style.width = "0";
} 
</script>

<template>
    <nav class="navbar navbar-expand-lg stickey-top navbar-dark bg-dark">
        <a class="navbar-brand" href="#">Ambrosia Alert</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02"
            aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                <li class="nav-item active">
                    <button class="btn postFindingSidebar nav-link" @click="openNav" href="#">Report a finding<span
                            class="sr-only">(current)</span></button>
                </li>

            </ul>
            <!-- <form class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="search" placeholder="Search">
      <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
    </form> -->
        </div>
    </nav>
    <div class="view pt-5" id="view">

        <div id="postFindingSidebar" class="sidebar">

            <a href="javascript:void(0)" class="closebtn" @click="closeNav()">&times;</a>
            <a href="#">Select a plant: {{ plantId }} {{ isMapClickable }}

            </a>
            <select v-model="plantId">
                <option disabled value="">Please select one</option>
                <option v-for="plant in initialPlants" :value="plant.plantId">{{plant.name}}</option>
            </select>
           
        </div>
        <div class="pageContent">
            <Map :isMapClickable="isMapClickable" :plantIdOfFinding="plantId"></Map>

        </div>
    </div>

</template>

<style scoped>
.read-the-docs {
    color: #888;
}
</style>
