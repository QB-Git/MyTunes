<template>
    <div id="app">
        <div class="bg"></div>
            <Menu/>
        <!-- <overlay-scrollbars :options="osComponentOptions" :class="hasCustomClassName ? customClassName : ''"> -->
            <router-view id="aaa" class="content"/>
        <!-- </overlay-scrollbars> -->
        <!-- <lecteur-audio :sourceAudio="'//drive.google.com/uc?id=1QzqtWXki3yJdS2n6z8kLwvHDZYPogZTL'"/> -->

        <lecteur-audio/>
    </div>
</template>

<script>
import OverlayScrollbars from 'overlayscrollbars';

// OverlayScrollbars(document.body, {
//     nativeScrollbarsOverlaid: {
//         initialize: false
//     }
// });
OverlayScrollbars(document.getElementById('aaa'), {});

// var instance = OverlayScrollbars(, {
//
// });


import LecteurAudio from '@/components/LecteurAudio'
import Menu from '@/components/Menu'

export default {
    components: {
        Menu,
        LecteurAudio
    },
    name: 'App'
}
</script>

<style>

#app {
    color: #e9e9e9;
    /* overflow:hidden; */
}

.bg {
    background-color: rgb(35, 35, 35);
    background-image: url('../src/assets/test.svg');
    position: fixed;
    top: 0;
    width: 100vw;
    height: 100vh;
    z-index: 0;
}

.content {
    padding: 30px;
    padding-left: calc(30px + var(--menu-width));
    padding-bottom: 30px;
    display: flex;
    height: calc(100vh - var(--lecteur-audio-height));
    z-index: 1;
}

p {
    color: rgba(3,169,244,1);
}
</style>
