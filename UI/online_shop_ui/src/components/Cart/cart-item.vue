<template>
  <v-card >
    <v-layout align-center justify-center>
      <v-flex md2>
        <v-img :aspect-ratio="16/9" src="https://cdn.vuetifyjs.com/images/cards/cooking.png"></v-img>
      </v-flex>
      <v-flex>
          <v-layout column justify-center align-start>
              <flex><v-card-text class="title" align="left">Item Name</v-card-text></flex>
              <flex><v-card-text class="title" align="left">Item Description</v-card-text></flex>
          </v-layout>
        
      </v-flex>
      <v-flex md1>
        <v-card-text class="title" align="center">160$</v-card-text>
      </v-flex>
      <v-flex md1>
        <v-btn icon>
          <v-icon>clear</v-icon>
        </v-btn>
      </v-flex>
    </v-layout>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class CartItem extends Vue {}
</script>
