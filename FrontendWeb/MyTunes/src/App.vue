<template>
    <div id="app">
        <div class="main">
            <Menu/>
            <div class="content">
                <router-view />
            </div>
        </div>
        <!-- <lecteur-audio :sourceAudio="'//drive.google.com/uc?id=1QzqtWXki3yJdS2n6z8kLwvHDZYPogZTL'"/> -->
        <lecteur-audio/>

    </div>
</template>

<script>
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

/* svg[class*='myicon'] {
    height: 1em;
} */
#app {

}

.main {
    background-color: rgba(250,250,250,1);
    display: flex;
}

.content {
    padding-bottom: 100px;
}

p {
    color: rgba(3,169,244,1);
}
</style>
