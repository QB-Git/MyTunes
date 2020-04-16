function getPage(page, nbFois = 1, idBalise = "#contentPage") {
  if(nbFois > 1) {
    for (var i = 0; i < nbFois; i++) {
      $(idBalise).append($('<div>').load(page));
    }
  }
  else $(idBalise).load(page);
}

$(() => {
  //getPage("b.html");

  // $('#sidebarCollapse').on('click', function () {
  //     $('#sidebar').toggleClass('active');
  // });

  $('body').overlayScrollbars({ });
  $('.aaa').overlayScrollbars({ });
  // Amplitude.init({
  //   "songs": [
  //     {
  //       "name": "Song Name 1",
  //       "artist": "Artist Name",
  //       "album": "Album Name",
  //       "url": "audio.mp3",
  //       "cover_art_url": "./ressources/music_girl.png"
  //     },
  //     {
  //       "name": "Song Name 2",
  //       "artist": "Artist Name",
  //       "album": "Album Name",
  //       "url": "audio.mp3",
  //       "cover_art_url": "./ressources/music_girl.png"
  //     },
  //     {
  //       "name": "Song Name 3",
  //       "artist": "Artist Name",
  //       "album": "Album Name",
  //       "url": "audio.mp3",
  //       "cover_art_url": "./ressources/music_girl.png"
  //     }
  //   ]
  // });

});
