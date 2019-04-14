<template>
  <v-container>
      <!-- <v-layout row wrap justify-space-around align-center fill-height>
          <v-flex ma-2>
              <single-item></single-item>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
      </v-layout>
      <v-layout row wrap justify-space-around align-center fill-height>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
      </v-layout>
      <v-layout row wrap justify-space-around align-center fill-height>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
          <v-flex ma-2>
              <SingleItem></SingleItem>
          </v-flex>
      </v-layout> -->

          <!-- <SingleItemWindow></SingleItemWindow>   -->

    <!-- <Cart/> -->

    <LoginPage/>
    
    <!-- <Order/> -->
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SingleItem from "./single-item.vue";
import SingleItemWindow from './SingleItemWindow.vue';
import Cart from '@/components/Cart/Cart.vue';
import LoginPage from '@/components/User/LoginPage.vue';
import Order from '@/components/Order/Order.vue';

@Component({
  components: {
    SingleItem,
    SingleItemWindow,
    Cart,
    LoginPage,
    Order
  }
})
export default class ItemsWindow extends Vue {}
</script>
