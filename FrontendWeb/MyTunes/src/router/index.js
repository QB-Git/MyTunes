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

const router = new Router({
    mode: 'history',
    routes: [{
            path: '/',
            name: 'Accueil',
            component: Accueil,
            meta: {title: 'MyTunes'}
        }, {
            path: '/profil',
            name: 'Profil',
            component: Profil,
            meta: {title: 'MyTunes - Profil'}
        }, {
            path: '/recherche',
            name: 'Recherche',
            component: Recherche,
            meta: {title: 'MyTunes - Recherche'}
        }, {
            path: '/mes-playlists',
            name: 'Mes playlists',
            component: MesPlaylists,
            meta: {title: 'MyTunes - Mes Playlists'}
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
 });

const DEFAULT_TITLE = 'MyTunes';
router.afterEach((to, from) => {
    // Use next tick to handle router history correctly
    // see: https://github.com/vuejs/vue-router/issues/914#issuecomment-384477609
    Vue.nextTick(() => {
        document.title = to.meta.title || DEFAULT_TITLE;
    });
});

export default router;
