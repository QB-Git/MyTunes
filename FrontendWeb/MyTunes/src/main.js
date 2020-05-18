// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vue from 'vue'
import App from './App'
import router from './router'

import "overlayscrollbars/css/OverlayScrollbars.css";
import { OverlayScrollbarsPlugin } from 'overlayscrollbars-vue';

// import AsyncComputed from 'vue-async-computed';

import VueResource from 'vue-resource'


Vue.config.productionTip = false;

// Vue.use(SuiVue);
// Vue.use(AsyncComputed);
Vue.use(OverlayScrollbarsPlugin);
Vue.use(VueResource);

/* eslint-disable no-new */
new Vue({
    el: '#app',
    router,
    components: { App },
    template: '<App/>'
})
