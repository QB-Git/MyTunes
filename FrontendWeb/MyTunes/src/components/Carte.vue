<template>
    <div class="card">
        <div class="pochette" @click="changerLaMusique">
            <img :src="carte_source">
            <my-icon class="imgPlayMusic" :nomSvg="'play'"/>
        </div>
        <div class="content">
            <div class="header">{{ carte_titre }}</div>
            <div class="meta">{{ carte_artiste }}</div>
        </div>
    </div>
</template>

<script>
    import MyIcon from '@/components/MyIcon'

    export default {
        name: 'Carte',
        components: {
            MyIcon
        },
        props: {
            source: {
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
                default: ''
            },
            url: {
                type: String,
                default: ''
            }
        },
        data () {
            return {
                carte_source: this.source,
                carte_titre: this.titre,
                carte_artiste: this.artiste,
                carte_album: this.album,
                carte_url: this.url
            }
        },
        methods: {
            changerLaMusique () {
                this.$root.$emit('changeMusic', {
                    url: this.carte_url,
                    pochette: this.carte_source,
                    titre: this.carte_titre,
                    artiste: this.carte_artiste,
                    album: this.carte_album
                });
            }
        }
    }
</script>

<style>
.card {
    width: 180px !important;
    margin: 15px;
    background-color: rgba(5,5,5,0.3);
    color: white;
    display:flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    border-radius: 5px;
    padding-top: 15px;
}

.pochette {
    display: flex;
    justify-content: center;
    width: 100%;
    align-items: center;
    flex-direction: column;
    align-content: center;
}

.pochette > span {
    position: absolute;
    opacity: 0;
    transition: all .3s ease-in-out;
}

.pochette:hover > span {
    opacity: 0.6;
}

.pochette > span svg {
    height: 100px;
    cursor: pointer;
}

.pochette > img {
	width: auto;
	height: 150px;
	border-radius: 3px;
}

.content {
    padding: 10px 2px;
    width: 80%;
}
</style>
