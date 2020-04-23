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
    @import "https://fonts.googleapis.com/css?family=Asap";

    [class*='myicon'] {
        height: 2em;
    }
    .ui.vertical.icon.menu {
        position: sticky;
        top: 0;
        height: 100vh;
        margin: 0;
        width: 80px;
        background: #7386D5;
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
        background: #6d7fcc;
    }
    .ui.icon.menu .item {
        line-height: 1.5;
    }
    .ui.icon.menu .item svg.myicon-logo {
        width: 100%;
        height: auto;
        padding: 10px;
        cursor: pointer;
    }
    .ui.icon.menu .item svg.myicon-logo path {
        fill: rgb(255, 127, 80);
    }
</style>
