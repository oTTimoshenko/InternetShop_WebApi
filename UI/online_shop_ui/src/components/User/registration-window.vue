<template>
  <v-layout row fill-height align-center>
    <v-flex md6>
      <v-img :aspect-ratio="16/9" src="https://cdn.vuetifyjs.com/images/cards/cooking.png"></v-img>
    </v-flex>
    <v-flex md6>
      <v-layout justify-end>
        <v-flex md8>
          <v-form ref="login_form">
            <v-text-field label="Name" required placeholder="Put your name here..." clearable></v-text-field>
            <v-text-field label="E-mail" required placeholder="Put your e-mail here..." clearable></v-text-field>
            <v-text-field label="Address" required placeholder="Put your address here..." clearable></v-text-field>

            <v-text-field
              label="Password"
              required
              placeholder="Put your password here..."
              type="password"
              clearable
            ></v-text-field>
            <v-text-field
              label="Confirm Password"
              required
              placeholder="Put your password again here..."
              type="password"
              clearable
            ></v-text-field>
            <v-layout row justify-space-around>
              <v-flex md5>
                <v-btn class="success" block @click="login">Login</v-btn>
              </v-flex>
              <v-flex md5>
                <v-btn class="info" block @click="login">Registrate</v-btn>
              </v-flex>
            </v-layout>
          </v-form>
        </v-flex>
      </v-layout>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {}
})
export default class RegistrationWindow extends Vue {}
</script>
