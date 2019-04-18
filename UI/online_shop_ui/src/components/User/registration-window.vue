<template>
  <v-layout row fill-height align-center>
    <v-flex md6>
      <v-img
        :aspect-ratio="11/9"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Emblem_of_National_Aviation_University.png/1200px-Emblem_of_National_Aviation_University.png"
      ></v-img>
    </v-flex>
    <v-flex md6>
      <v-layout justify-end>
        <v-flex md8>
          <v-form ref="login_form" v-model="isFormValid">
            <v-text-field
              label="Name*"
              v-model="name"
              required
              placeholder="Put your name here..."
              :rules="[(v) => !!v || 'Name is required']"
              clearable
            ></v-text-field>
            <v-text-field
              label="E-mail*"
              v-model="email"
              required
              placeholder="Put your e-mail here..."
              :rules="[(v) => !!v || 'E-mail is required']"
              clearable
            ></v-text-field>
            <v-text-field
              label="Address*"
              v-model="address"
              required
              placeholder="Put your address here..."
              :rules="[(v) => !!v || 'Address is required']"
              clearable
            ></v-text-field>

            <v-text-field
              label="Password*"
              required
              placeholder="Put your password here..."
              :rules="[(v) => !!v || 'Password is required']"
              type="password"
              clearable
              v-model="password"
            ></v-text-field>
            <v-text-field
              label="Confirm Password*"
              required
              placeholder="Put your password again here..."
              :rules="[(v) => !!v || 'Confirm Password is required']"
              type="password"
              clearable
              v-model="confirmPassword"
            ></v-text-field>
            <v-layout row justify-space-around>
              <v-flex md5>
                <v-btn class="info" block @click="onShowLoginComponent()">Login</v-btn>
              </v-flex>
              <v-flex md5>
                <v-btn
                  :disabled="!isFormValid"
                  class="success"
                  block
                  @click="registrate()"
                >Registrate</v-btn>
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
import Axios from "axios";
@Component({
  components: {}
})
export default class RegistrationWindow extends Vue {
  private isFormValid: boolean = true;
  private name: string = "";
  private email: string = "";
  private address: string = "";
  private password: string = "";
  private confirmPassword: string = "";

  private onShowLoginComponent() {
    this.$emit("onShowLoginComponent");
  }

  private async registrate() {
    var response = (await Axios.get(
      "http://localhost:51936/api/Account/Register",
      {
        params: {
          email: this.email,
          password: this.password,
          confirmPassword: this.confirmPassword,
          address: this.address,
          name: this.name
        }
      }
    )).data;

    if (response.Succedeed) this.$emit("userLoggedIn");
  }
}
</script>
