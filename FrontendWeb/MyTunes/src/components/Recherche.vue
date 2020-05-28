<template>
    <div>
        <h1 class="ui header">Recherche</h1>
        
        <!-- <span>{{chargement}}</span> -->
        <div class="ui segment raised">
            <div class="ui fluid multiple search selection dropdown">
                <input name="tags" type="hidden" value="">
                <i class="dropdown icon"></i>
                <div class="default text">Genres</div>
                <div class="menu"></div>
            </div>
            </select>
        </div>
        <span id="loader" v-if="chargement == 1">
            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" style="margin:auto; display:block;" width="200px" height="200px" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid">
                <circle cx="50" cy="50" fill="none" stroke="#e15b64" stroke-width="8" r="33" stroke-dasharray="155.50883635269477 53.83627878423159">
                    <animateTransform attributeName="transform" type="rotate" repeatCount="indefinite" dur="1.25s" values="0 50 50;360 50 50" keyTimes="0;1"></animateTransform>
                </circle>
            </svg>
        </span>
        <div class="testGen" v-if="chargement == 2">
            <Carte
                v-for="(musique, x) in musiques" :key="x"
                :source="musique.pochette"
                :titre="musique.titre"
                :artiste="musique.artiste"
                :album="musique.album"
                :url="musique.url"
            />
        </div>
        <span v-if="chargement == 3">Pas de musiques disponibles pour cette recherche ...</span>

    </div>
</template>

<script>
    import Carte from '@/components/Carte'

    function getArtistes(musique) {
        let strArtiste = '';
        for(const artiste of musique.artistes) {
            const nomArtiste = artiste.artiste.nom ? artiste.artiste.nom : '';
            const prenomArtiste = artiste.artiste.prenom ? artiste.artiste.prenom : '';
            let strArtisteTmp = nomArtiste + ' ' + prenomArtiste;
            strArtiste += strArtisteTmp.trim()+', ';
        }
        return strArtiste.trim().slice(0, -1);
    }

    function getAlbums(musiqueCurrent) {
        let strAlbum = '';
        // for(const album of musiqueCurrent.albums) {
        //     const nomArtiste = artiste.artiste.nom ? artiste.artiste.nom : '';
        //     const prenomArtiste = artiste.artiste.prenom ? artiste.artiste.prenom : '';
        //     let strArtisteTmp = nomArtiste + ' ' + prenomArtiste;
        //     strArtiste += strArtisteTmp.trim()+', ';
        // }
        // return strArtiste.trim().slice(0, -1);
        return '';
    }

    export default {
        components: {
            Carte
        },
        data () {
            return {
                musiques: [],
                musiquesList: {
                    'par_genre': {}
                },
                chargement: 0
            }
        },
        methods: {
            getMusiques () {
                //Si 0 musique pour les genres sélectionnés

                if(_.isEmpty(JSON.parse(JSON.stringify(this.musiquesList.par_genre)))) {
                // Si 0 musique pour les genres sélectionnés
                    this.chargement = 3 //message d'info
                } else {
                    const musiquesList = _.values(this.musiquesList.par_genre);
                    console.log(musiquesList)
                    this.musiques = [];
                    for (const musique of musiquesList) {
                        this.musiques.push(musique)
                    }
                    console.log(this.musiques.length)
                    //if(this.musiques.length != 0) {
                        this.chargement = 2 //afficher cartes
                    //    console.log('chargement', chargement)
                    //}
                }

                // if()
                //     || this.musiques.length == 0) {
                //     this.chargement = 0
                // } else {
                //
                // }

            }
        },
        mounted() {
            this.$http.get(`${API}genres`).then((res) => {
                const genres = res.data.map(
                    obj => {
                        return {
                            "name" : obj.genre,
                            "value": obj.genre, //obj.id_genre,
                            "text": obj.genre
                        }
                    }
                ).sort((obj1, obj2) => {
                    return obj1.name.localeCompare(obj2.name);
                });

                $('.ui.dropdown').dropdown({
                    // useLabels: false,
                    values: genres,
                    placeholder: 'Genres',
                    onChange: (listGenres) => {
                        this.chargement = 1 //loader
                        // var x = setTimeout(() => { }, 5000);
                        // clearTimeout(x);
                        this.musiquesList.par_genre = {}
                        if(listGenres.length == 0) { //si 0 genre sélectionné
                            this.chargement = 0 // on affiche rien
                            //this.getMusiques()
                        } else {
                            listGenres = listGenres.split(',')
                            for (const [index, genre] of listGenres.entries()) {
                                this.$http.get(`${API}Musiques/recherche/genre/${genre}`).then((res) => {
                                    for (var musique of res.data) {
                                        this.musiquesList.par_genre[musique.id_musique] = {
                                            pochette: musique.pochette.img_pochette,
                                            titre: musique.titre,
                                            artiste: getArtistes(musique),
                                            album: getAlbums(musique),
                                            url: musique.url
                                        };
                                    }
                                    if(index == listGenres.length-1) {
                                        this.getMusiques();
                                    }
                                }, (res) => {
                                    console.log('erreur', res)
                                });
                            }
                        }
                    }
                });
            }, (res) => {
                console.log('erreur', res)
            });
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    .ui.segment {
        width: 80%;
        z-index: 5;
    }

    .testGen {
    	display: flex;
    	width: 100%;
    	flex-wrap: wrap;
    	justify-content: space-around;
    }

    #loader {
        margin-top:110px
    }
</style>
