<template>
  <v-container>
    <v-layout column>
      <v-flex ma-1>
        <CartItem/>
      </v-flex>
      <v-flex ma-1>
        <CartItem/>
      </v-flex>
      <v-flex ma-1>
        <CartItem/>
      </v-flex>
      <v-flex ma-1>
        <CartItem/>
      </v-flex>
      <v-flex ma-1>
        <CartItem/>
      </v-flex>
      <v-flex ma-1>
        <v-layout row justify-end align-center>
          <v-flex md3>
            <v-btn block class="success">Buy All</v-btn>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CartItem from "./cart-item.vue";

@Component({
  components: { CartItem }
})
export default class Cart extends Vue {}
</script>
