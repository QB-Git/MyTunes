<template>
    <div class="LecteurAudio">
        <audio :src="laudio_source" preload="metadata"></audio>
        <span class="picture">
            <img :src="laudio_pochette" alt="Pas de pochette">
        </span>
        <div class="infos-musiques">
            <span class="album">{{ laudio_album }}</span>
            <span class="artiste">{{ laudio_artiste }}</span>
            <span class="piste">{{ laudio_titre }}</span>
        </div>
        <div class="lecteur">
            <div class="controls">
                <span class="precedent" v-html='precedent'></span>
                <!-- <span class="play-pause" v-html='play' @click='changePlayPause' v-if='boolPlay'></span>
                <span class="play-pause" v-html='pause' @click='changePlayPause' v-else></span> -->
                <span class="play-pause" v-html='changeSvgPlayPause' @click='changePlayPause()'></span>
                <span class="suivant" v-html='suivant'></span>
            </div>
            <div id="progress-bar"></div>
        </div>
    </div>
</template>

<script>
require('webpack-jquery-ui/slider');
require('webpack-jquery-ui/css');
import $ from 'jquery'

export default {
    name: 'LecteurAudio',
    props: {
        source: {
            type: String,
            default: '//www.hochmuth.com/mp3/Haydn_Cello_Concerto_D-1.mp3'
        },
        pochette: {
            type: String,
            default: ''
        },
        titre: {
            type: String,
            default: 'Titre inconnu'
        },
        artiste: {
            type: String,
            default: 'Artiste inconnu'
        },
        album: {
            type: String,
            default: 'Album inconnu'
        }
    },
    data () {
        return {
            laudio_source: this.source,
            laudio_pochette: this.pochette,
            laudio_titre: this.titre,
            laudio_artiste: this.artiste,
            laudio_album: this.album,
            precedent: getSvg('step-backward'),
            suivant: getSvg('step-forward'),
            boolPlay: false,
            intervalProgressBar:'',
            progressBar:''
        }
    },
    methods: {
        changePlayPause() {
            let audio = $('audio')[0];
            if(!isNaN(audio.duration)) {
                $("#progress-bar").slider("option", "max", (+($('audio')[0].duration.toFixed(2))));
            }
            if (audio.duration > 0 && !audio.paused) {
                audio.pause();
                this.boolPlay = false;
                clearInterval(this.intervalProgressBar);
            } else {
                audio.play();
                this.boolPlay = true;
                this.intervalProgressBar = setInterval(() => {
                    let dureeVal = 100 * audio.currentTime / audio.duration;
                    dureeVal = dureeVal.toFixed(2);
                    this.progressBar.slider('value', dureeVal);
                }, 100);
            }
        }
    },
    computed: {
        changeSvgPlayPause() {
            if(this.boolPlay) return getSvg('pause');
            else return getSvg('play');
        }
    },
    mounted() {
        this.$root.$on('changeMusic', (musique) => { // here you need to use the arrow function
            console.log(musique)
            this.laudio_source = musique.url;
            this.laudio_pochette = musique.pochette;
            this.laudio_titre = musique.titre;
            this.laudio_artiste = musique.artiste;
            this.laudio_album = musique.album;
        });

        console.log(+($('audio')[0].duration.toFixed(2)));
        this.progressBar = $("#progress-bar").slider({
            value: 0,
            orientation: "horizontal",
            range: "min",
            animate: "fast",
            step: 0.01,
            min: 0,
            slide: function(event, ui) {
            //     console.log('aaa', ui.value);
            //     // if(!isNaN(ui.value) && $('#progress-bar > span').hasClass('ui-state-active')) {
                    $('audio')[0].currentTime = ui.value;
                    $(event.target).slider('value', ui.value);
            //     // }
            //     // audioObject.currentTime = seconds
            },
            start: function(event, ui) {
                $('.ui-slider-range').addClass('slider-range-active');
                $('audio')[0].pause();
                $('audio')[0].currentTime = ui.value;
                $(event.target).slider('value', ui.value);
                clearInterval(this.intervalProgressBar);
            },
            stop: function(event, ui) {
                // if(!isNaN(ui.value) && $('#progress-bar > span').hasClass('ui-state-active')) {
                    console.log($(event.target));
                    $('audio')[0].currentTime = ui.value;
                    $(event.target).slider('value', ui.value);
                // }
                $('.ui-slider-range').removeClass('slider-range-active');
                $('.play-pause').click();
            }
        });
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    :root {
        --lecteur-audio-height: 85px;
    }

    audio {
        display: none;
    }

    .LecteurAudio {
        width: 100vw;
        height: var(--lecteur-audio-height);
        position: fixed;
        bottom: 0;
        /* background-color: rgba(50, 50, 50, 0.95); */
        background-color: rgba(255, 255, 255, 0.65);
        display: flex;
        /* align-items: center;
        justify-content: space-between; */
        z-index: 2;
    }

    .LecteurAudio * {
        color: rgb(227, 79, 86);
    }

    .picture {
        height: var(--lecteur-audio-height);
        width: var(--menu-width);
    }

    .picture img {
        object-fit: cover;
        width: 100%;
        height: 100%;
    }

    .infos-musiques {
        width: 20vw;
        padding: 10px;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-content: baseline;
        align-items: baseline;
        font-size: 1.5em;
    }

    .infos-musiques > .artiste {
        font-size: 21px;
        font-weight: 300;
    }

    .infos-musiques > .album {
        font-size: 25px;
        font-weight: 800;
    }
    .infos-musiques > .piste {
        font-size: 21px;
        font-weight: 300;
    }
    .infos-musiques * {
        display: block;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        width: 100%;
        height: 100%;
    }

    .lecteur {
        width: calc(100vw - var(--menu-width) - 20vw);
        padding: 20px;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-content: center;
        align-items: center;
    }

    .controls > span {
        margin: 5px;
    }

    .controls svg {
        cursor: pointer;
        transition: all .3s ease-in-out;
    }

    .controls svg * {
        color: rgba(227, 79, 86, 0.8);
    }

    .controls svg:hover * {
        color: rgba(227, 79, 86, 1);
    }

    #progress-bar {
        margin-top: 7px;
        border: 0px solid transparent;
        height: 4px;
        background-color: #535353; /*gris foncé*/
        /* width: 80%; */
        width: 100%;
    }
    #progress-bar:hover .ui-slider-range, .slider-range-active {
        background-color: #1db954 !important; /*vert*/
    }
    #progress-bar * {
        border: 0px solid transparent;
    }
    #progress-bar .ui-slider-handle { /*bouton curseur*/
        border-radius: 50%;
        height: 12px;
        width: 12px;
        box-shadow: 0 2px 4px 0 rgba(0,0,0,.5);
        top: -100%;
        /* opacity: 0;
        transition: opacity .15s ease-in-out; */
    }
    #progress-bar .ui-slider-handle.ui-state-active {
        background: #f6f6f6;
    }
    #progress-bar .ui-slider-handle:focus {
        outline-width: 0px;
    }
    #progress-bar:hover .ui-slider-handle {
        opacity: 1;
    }
    #progress-bar .ui-slider-range {
        background-color: #b3b3b3; /*gris clair*/
    }

</style>
