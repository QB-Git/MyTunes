import Vue from 'vue'
import Router from 'vue-router'
import Accueil from '@/components/Accueil'
import Recherche from '@/components/Recherche'
import MesPlaylists from '@/components/MesPlaylists'
import Connexion from '@/components/Connexion'

Vue.use(Router)

const router = new Router({
    mode: 'history',
    routes: [{
            path: '/',
            name: 'Accueil',
            component: Accueil,
            meta: {title: 'MyTunes'}
        }, {
            path: '/recherche',
            name: 'Recherche',
            component: Recherche,
            meta: {title: 'MyTunes - Recherche'}
        }, {
            path: '/connexion',
            name: 'Connexion',
            component: Connexion,
            meta: {title: 'MyTunes - Connexion'}
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
