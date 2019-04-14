<template>
  <v-container>
    <v-card>
      <v-layout column>
        <v-flex ma-3>
          <span class="title">Your made order:</span>
        </v-flex>
        <v-flex ma-2>
          <v-layout column>
            <v-flex ma-2>
              <v-layout row justify-space-between>
                <v-flex>
                  <span class="title">Time:</span>
                </v-flex>
                <v-flex mr-3 md4 style="text-align: right">
                  <span class="title">14.04.2019 18:49</span>
                </v-flex>
              </v-layout>
            </v-flex>
            <v-flex ma-2>
              <v-layout row justify-space-between>
                <v-flex >
                  <span class="title">Total price:</span>
                </v-flex>
                <v-flex mr-3 md2 style="text-align: right">
                  <span  class="title">843.43$</span>
                </v-flex>
              </v-layout>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex ma-2>
          <v-layout column>
            <v-flex ma-2>
              <OrderItem/>
            </v-flex>
            <v-flex ma-2>
              <OrderItem/>
            </v-flex>
            <v-flex ma-2>
              <OrderItem/>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex ma-2>
          <v-layout justify-end align-end>
            <v-flex md2 ma-2>
              <v-btn class="info" block>Close</v-btn>
            </v-flex>
          </v-layout>
        </v-flex>
      </v-layout>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import OrderItem from "./order-item.vue";

@Component({
  components: { OrderItem }
})
export default class Order extends Vue {}
</script>
