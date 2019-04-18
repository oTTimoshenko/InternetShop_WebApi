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
              label="E-mail"
              required
              placeholder="Put your e-mail here..."
              clearable
              v-model="email"
              :rules="[(v) => !!v || 'E-mail is required']"
            ></v-text-field>
            <v-text-field
              label="Password"
              required
              placeholder="Put your password here..."
              type="password"
              :rules="[(v) => !!v || 'Password is required']"
              v-model="password"
              clearable
            ></v-text-field>
            <v-layout row justify-space-around>
              <v-flex md4>
                <v-btn block class="info" @click="onShowRegistrationComponent()">Registrate</v-btn>
              </v-flex>
              <v-flex md4>
                <v-btn block class="success" :disabled="!isFormValid" @click="login()">Login</v-btn>
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
export default class LoginWindow extends Vue {
  private isFormValid: boolean = true;

  private email: string = "";
  private password: string = "";

  private onShowRegistrationComponent() {
    this.$emit("onShowRegistrationComponent");
  }

  private async login() {
    var response = (await Axios.get(
      "http://localhost:51936/api/Account/Login",
      {
        params: {
          email: this.email,
          password: this.password
        }
      }
    )).data;

    if (response) this.$emit("userLoggedIn");
  }
}
</script>
