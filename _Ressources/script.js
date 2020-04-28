(() => {
    let listUrl = document.getElementsByClassName('WYuW0e'),
        listTitle = document.getElementsByClassName('KL4NAf'),
        tab = null;

    function EditTitle(str) {
        //TSFH - Invicible et Archangel
        return str.split(' - ')[2].replace('.mp3', '').replace(' (Choir)','').replace(' (Vocals)','');
    }

    tab = [{
        'nom_album': 'Archangel',
        'pochette': 'https://drive.google.com/uc?id='+listUrl[listUrl.length-1].getAttribute('data-id'),
        'musiques': []
    }];

    for (let i = 0; i < listUrl.length-1; i++) {
        tab[0].musiques.push({
            'url': 'https://drive.google.com/uc?id='+listUrl[i].getAttribute('data-id'),
            'titre': EditTitle(listTitle[i].textContent),
        	'langue': null,
        	'date': '2011-01-01'+'T00:00:00',
        	'editeur': null,
        	'genre': 'Trailer',
        	'artistes': 'Two Steps From Hell',
            'num_piste': i+1
        });
    }

    console.log(JSON.stringify(tab, null, 2));
})();
