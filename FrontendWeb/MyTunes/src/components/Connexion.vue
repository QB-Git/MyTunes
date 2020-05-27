<template>
    <div class="connexion-form">
        <h1 class="ui header">Connexion</h1>
        <p>{{ $route.params.id }}</p>
        <div class="ui middle aligned center aligned grid form">
            <div class="column">
                <div class="ui large form">
                    <div class="ui stacked segment">
                        <div class="field">
                            <div class="ui left icon input">
                                <i class="icon form-icon"><my-icon :nomSvg="'user'"/></i>
                                <input type="text" name="pseudo" placeholder="Pseudo">
                            </div>
                        </div>
                        <div class="field">
                            <div class="ui left icon input">
                                <i class="icon form-icon"><my-icon :nomSvg="'lock'"/></i>
                                <input type="password" name="mdp" placeholder="Mot de passe">
                            </div>
                        </div>
                        <div class="ui fluid large teal submit button">Login</div>
                    </div>
                    <div class="ui error message"></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import MyIcon from '@/components/MyIcon'

    export default {
        name: 'Connexion',
        components: {
            MyIcon
        },
        props: {

        },
        data () {
            return {
            }
        },
        methods: {

        },
        mounted() {
            $('.connexion-form > div').form({
                fields: {
                    pseudo: {
                        identifier  : 'pseudo',
                        rules: [{
                            type   : 'empty',
                            prompt : `Pas de pseudo saisi`
                        }]
                    },
                    mdp: {
                        identifier  : 'mdp',
                        rules: [{
                            type   : 'empty',
                            prompt : 'Pas de mot de passe saisi'
                        }]
                    }
                },
                onSuccess: (event, fields) => {
                    event.preventDefault();
                    event.stopImmediatePropagation();
                    this.$http.get(`${API}users/recherche/${fields.pseudo}`).then((res) => {
                        if (res.data.length == 0) {
                            $('.ui.error.message').show().html('Pseudo inexistant');
                        } else if (res.data[0].password.localeCompare(fields.mdp) == 0) {
                            $cookies.set('user', res.data[0].pseudo)
                            this.$router.push('/')
                            this.$router.go(0)
                        } else {
                            $('.ui.error.message').show().html('Mot de passe incorrect');
                        }
                        console.log(res.data);
                    }, (res) => {
                        console.log('erreur', res)
                    });
                    console.log(fields.pseudo, fields.mdp);
                }
            });
        }
    }
</script>

<style>
    .connexion-form .grid {
        height: 100%;
    }
    .connexion-form .image {
        margin-top: -100px;
    }
    .connexion-form .column {
        max-width: 450px;
    }
    .connexion-form i.icon {
    	z-index: 2;
    	display: flex;
    	align-items: center;
    	justify-content: center;
    }
    .connexion-form .form-icon > span > svg {
        height: 20px !important;
    }
</style>
