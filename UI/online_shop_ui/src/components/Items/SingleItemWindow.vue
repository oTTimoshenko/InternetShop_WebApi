<template>
  <v-container grid-list-xl>
    <v-layout column>
      <v-flex>
        <v-layout column>
          <v-flex>Test name of Item</v-flex>
          <v-flex>
            <v-rating :value="value" color="amber" dense half-increments readonly size="14"></v-rating>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex>
        <v-layout row fill-height>
          <v-flex md7>
            <v-tabs align-with-title fixed-tabs left>
              <v-tab>Item 1</v-tab>

              <v-tab>Item 2</v-tab>

              <v-tab>Item 3</v-tab>

              <v-tab-item>
                <v-card>
                  <v-card-text>Test tab text1</v-card-text>
                  <v-img
                    :aspect-ratio="16/9"
                    src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                  ></v-img>
                </v-card>
              </v-tab-item>

              <v-tab-item>
                <v-card>
                  <v-card-text>Test tab text2</v-card-text>
                  <v-img
                    :aspect-ratio="16/9"
                    src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                  ></v-img>
                </v-card>
              </v-tab-item>

              <v-tab-item>
                <v-card>
                  <v-card-text>Test tab text3</v-card-text>
                  <v-img
                    :aspect-ratio="16/9"
                    src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                  ></v-img>
                </v-card>
              </v-tab-item>
            </v-tabs>
          </v-flex>
          <v-flex md5>
            <v-card>
              <v-layout column justify-center >
                <v-flex>
                  <v-card-text>Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Ultrices sagittis orci a scelerisque purus semper. Pretium lectus quam id leo in vitae. Sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae. Consequat interdum varius sit amet. Nam libero justo laoreet sit amet. Posuere urna nec tincidunt praesent semper feugiat. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Imperdiet nulla malesuada pellentesque elit eget gravida. Dui vivamus arcu felis bibendum ut tristique et egestas. Proin fermentum leo vel orci. Amet commodo nulla facilisi nullam vehicula. Ut etiam sit amet nisl purus in mollis. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Ultrices sagittis orci a scelerisque purus semper. Pretium lectus quam id leo in vitae. Sagittis aliquam malesuada bibendum arcu vitae elementum curabitur vitae. Consequat interdum varius sit amet. Nam libero justo laoreet sit amet. Posuere urna nec tincidunt praesent semper feugiat.</v-card-text>
                </v-flex>
                <v-flex>
                    <v-btn class="success" block>Buy</v-btn>
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
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class SingleItemWindow extends Vue {
  private value: number = 3.4;
  private reviews: number = 435;
}
</script>
