import { createApp } from 'vue';

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

    app.use(router);
    app.mount("#app");
}

init();

// store.subscribe((mutation, state) => {
//     console.log("subscribe");
//     // Store the state object as a JSON string
//     localStorage.setItem("store", JSON.stringify(state));
// });
