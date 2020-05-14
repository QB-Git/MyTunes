<template>
    <div id="app">
        <div class="bg"></div>
        <Menu/>
        <overlay-scrollbars>
        <div class="main">
            <div class="ui black icon message transition">
                <i class="close icon"></i>
                <i class="sign-in icon"></i>
                <div class="content">
                    <div class="header">Vous n'êtes pas connecté</div>
                    <p>En vous connectant vous pourrez accéder à plus de fonctionnalités. <router-link to="/profil">Se connecter</router-link></p>
                </div>
            </div>
            <router-view class="main-content"/>
        </div>
      </overlay-scrollbars>
        <lecteur-audio :sourceAudio="'//drive.google.com/uc?id=1QzqtWXki3yJdS2n6z8kLwvHDZYPogZTL'"/>

        <!-- <div id="amplitude-play-pause" class="amplitude-paused"></div> -->
        <!-- <lecteur-audio/> -->
    </div>
</template>

<script>
window.$ = window.jQuery = require('jquery')
window._ = require('underscore')
require('semantic-ui-css/semantic.css')
require('semantic-ui-css/semantic.js')
require('@/js/api.js')

// window.Amplitude = require('amplitudejs/dist/amplitude.js')
// // import 'amplitudejs/dist/amplitude.js';
//
// console.log('Amplitude',Amplitude);
//
// Amplitude.init({
//     "songs": [
//         {
//             "name": "Risin' High (feat Raashan Ahmad)",
//             "artist": "Ancient Astronauts",
//             "album": "We Are to Answer",
//             "url": "https://521dimensions.com/song/Ancient Astronauts - Risin' High (feat Raashan Ahmad).mp3",
//             "cover_art_url": "https://521dimensions.com/img/open-source/amplitudejs/album-art/we-are-to-answer.jpg"
//         },
//         {
//             "name": "Risin' High (feat Raashan Ahmad)",
//             "artist": "Ancient Astronauts",
//             "album": "We Are to Answer",
//             "url": "https://521dimensions.com/song/Ancient Astronauts - Risin' High (feat Raashan Ahmad).mp3",
//             "cover_art_url": "https://521dimensions.com/img/open-source/amplitudejs/album-art/we-are-to-answer.jpg"
//         }
//     ],
//     "autoplay": true
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
html {
    overflow: hidden;
}
.bg {
    background-color: rgb(35, 35, 35);
    /* background-image: url('../src/assets/test.svg'); */
    background-image: url('../src/assets/test.svg'), linear-gradient(-134deg, #C182DC 0%, #FB7C62 94%, #FF7C5B 100%);
    position: fixed;
    top: 0;
    width: 100vw;
    height: 100vh;
    z-index: 0;
}

.main {
    padding: 30px;
    padding-left: calc(30px + var(--menu-width));
    padding-bottom: 30px;
    height: calc(100vh - var(--lecteur-audio-height));
}

.main * {
    z-index: 1;
}

.main-content p {
    color: rgba(3,169,244,1);
}

.ui.message {
    /* background-color: rgba(0, 0, 0, 0.4); */
    /* color: #276f86; */
    color: white;
}

.ui.header {
    color: white;
    text-align: center;
    margin-bottom: 1.5em;
}

.main-content {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
}
</style>
