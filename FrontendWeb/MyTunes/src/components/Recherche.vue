<template>
    <div>
        <h1 class="ui header">Recherche</h1>
        <div class="ui segment raised">
            <div class="ui fluid multiple search selection dropdown">
                <input name="tags" type="hidden" value="">
                <i class="dropdown icon"></i>
                <div class="default text">Genres</div>
                <div class="menu"></div>
            </div>
            </select>
        </div>
        <!-- <Carte :source="'https://1.bp.blogspot.com/-ymEujbrEdWg/T6QavBSluLI/AAAAAAAAIUI/1WB0MJjRVsw/s1600/CarreRouge-Image-INFOSuroit_com_.jpg'" :titre="'test'" :artiste="'test'"/>
        {{ test }}
        {{ musiques }} -->
        <div class="testGen">
            <Carte
                v-for="musique in musiques"
                :source="musique.pochette"
                :titre="musique.titre"
                :artiste="musique.artiste"
                :album="musique.album"
                :url="musique.url"
            />
        </div>
    </div>
</template>

<script>
    import Carte from '@/components/Carte'

    export default {
        components: {
            Carte
        },
        data () {
            return {
                musiques: [],
                musiquesList: {
                    'par': {
                        'genre': []
                    },
                    'infos': {}
                }
            }
        },
        methods: {
            getMusiques () {
                const musiquesListId = _.union(this.musiquesList.par.genre);
                this.musiques = [];
                for (var idMusique of musiquesListId) {
                    this.$http.get(`${API}musiques/${idMusique}`).then((res) => {
                        let musiqueCurrent = res.data;
                        let strArtistes = '';
                        for(const artiste of musiqueCurrent.artistes) {
                            const nomArtiste = artiste.artiste.nom ? artiste.artiste.nom : '';
                            const prenomArtiste = artiste.artiste.prenom ? artiste.artiste.prenom : '';
                            strArtiste = nomArtiste + ' ' + prenomArtiste;
                            strArtiste = strArtiste.trim();
                            strArtiste += ', ';
                        }
                        let strArtiste = strArtiste.slice(0, -2);
                        console.log(musiqueCurrent.url)
                        this.musiques.push({
                            'pochette': musiqueCurrent.pochette.img_pochette,
                            'titre': musiqueCurrent.titre,
                            'artiste': strArtiste,
                            'album': musiqueCurrent.albums[0].album.nom_album,
                            'url': musiqueCurrent.url
                        });
                    }, (res) => {
                        console.log('erreur', res)
                    });
                }
            }
        },
        mounted() {
            this.$http.get(`${API}genres`).then((res) => {
                const genres = res.data.map(
                    obj => {
                        return {
                            "name" : obj.genre,
                            "value": obj.id_genre,
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
                    onChange: (idListGenres) => {
                        this.musiquesList.par.genre = [];
                        if(idListGenres === "") {
                            this.getMusiques();
                        } else {
                            idListGenres = idListGenres.split(',')
                            for (const [index, idGenre] of idListGenres.entries()) {
                                this.$http.get(`${API}genres/${idGenre}`).then((res) => {
                                    for (var musique of res.data.musiques) {
                                        this.musiquesList.par.genre.push(musique.id_musique);
                                    }
                                    if(index == idListGenres.length-1) {
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
    }

    .testGen {
    	display: flex;
    	width: 100%;
    	flex-wrap: wrap;
    	justify-content: space-around;
    }
</style>
