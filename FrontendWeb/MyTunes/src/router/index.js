import Vue from 'vue'
import Router from 'vue-router'
import Accueil from '@/components/Accueil'
import Profil from '@/components/Profil'
import Recherche from '@/components/Recherche'
import MesPlaylists from '@/components/MesPlaylists'



// import HelloWorld from '@/components/HelloWorld'
// import Menu from '@/components/Menu'
// import PageA from '@/components/PageA'
// import PageC from '@/components/PageC'
// import Accueil from '@/components/Accueil'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            name: 'Accueil',
            component: Accueil
        }, {
            path: '/profil',
            name: 'Profil',
            component: Profil
        }, {
            path: '/recherche',
            name: 'Recherche',
            component: Recherche
        }, {
            path: '/mes-playlists',
            name: 'Mes playlists',
            component: MesPlaylists
        }, /*{
            path: '/article/:id(\\d+)',
            name: 'PageA',
            //component: PageA
            components: {
                default: PageA,
                sidebar: PageC
            }
        },*/ {
            path: '*',
            redirect: '/'
        }
    ]
})
