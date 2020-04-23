#!/bin/bash


# En principe, $1 doit être égal à 'genre.txt' 
# que je fournis à côté
if [ -z $1 ]; then
	echo "Pas de fichier à traiter"
	exit
fi


# Les noms de la table et des champs sont arbitraires
# A vous d'adapter...
n=1
while read -r line; do
	echo -e "INSERT INTO \`Genre\` (\`id_genre\`, \`lib_genre\`) VALUE ($n,'${line%?}');"
	n=$(( $n + 1 ))
done < $1
