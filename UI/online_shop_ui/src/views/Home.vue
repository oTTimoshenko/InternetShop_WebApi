<template>
  <div class="home">
    <ItemsWindow />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import ItemsWindow from '@/components/Items/ItemsWindow.vue'

@Component({
  components: {
    ItemsWindow
  }
})
export default class Home extends Vue {}
</script>
