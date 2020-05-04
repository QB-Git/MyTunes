<template>
    <div class="LecteurAudio">
        <!-- <audio controls :src="source"></audio> -->
        <div id="master"></div>
    </div>
</template>

<script>
require('webpack-jquery-ui/slider');
require('webpack-jquery-ui/css');
import $ from 'jquery'

$(() => {
    $("#master").slider({
        value: 0,
        orientation: "horizontal",
        range: "min",
        animate: "fast",
        change: function(event, ui) {
            //console.log(ui.value);
        },
        start: function(event, ui) {
            $('.ui-slider-range').addClass('slider-range-active');
        },
        stop: function(event, ui) {
            $('.ui-slider-range').removeClass('slider-range-active');
        }
    });
    // setInterval(()=>{
    //     console.log("aaa");
    // }, 1000);
});

export default {
    name: 'LecteurAudio',
    props: {
        sourceAudio: {
            type: String,
            default: '//www.hochmuth.com/mp3/Haydn_Cello_Concerto_D-1.mp3'
        }
    },
    data () {
        return {
            source: this.sourceAudio
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    :root {
        --lecteur-audio-height: 85px;
        /* --percent-music: 0%; */
    }

    #master {
        border: 0px solid transparent;
        height: 4px;
        background-color: #535353; /*gris foncé*/
        width: 80%;
    }
    #master:hover .ui-slider-range, .slider-range-active {
        background-color: #1db954 !important; /*vert*/
    }
    #master * {
        border: 0px solid transparent;
    }
    #master .ui-slider-handle { /*bouton curseur*/
        border-radius: 50%;
        height: 12px;
        width: 12px;
        box-shadow: 0 2px 4px 0 rgba(0,0,0,.5);
        top: -100%;
        /* opacity: 0;
        transition: opacity .15s ease-in-out; */
    }
    #master .ui-slider-handle.ui-state-active {
        background: #f6f6f6;
    }
    #master .ui-slider-handle:focus {
        outline-width: 0px;
    }
    #master:hover .ui-slider-handle {
        opacity: 1;
    }
    #master .ui-slider-range {
        background-color: #b3b3b3; /*gris clair*/
    }

    .LecteurAudio {
        width: 100vw;
        height: var(--lecteur-audio-height);
        position: fixed;
        bottom: 0;
        background-color: rgba(50, 50, 50, 0.95);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 2;
    }
</style>
