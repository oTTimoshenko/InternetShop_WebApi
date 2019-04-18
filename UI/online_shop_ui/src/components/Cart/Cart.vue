<template>
  <v-container>
    <v-layout column>
      <v-flex md12 ma-1 v-for="(line, index) in cartDetails.lines" :key="index">
        <CartItem v-on:onItemRemoved="onItemRemoved" :itemDetails="line.Item"/>
      </v-flex>

      <v-flex ma-1 v-if="isInCartAtLeastOneItem">
        <v-layout row justify-end align-center>
          <v-flex md3>
            <span class="title">Total price of cart: {{totalPrice}}</span>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex ma-1 v-else>
        <v-layout row justify-center align-center>
          <v-flex md4 ml-5>
            <span class="title">There are no items in your cart...</span>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex ma-1 v-if="isInCartAtLeastOneItem">
        <v-layout row justify-end align-center>
          <v-flex md3>
            <v-btn block @click="makeOrder()" class="success">Buy All</v-btn>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CartItem from "./cart-item.vue";
import Axios from "axios";

@Component({
  components: { CartItem }
})
export default class Cart extends Vue {
  private cartDetails: any = {
    overallPrice: 0,
    lines: [
      {
        ShoppingCartId: 0,
        Quantity: 0,
        Item: {
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
      }
    ]
  };

  private onItemRemoved(itemId: number) {
    this.cartDetails.lines = this.cartDetails.lines.filter(
      x => x.Item.ItemId !== itemId
    );
    this.$emit("onItemRemoved", this.cartDetails.lines.length);
  }

  private get totalPrice() {
    var total = 0;

    this.cartDetails.lines.forEach(x => (total += x.Item.Price));

    return total;
  }

  private get isInCartAtLeastOneItem() {
    return this.countOfItems > 0;
  }

  public get countOfItems() {
    return this.cartDetails.lines.length;
  }

  private async makeOrder() {
    var response = (await Axios.get(
      "http://localhost:51936/api/OrderPanel/addOrder"
    )).data;
    this.$emit("onOrderMaked", response);
  }

  private async created() {
    this.cartDetails = (await Axios.get(
      "http://localhost:51936/api/CartPanel/composeOrder"
    )).data;
  }
}
</script>
