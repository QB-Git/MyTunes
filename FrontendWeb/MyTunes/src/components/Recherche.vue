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
        <div class="testGen">

        </div>
        <!-- <span>{{ azer }}</span> -->
    </div>
</template>

<script>
    let musiquesList = {
        'par': {
            'genre': []
        },
        'infos': {}
    };

    async function getResultats() {
        const musiquesListId = _.union(...(_.values(musiquesList.par)));
        for (var idMusique of musiquesListId) {
            // $('.testGen').append(`
            //     ${}
            // `);
            const musiqueCurrent = await API(`musiques/${idMusique}`);
            console.log(
                musiqueCurrent.id_musique,
                musiqueCurrent.url,
                musiqueCurrent.langue,
                musiqueCurrent.pochette.img_pochette,
                musiqueCurrent.date,
                (musiqueCurrent.editeur != null) ? musiqueCurrent.editeur.nom_editeur : null
            )
            console.log(musiqueCurrent);
        }
        return;
    }

    async function loadPage() {
        const genres = await API('genres', function(json) {
            return json.map(
                obj => {
                    return {
                        "name" : obj.genre,
                        "value": obj.id_genre,
                        "text": obj.genre
                    }
                }
            ).sort(function(obj1, obj2) {
                return obj1.name.localeCompare(obj2.name);
            });
        });

        //console.log(genres);

        $('.ui.dropdown').dropdown({
            // useLabels: false,
            values: genres,
            placeholder: 'Genres',
            onChange: async function (idListGenres) {
                musiquesList.par.genre = [];
                idListGenres = idListGenres.split(',');
                for (var idGenre of idListGenres) {
                    const genreCurrent = await API(`genres/${idGenre}`);
                    const musiquesGenre = genreCurrent.musiques;
                    for (var musique of musiquesGenre) {
                        musiquesList.par.genre.push(musique.id_musique);
                    }
                }
                getResultats();
                console.log(musiquesList)
            }
            // onAdd: async function (id) {
            //     const genreCurrent = await API(`genres/${id}`);
            //     const musiquesGenre = genreCurrent.musiques;
            //     for (var musique of musiquesGenre) {
            //         musiquesList.par.genre.push(musique.id_musique);
            //         console.log(musique.id_musique);
            //     }
            // },
            // onRemove: async function (id) {
            //     const genreCurrent = await API(`genres/${id}`);
            //     const musiquesGenre = genreCurrent.musiques;
            //     for (var musique of musiquesGenre) {
            //         _.without(musiquesList.par.genre, musique.id_musique);
            //         console.log(musique.id_musique);
            //     }
            // }
        });
    }

    export default {
        // data: {
        //     azer: "valeur de azer"
        // },
        mounted() {
            loadPage();
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    .ui.segment {
        width: 80%;
    }
</style>
