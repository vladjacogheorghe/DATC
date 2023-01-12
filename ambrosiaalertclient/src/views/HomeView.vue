<script setup>
import { ref } from 'vue';
import { RouterLink, RouterView } from "vue-router";
import { getPlants } from '../assets/getPlants.js';
import Navbar from '../components/Navbar.vue';
import Map from '../components/Map.vue';

defineProps({
    msg: String,
})

let initialPlants = await getPlants();

const plantId=ref("");

const isMapClickable = ref(false);

function toggleIsMapClickable() {
    if (isMapClickable.value) {
        isMapClickable.value = false;
        closeNav();
    }
    else {
        isMapClickable.value = true;
        console.log("turnIsMapClickableOn", isMapClickable.value);
        openNav();
    }

}
function openNav() {
    document.getElementById("postFindingSidebar").style.width = "250px";
}
function closeNav() {
    document.getElementById("postFindingSidebar").style.width = "0";
} 
</script>

<template>
    <Navbar />
    <div class="view pt-5" id="view">

        <div id="postFindingSidebar" class="sidebar">
            <label class="container">Select a plant:{{ plantId }}
            </label>
            <input type="radio" v-for="plant in initialPlants" v-model="plantId" :value="plant.PlantId">{{ plant.Name }}
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="#">About</a>
            <a href="#">Services</a>
            <a href="#">Clients</a>
            <a href="#">Contact</a>
        </div>
        <div class="pageContent">
            <button class="btn postFindingSidebar" @click="toggleIsMapClickable">Report a finding</button>

            <Map :isMapClickable=isMapClickable></Map>

        </div>
    </div>

</template>

<style scoped>
.read-the-docs {
    color: #888;
}
</style>
