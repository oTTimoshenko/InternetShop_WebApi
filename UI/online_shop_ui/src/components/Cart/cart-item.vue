<template>
  <v-card v-if="isVisible">
    <v-layout align-center justify-center>
      <v-flex md2>
        <v-img :aspect-ratio="16/9" src="https://cdn.vuetifyjs.com/images/cards/cooking.png"></v-img>
      </v-flex>
      <v-flex>
        <v-layout column justify-center align-start>
          <flex>
            <v-card-text class="title" align="left">{{itemDetails.ItemName}}</v-card-text>
          </flex>
          <flex>
            <v-card-text class="title" align="left">{{itemDetails.itemDetails}}</v-card-text>
          </flex>
        </v-layout>
      </v-flex>
      <v-flex md1>
        <v-card-text class="title" align="center">{{itemDetails.Price}}$</v-card-text>
      </v-flex>
      <v-flex md1>
        <v-btn @click="removeItem()" icon>
          <v-icon>clear</v-icon>
        </v-btn>
      </v-flex>
    </v-layout>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from "vue-property-decorator";
import Axios from "axios";

@Component({
  components: {}
})
export default class CartItem extends Vue {
  @Prop() private itemDetails!: any;
  private isVisible: boolean = true;

  private removeItem() {
    Axios.get(
      "http://localhost:51936/api/CartPanel/removeItem/" +
        this.itemDetails.ItemId
    );

    this.isVisible = false;
    this.onItemRemoved();
  }

  private onItemRemoved() {
    this.$emit("onItemRemoved", this.itemDetails.ItemId);
  }

  @Watch("itemDetails")
  private tere(tegrg: any) {
    var test = tegrg;
  }
}
</script>
