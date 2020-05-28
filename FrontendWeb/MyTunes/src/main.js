// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vue from 'vue'
import App from './App'
import router from './router'

import "overlayscrollbars/css/OverlayScrollbars.css";
import { OverlayScrollbarsPlugin } from 'overlayscrollbars-vue';

// import AsyncComputed from 'vue-async-computed';

import VueResource from 'vue-resource'


import VueCookies from 'vue-cookies'


Vue.config.productionTip = false;

// Vue.use(SuiVue);
// Vue.use(AsyncComputed);
Vue.use(OverlayScrollbarsPlugin);
Vue.use(VueResource);

Vue.use(VueCookies)

Vue.$cookies.config('7d')

// set global cookie
if(!Vue.$cookies.isKey('user')) {
    Vue.$cookies.set('user','invite');
}

/* eslint-disable no-new */
new Vue({
    el: '#app',
    router,
    components: { App },
    template: '<App/>'
})
