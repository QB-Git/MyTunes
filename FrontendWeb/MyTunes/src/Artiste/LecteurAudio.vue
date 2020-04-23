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
<style scoped>
    .LecteurAudio {
        width: 100vw;
        height: 40px;
        position:fixed;
        bottom: 0;
        background-color: #3092B1;
    }
</style>
