<template>
    <div class="LecteurAudio">
        <audio controls :src="source"></audio>
    </div>
</template>

<script>
export default {
  name: 'LecteurAudio',
  props: {
      sourceAudio: {
          type: String,
          default: '//www.hochmuth.com/mp3/Haydn_Cello_Concerto_D-1.mp3'
      }
  },
  data () {
    return {
      source: this.sourceAudio
  }
}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    :root {
        --lecteur-audio-height: 85px;
    }

    .LecteurAudio {
        width: 100vw;
        height: var(--lecteur-audio-height);
        position: fixed;
        bottom: 0;
        background-color: rgba(50, 50, 50, 0.95);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 2;
    }
</style>
