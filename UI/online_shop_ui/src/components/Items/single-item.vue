<template>
  <v-hover>
    <v-card slot-scope="{ hover }" :class="`elevation-${hover ? 12 : 2}`" class="mx-auto">
      <v-img :aspect-ratio="16/9" src="https://cdn.vuetifyjs.com/images/cards/cooking.png"></v-img>
      <v-card-title>
        <div>
          <span style="font-size: 16px; font-weight: bold;">{{itemDetails.ItemName}}</span>
          <div class="d-flex">
            <v-rating :value="value" color="amber" dense half-increments readonly size="14"></v-rating>
            <div class="ml-2 grey--text text--darken-2">
              <span>{{ value }}</span>
              <span>({{ reviews }})</span>
            </div>
          </div>
        </div>
        <v-spacer></v-spacer>
        <v-btn @click="goToItemDetailsPage()" icon class="mr-0">
          <v-icon>keyboard_arrow_right</v-icon>
        </v-btn>
      </v-card-title>
    </v-card>
  </v-hover>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component({
  components: {}
})
export default class SingleItem extends Vue {
  @Prop({
    default: {
      itemId: 0,
      itemName: "",
      itemPhotoPath: "",
      description: "",
      price: 0
    }
  })
  private itemDetails: any;

  private value: number = 3.4;
  private reviews: number = 435;

  private goToItemDetailsPage() {
    //this.$router.push({ name: "itemDetails" });
  }
}
</script>
