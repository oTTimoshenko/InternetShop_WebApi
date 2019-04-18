<template>
  <v-container grid-list-xl>
    <v-layout column>
      <v-flex>
        <v-layout column>
          <v-flex>
            <span class="title">{{itemDetails.ItemName}}</span>
          </v-flex>
          <v-flex>
            <v-rating :value="value" color="amber" dense half-increments readonly size="24"></v-rating>
            <span>{{value}} ({{reviews}})</span>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex>
        <v-layout row fill-height>
          <v-flex md7>
            <v-tabs align-with-title fixed-tabs left>
              <v-tab>Photo</v-tab>

              <v-tab>Characteristics</v-tab>

              <v-tab>Description</v-tab>

              <v-tab-item>
                <v-card height="350px">
                  <v-img
                    :aspect-ratio="16/9"
                    src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                  ></v-img>
                </v-card>
              </v-tab-item>

              <v-tab-item>
                <v-card height="350px">
                  <v-card-text>
                    <v-layout column>
                      <v-flex>
                        <v-layout row>
                          <v-flex md1></v-flex>
                          <v-flex md3>
                            <span>Display Diagonal:</span>
                          </v-flex>
                          <v-flex md6>
                            <span>{{itemDetails.ItemCharacteristic.DisplayDiagonal}}''</span>
                          </v-flex>
                        </v-layout>
                      </v-flex>
                      <v-flex>
                        <v-layout row>
                          <v-flex md1></v-flex>
                          <v-flex md3>
                            <span>RAM:</span>
                          </v-flex>
                          <v-flex md6>
                            <span>{{itemDetails.ItemCharacteristic.RAM}} Gb</span>
                          </v-flex>
                        </v-layout>
                      </v-flex>
                      <v-flex>
                        <v-layout row justify-start align-start>
                          <v-flex md1></v-flex>
                          <v-flex md3>
                            <span>Memory:</span>
                          </v-flex>
                          <v-flex md6>
                            <span>{{itemDetails.ItemCharacteristic.Memory}} Gb</span>
                          </v-flex>
                        </v-layout>
                      </v-flex>
                      <v-flex>
                        <v-layout row>
                          <v-flex md1></v-flex>
                          <v-flex md3>
                            <span>Camera:</span>
                          </v-flex>
                          <v-flex md6>
                            <span>{{itemDetails.ItemCharacteristic.Camera}} Megapixels</span>
                          </v-flex>
                        </v-layout>
                      </v-flex>
                    </v-layout>
                  </v-card-text>
                </v-card>
              </v-tab-item>

              <v-tab-item>
                <v-card height="350px">
                  <v-card-text>{{itemDetails.Description}}</v-card-text>
                </v-card>
              </v-tab-item>
            </v-tabs>
          </v-flex>
          <v-flex md5 mt-2>
            <v-card height="400px">
              <v-layout column justify-center fill-height>
                <v-flex md11>
                  <v-card-text>{{itemDetails.Description}}</v-card-text>
                </v-flex>
                <v-flex md>
                  <v-layout column fill-height justify-end>
                    <v-flex>
                      <v-layout row justify-center align-end>
                        <v-flex md6 v-if="!itemIsSaled">
                          <v-btn @click="addToCart()" class="success" block>Buy</v-btn>
                        </v-flex>
                        <v-flex md6 v-if="itemIsSaled">
                          <v-btn @click="goToCart()" class="info" block>Go to cart</v-btn>
                        </v-flex>
                      </v-layout>
                    </v-flex>
                  </v-layout>
                </v-flex>
              </v-layout>
            </v-card>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex>
        <v-layout row>
          <v-flex>
            <v-card>
              <v-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Imperdiet nulla malesuada pellentesque elit eget gravida. Dui vivamus arcu felis bibendum ut tristique et egestas. Proin fermentum leo vel orci. Amet commodo nulla facilisi nullam vehicula. Ut etiam sit amet nisl purus in mollis. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Ultrices sagittis orci a scelerisque purus semper. Pretium lectus quam id leo in vitae. Sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae. Consequat interdum varius sit amet. Nam libero justo laoreet sit amet. Posuere urna nec tincidunt praesent semper feugiat. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Imperdiet nulla malesuada pellentesque elit eget gravida. Dui vivamus arcu felis bibendum ut tristique et egestas. Proin fermentum leo vel orci. Amet commodo nulla facilisi nullam vehicula. Ut etiam sit amet nisl purus in mollis. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Ultrices sagittis orci a scelerisque purus semper. Pretium lectus quam id leo in vitae. Sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae. Consequat interdum varius sit amet. Nam libero justo laoreet sit amet. Posuere urna nec tincidunt praesent semper feugiat.</v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import Axios from "axios";

@Component({
  components: {}
})
export default class SingleItemWindow extends Vue {
  private value: number = 3.4;
  private reviews: number = 435;
  private itemIsSaled: boolean = false;

  @Prop({ default: 8 }) selectedItemId!: number;

  private itemDetails: any = {
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
  };

  private async addToCart() {
    Axios.get(
      "http://localhost:51936/api/CartPanel/addItem/" + this.selectedItemId
    );
    this.itemIsSaled = true;
    this.$emit("onItemAdded");
  }

  private goToCart() {
    this.$emit("goToCartPage");
  }

  private async created() {
    this.itemDetails = (await Axios.get(
      "http://localhost:51936/api/output/items/get/" + this.selectedItemId
    )).data;
    var test = "";
  }
}
</script>
