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
                  <span class="title">{{orderDate}} {{orderTime}}</span>
                </v-flex>
              </v-layout>
            </v-flex>
            <v-flex ma-2>
              <v-layout row justify-space-between>
                <v-flex>
                  <span class="title">Total price:</span>
                </v-flex>
                <v-flex mr-3 md2 style="text-align: right">
                  <span class="title">{{orderDetails.Price}}$</span>
                </v-flex>
              </v-layout>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex ma-2>
          <v-layout column>
            <v-flex md12 ma-2 v-for="(item, index) in orderDetails.Items" :key="index">
              <OrderItem :itemDetails="item"/>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex ma-2>
          <v-layout justify-end align-end>
            <v-flex md2 ma-2>
              <v-btn @click="close()" class="info" block>Close</v-btn>
            </v-flex>
          </v-layout>
        </v-flex>
      </v-layout>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import OrderItem from "./order-item.vue";

@Component({
  components: { OrderItem }
})
export default class Order extends Vue {
  @Prop() private orderDetails!: any;

  private get orderTime() {
    return new Date(Date.now()).toLocaleTimeString();
  }

  private get orderDate() {
    return new Date(Date.now()).toDateString();
  }

  private close() {
    this.$emit("closeOrder");
  }

  private orderDetails1: any = {
    Time: new Date(),
    TimeInMilliseconds: 0,
    Price: 0,
    Items: [
      {
        ItemId: 0,
        ItemName: "",
        ItemPhotoPath: "",
        Description: "",
        Price: 0,
        ItemCharacteristic: {
          DisplayDiagonal: 0,
          RAM: 0,
          Memory: 0,
          Camera: 0
        }
      }
    ]
  };
}
</script>
