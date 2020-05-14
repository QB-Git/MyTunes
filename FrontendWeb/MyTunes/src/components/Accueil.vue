<template>
    <div>
        <br>
        <h1 class="ui header">Écoutez gratuitement les dernières tendances MyTunes</h1>
        <div class="ui four column grid cards-container">
            <div class="col" v-for="(item, x) in dataContent" :key="x">
                <div class="card">
                    <img v-bind:src="item.img">
                    <div class="content">
                        <div class="header">{{item.musique}}</div>
                        <div class="meta">{{item.artiste}}</div>
                    </div>
                </div>
            </div>
        </div>
        <br>
    </div>
</template>

<script>
    function resize() {
        if ($(window).width() < 1095) {
            $('.col').removeClass('column');
        } else $('.col').addClass('column');
    }
    $(() => { resize(); });

    $(window).resize(() => { resize(); });

    export default {
        data() {
                return {
                  dataContent: [
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique1', artiste: 'Artiste1'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique2', artiste: 'Artiste2'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique3', artiste: 'Artiste3'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique4', artiste: 'Artiste4'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique5', artiste: 'Artiste5'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique6', artiste: 'Artiste6'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique7', artiste: 'Artiste7'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique8', artiste: 'Artiste8'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique9', artiste: 'Artiste9'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique10', artiste: 'Artiste10'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique11', artiste: 'Artiste11'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique12', artiste: 'Artiste12'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique13', artiste: 'Artiste13'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique14', artiste: 'Artiste14'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique15', artiste: 'Artiste15'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique16', artiste: 'Artiste16'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique17', artiste: 'Artiste17'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique18', artiste: 'Artiste18'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique19', artiste: 'Artiste19'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique20', artiste: 'Artiste20'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique21', artiste: 'Artiste21'},
                   {img: 'https://semantic-ui.com/examples/assets/images/wireframe/image.png', musique: 'Musique22', artiste: 'Artiste22'},
                   {img: 'https://interactive-examples.mdn.mozilla.net/media/examples/plumeria.jpg', musique: 'Musique23', artiste: 'Artiste23'}
                  ]
                }
        },
        mounted () {

            // axios.get('https://mytunes20200429155409.azurewebsites.net/api/Genres')
            //     .then(function (response) {
            //
            // 		console.log(response.data[0].id_genre, response.data[0].genre, response.data[0].musiques);
            // 		console.log('response is : ' + response.data);
            // 	}).catch(function (error) {
            //         if (error.response) console.log(error.response.headers);
            //         else if (error.request) console.log(error.request);
            //         else console.log(error.message);
            //         console.log(error.config);
            // });
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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
    }

    .card img {
        width: 80%;
        height: 150px;
        object-fit: cover;
        object-position: center;
        border-radius: 3px;
        margin-top: 15px;
    }

    .card .content {
        padding: 10px 2px;
        width: 80%;
    }



    .cards-container > .column {
        display: flex !important;
        justify-content: center !important;
    }

    @media (max-width: 1095px) {
        .cards-container {
            justify-content: space-around !important;
        }
    }

    @media (min-width: 1600px) {
        .ui.cards-container {
            margin: 0 20%;
        }
    }

    @media (min-width:1095px) and (max-width:1600px) {
        .ui.cards-container {
            margin: 0 10%;
        }
    }
</style>
