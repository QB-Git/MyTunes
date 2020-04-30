// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vue from 'vue'
import App from './App'
import router from './router'
import SuiVue from 'semantic-ui-vue'
import 'semantic-ui-css/semantic.min.css';

import "overlayscrollbars/css/OverlayScrollbars.css";
import { OverlayScrollbarsPlugin } from 'overlayscrollbars-vue';


Vue.config.productionTip = false;

Vue.use(SuiVue);
Vue.use(OverlayScrollbarsPlugin);

/* eslint-disable no-new */
new Vue({
    el: '#app',
    router,
    components: { App },
    template: '<App/>'
})
// 
// OverlayScrollbars(document.getElementsByClassName('main')[0], {});
