var filePickerEl = document.querySelector('.file-picker-box')
var filePickerInputEl = filePickerEl.querySelector('input')
var mediaPlayerEl = document.querySelector('.music-player')
var mediaTitleEl = document.querySelector('.media-title')
var mediaArtistEl = document.querySelector('.media-artist')
var mediaPlayButtonEl = document.querySelector('.play-button')
var mediaTotalDurationEl = document.querySelector('.media-time > .end')
var mediaCurrentTimeEl = document.querySelector('.media-time > .current')
var coverArtEl = document.querySelector('.cover-art');
var mediaVisualizerEl = document.querySelector('.media-visualizer')
var progressBarEl = document.querySelector('.progress-bar')

var currentFile

var audioSrcEl = new Audio(),
    audioSrc,
    audioCtx,
    frequencyData,
    analyser

audioCtx = new (window.AudioContext || window.webkitAudioContext)()
analyser = audioCtx.createAnalyser()
analyser.fftSize = 1024

audioSrc = audioCtx.createMediaElementSource(audioSrcEl)
audioSrc.connect(analyser)
analyser.connect(audioCtx.destination);

frequencyData = new Uint8Array(analyser.frequencyBinCount);

filePickerInputEl.addEventListener('change', e => {
    currentFile = e.target.files[0]
    setPlayButtonStatus('pause')
    audioSrcEl.src = URL.createObjectURL(currentFile)
    audioSrcEl.volume = .15
    audioSrcEl.load()
    updateAudioTags()
})

filePickerEl.addEventListener('click', e => {
    audioCtx.resume()
    filePickerInputEl.click()
})

audioSrcEl.addEventListener('timeupdate', () =>
{
    updateUI()
})

audioSrcEl.addEventListener('play', () => {
    setPlayButtonStatus('play')
})

audioSrcEl.addEventListener('pause', () => {
    setPlayButtonStatus('pause')
})

progressBarEl.addEventListener('input', () =>
{
    audioSrcEl.currentTime = progressBarEl.value
})

mediaPlayButtonEl.addEventListener('click', () => {
    audioSrcEl.paused ? audioSrcEl.play() : audioSrcEl.pause()
})


function updateAudioTags ()
{
    jsmediatags.read(currentFile,
    {
        onSuccess (info)
        {
            if (info.tags.picture)
            {
                var base64String = '';

                for (var i = 0; i < info.tags.picture.data.length; i++)
                {
                    base64String += String.fromCharCode(info.tags.picture.data[i]);
                }

                var imageUri = "data:" + info.tags.picture.format + ";base64," + window.btoa(base64String)

                coverArtEl.style.backgroundImage = `url("${imageUri}")`
            }

            mediaTitleEl.innerHTML = info.tags.title
            mediaArtistEl.innerHTML = info.tags.artist
            progressBarEl.min = 0
            progressBarEl.max = audioSrcEl.duration
            audioSrcEl.currentTime = 0

            updateUI()
        },

        onError (err)
        {
            console.error(err)
        }
    })
}



function animStep()
{
    analyser.getByteFrequencyData(frequencyData)

    document.querySelectorAll('.media-visualizer > .bar').forEach((e, i) =>
    {
        e.style.height = frequencyData[i*32] / 255 * 100 + '%'
    })

    mediaPlayerEl.style.transform = `scale(${(frequencyData[0] / 255) * .34 + 1})`

    window.requestAnimationFrame(animStep)
}

window.requestAnimationFrame(animStep)



function secToMin (sec)
{
    sec = Math.floor(sec)

    return(sec-(sec%=60))/60+(9<sec?':':':0')+sec
}

function updateUI ()
{
    progressBarEl.value = audioSrcEl.currentTime
    mediaCurrentTimeEl.innerHTML = secToMin(audioSrcEl.currentTime)
    mediaTotalDurationEl.innerHTML = secToMin(audioSrcEl.duration)
}

function setPlayButtonStatus (status)
{
    if (status == 'pause') {
        mediaPlayButtonEl.querySelector('i').classList.remove('ion-ios-pause')
        mediaPlayButtonEl.querySelector('i').classList.add('ion-ios-play')
    }

    if (status == 'play') {
        mediaPlayButtonEl.querySelector('i').classList.remove('ion-ios-play')
        mediaPlayButtonEl.querySelector('i').classList.add('ion-ios-pause')
    }
}
