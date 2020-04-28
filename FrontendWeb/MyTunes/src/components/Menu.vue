<template>
    <div class="ui vertical icon menu">
        <router-link to="/">
            <a class="item logo" v-html='logo'></a>
        </router-link>
        <router-link to="/profil">
            <a class="item" v-html='user'></a>
        </router-link>
        <router-link to="./recherche">
            <a class="item" v-html='search'></a>
        </router-link>
        <router-link to="./mes-playlists">
            <a class="item" v-html='music'></a>
        </router-link>
    </div>
</template>

<script>
import '../../src/js/myicon.js'

export default {
    name: 'Menu',
    data () {
        return {
            logo: getSvg('logo'),
            user: getSvg('user')+'<span>Profil</span>',
            search: getSvg('search')+'<span>Chercher</span>',
            music: getSvg('music')+'<span>Mes playlists</span>'
        }
    }/*,
    mounted: function() {
        SvgReplaceAll() ;
    }*/
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    :root {
        --menu-width: 80px;
    }

    @import "https://fonts.googleapis.com/css?family=Asap";

    @keyframes ld-jingle {
    	0% {
    		animation-timing-function: cubic-bezier(0.146, 0.2111, 0.5902, 1.3204);
    		transform: rotate(0)
    	}
    	11% {
    		animation-timing-function: cubic-bezier(0.1079, 0.1992, -0.6462, 0.828);
    		transform: rotate(7.61deg)
    	}
    	23% {
    		animation-timing-function: cubic-bezier(0.0504, 0.0951, 0.0163, 0.9677);
    		transform: rotate(-5.789999999999999deg)
    	}
    	36% {
    		animation-timing-function: cubic-bezier(0.0475, 0.0921, 0.3134, 1.0455);
    		transform: rotate(3.35deg)
    	}
    	49% {
    		animation-timing-function: cubic-bezier(0.0789, 0.1565, 0.3413, 1.0972);
    		transform: rotate(-1.9300000000000002deg)
    	}
    	62% {
    		animation-timing-function: cubic-bezier(0.141, 0.2885, 0.406, 1.1519);
    		transform: rotate(1.12deg)
    	}
    	75% {
    		animation-timing-function: cubic-bezier(0.226, 0.4698, 0.5031, 1.1722);
    		transform: rotate(-0.64deg)
    	}
    	88% {
    		animation-timing-function: cubic-bezier(0.3121, 0.5521, 0.5655, 0.8997);
    		transform: rotate(0.37deg)
    	}
    	100% {
    		transform: rotate(-0.28deg)
    	}
    }

    [class*='myicon'] {
        height: 2em;
    }
    .ui.vertical.icon.menu {
        position: fixed;
        top: 0;
        height: 100vh;
        height: calc(100vh - var(--lecteur-audio-height));
        margin: 0;
        width: var(--menu-width);
        background: rgba(255, 255, 255, 0.1);
        border-radius: 0;
        border-width: 0;
    }
    .ui.icon.menu .item {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        /* height: 5em; */
    }
    .ui.icon.menu .item svg {
        font-size: 1.1em;
        overflow: visible;
    }
    .ui.icon.menu .item:hover svg{
        animation:ld-jingle 1s linear infinite;
    }
    .ui.icon.menu .item svg path {
        fill: white;
    }
    .ui.icon.menu .item span {
        padding-top: 10px;
        font-size: 1.1em;
        font-weight: 600;
        font-family: 'Asap', sans-serif;
        color: white;
        line-height: 1.2;
    }
    .ui.icon.menu .item.logo {
        padding: 0;
        background: rgba(0, 0, 0, 0.1);
        height: 75px;
    }
    .ui.icon.menu .item {
        line-height: 1.5;
    }
    .ui.icon.menu .item svg.myicon-logo {
        width: 100%;
        height: min-content;
        padding: 10px;
        cursor: pointer;
    }
    .ui.icon.menu .item svg.myicon-logo path {
        fill: rgb(255, 127, 80);
    }
</style>
