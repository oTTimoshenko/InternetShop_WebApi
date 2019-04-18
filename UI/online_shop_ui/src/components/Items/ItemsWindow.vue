<template>
  <v-container>
    <v-toolbar app>
      <v-btn v-if="isUserLogedIn" flat @click="goToHomePage()" icon target="_blank">
        <v-icon size="36">home</v-icon>
      </v-btn>
      <v-toolbar-title class="headline text-uppercase">
        <span>Olexandr Timoshenko PI-316 Online Shop Project</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>

      <v-badge left v-if="isUserLogedIn" overlap>
        <template v-slot:badge>
          <span style="font-size: 12px;">{{cartItemsCount}}</span>
        </template>
        <v-btn flat @click="goToCartPage()" icon target="_blank">
          <v-icon size="32" color="grey lighten-1">shopping_cart</v-icon>
        </v-btn>
      </v-badge>
      <span v-if="isUserLogedIn" class="mr-2">Go to cart</span>
    </v-toolbar>
    <v-layout
      v-if="isAllItemsPageHasToBeVisible"
      row
      wrap
      justify-space-around
      align-center
      fill-height
    >
      <v-flex md3 ma-1 v-for="(itemDetails, index) in allItems" :key="index">
        <v-card @click="itemSelected(itemDetails.ItemId)">
          <single-item :itemDetails="itemDetails"></single-item>
        </v-card>
      </v-flex>
    </v-layout>

    <SingleItemWindow
      v-on:onItemAdded="onItemAdded"
      v-on:goToCartPage="goToCartPage"
      v-if="isSingleItemPageHasToBeVisible"
      :selectedItemId="selectedItemId"
    ></SingleItemWindow>

    <Cart
      ref="cart"
      v-on:onItemRemoved="onItemRemoved"
      v-if="isCartPageHasToBeVisible"
      v-on:onOrderMaked="onOrderMaked"
    />

    <LoginPage v-if="!isUserLogedIn" v-on:userLoggedIn="userLoggedIn"/>

    <Order
      v-if="isOrderPageHasToBeVisible"
      v-on:closeOrder="closeOrder"
      :orderDetails="orderDetails"
    />
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SingleItem from "./single-item.vue";
import SingleItemWindow from "./SingleItemWindow.vue";
import Cart from "@/components/Cart/Cart.vue";
import LoginPage from "@/components/User/LoginPage.vue";
import Order from "@/components/Order/Order.vue";
import Axios from "axios";

@Component({
  components: {
    SingleItem,
    SingleItemWindow,
    Cart,
    LoginPage,
    Order
  }
})
export default class ItemsWindow extends Vue {
  private isUserLogedIn: boolean = false;
  private cartItemsCount = 0;
  private onItemRemoved(length) {
    this.cartItemsCount = length;
  }

  private onItemAdded() {
    this.cartItemsCount++;
  }

  private userLoggedIn() {
    this.isUserLogedIn = true;
  }
  private selectedItemId: number = 0;
  private orderDetails: any = {
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
  private allItems: any[] = [
    {
      itemId: 0,
      itemName: "",
      itemPhotoPath: "",
      description: "",
      price: 0
    }
  ];

  private async created() {
    var response = await Axios.get(
      "http://localhost:51936/api/output/all_items"
    );
    this.allItems = response.data;
  }

  private onOrderMaked(orderDetails1) {
    this.orderDetails = orderDetails1;
    this.isCartPageHasToBeVisible = false;
    this.isOrderPageHasToBeVisible = true;
  }

  private itemSelected(itemId) {
    this.selectedItemId = itemId;
  }

  private get isAllItemsPageHasToBeVisible() {
    return (
      this.selectedItemId === 0 &&
      !this.isCartPageHasToBeVisible &&
      !this.isOrderPageHasToBeVisible &&
      this.isUserLogedIn
    );
  }

  private get isSingleItemPageHasToBeVisible() {
    return (
      this.selectedItemId !== 0 &&
      !this.isCartPageHasToBeVisible &&
      !this.isOrderPageHasToBeVisible &&
      this.isUserLogedIn
    );
  }

  private goToHomePage() {
    this.selectedItemId = 0;
    this.isCartPageHasToBeVisible = false;
    this.isOrderPageHasToBeVisible = false;
  }

  private isCartPageHasToBeVisible: boolean = false;

  private goToCartPage() {
    this.isOrderPageHasToBeVisible = false;
    this.isCartPageHasToBeVisible = true;
    this.selectedItemId = 0;
  }

  private isOrderPageHasToBeVisible: boolean = false;

  private goToOrderPage() {
    this.isCartPageHasToBeVisible = false;
    this.selectedItemId = 0;
  }

  private closeOrder() {
    this.isOrderPageHasToBeVisible = false;
    this.selectedItemId = 0;
  }
}
</script>


