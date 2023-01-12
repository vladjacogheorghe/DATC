import { createApp } from 'vue';
//import VueGoogleMaps from '@fawmi/vue-google-maps'
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './style.css';
import App from './App.vue';
// import { getAuhenticatedUser, intervalMilliSeconds } from "./components/utils/usermanagement/getAuhenticatedUser";
import router from "./router";
// import store from "./store";

async function init() {
    // await getAuhenticatedUser();

    const app = createApp(App
        //     , {
        //     beforeCreate() {
        //         store.commit("initialiseStore");
        //     },
        // }
    );
    // ----------- old googlemaps idea
    //app.use(VueGoogleMaps, {
    //     load: {
    //         key: 'AIzaSyC9kiuJIxPV4pRd1J4gSZE2mWs5hV_L1Y0',
    //     },
    // });
    app.use(router);
    app.mount("#app");
}

init();



// function loadScript(src) {
//     return new Promise(resolve => {
//         const script = document.createElement("script");
//         script.setAttribute("async", "");
//         script.onload = resolve;
//         script.setAttribute("src", src);
//         document.head.appendChild(script);
//     });
// }

// const urls = [
//     // "https://npmjs.com/package/@googlemaps/js-api-loader",
//   "https://maps.googleapis.com/maps/api/js?key=AIzaSyC9kiuJIxPV4pRd1J4gSZE2mWs5hV_L1Y0&callback=initMap"
   
// ];

// const promiseGoogleMaps = new Promise((resolve, reject) => {
//     setTimeout(() => {
//       resolve("foo");
//     }, 300);
//   });
// Promise.all(urls.map(loadScript)).then(ready);

// function ready() {
//     console.log("all loaded");
// }

// store.subscribe((mutation, state) => {
//     console.log("subscribe");
//     // Store the state object as a JSON string
//     localStorage.setItem("store", JSON.stringify(state));
// });
