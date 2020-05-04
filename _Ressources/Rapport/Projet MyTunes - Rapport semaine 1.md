# Projet MyTunes - Rapport semaine 1


Durant cette première semaine, nous avons amorcés plusieurs points importants.

Tout d'abord, nous avons établi un diagramme de Gantt, nous permettant de planifier le déroulement du projet sur la durée. Celui-ci sera peut-être sujet à des modifications par la suite.



### Base de données

Dans un second temps, nous avons réfléchi aux fonctionnalités nécessaires à cette application. De cela a découlé une première version de la base de données :

![](https://cdn.discordapp.com/attachments/697064565787197480/697468492080873542/unknown.png)



### Gestion des métadonnées (tags ID3) et des utilisateurs

Nous avons également réfléchi aux différentes possibilités concernant l'origine de la musique. Nous avons établi trois cas possibles :
- (1) Les fichiers uploadés par les administrateurs (nous) qui seront globaux à l'ensemble des utilisateurs.


- (2) Des fichiers uploadés par les utilisateurs eux-mêmes et qui seront accessibles par eux-mêmes uniquement ou à l'ensemble des utilisateurs (choix de l'utilisateur).
- (3) Les fichiers locaux de l'utilisateur (sur mobile uniquement) 

Et c'est seulement dans les cas 2 et 3 que l'utilisateur peut avoir le droit de modifier les tags. Les tags des fichiers uploadés par les administrateurs sont modifiables par eux et eux seuls.

Ces tags sont assez importants : nous allons considérer que dans les cas 1 et 2, les métadonnées des fichiers sont uploadés comme informations au sein de la base de données et c'est cette base de données qui sera manipulé et non plus les métadonnées en elles-même. Dans le cas 3, quand l'utilisateur modifiera un tag ce sera les métadonnées du fichier.



### Structure du projet et technologies choisies

Nous avons choisi pour ce projet de partir sur le principe suivant :
- 1 Base de données (SQL Server)

- 1 WebAPI gérant tout l'aspect backend de ce projet (ASP.NET Core API)

  ![](https://cdn.discordapp.com/attachments/697064565787197480/698147535885434880/unknown.png)

- 2 Frontends :
  - Web (JS, HTML, CSS, ...)
  - Mobile (Android)

Il sera toutefois peut-être nécessaire de mettre un léger backend intermédiaire au web ou au mobile pour servir d'intermédiaire.



### La situation actuelle

Nous avons pu construire une structure de base pour l'API qui fonctionne correctement. Il faudrait rajouter tous les modèles et les contrôleurs pour la base de données, et la connexion à cette dernière.

Nous avons effectué quelques tests d'extraction de métadonnées en javascript plutôt concluant.

Nous avons commencé à réfléchir à une maquette de la version Web de notre application : apparence, pages nécessaires, framework, plugins, ...

Nous recherchons actuellement des solutions pour nous permettre d'héberger l'API et la base de données. Pour ceux-ci, nous avons vu que Azure proposait des services pouvant correspondre à ces besoins, mais nous n'avons pas encore mis cela en place.

Nous recherchons également un moyen d'héberger nos fichiers (mp3 et images) dans un serveur web disposant d'une API permettant au minimum :

- La mise en ligne d'un fichier.
- Le téléchargement d'un fichier.
- La suppression d'un fichier.
- La possibilité d'obtenir un lien direct vers le fichier (si on suit ce lien on arrive directement sur le fichier et non sur une page avec interface affichant le fichier).



