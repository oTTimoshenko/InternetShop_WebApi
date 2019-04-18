<template>
  <v-container>
    <div class="loginPage">
      <LoginWindow
        v-on:onShowRegistrationComponent="onShowRegistrationComponent"
        v-on:userLoggedIn="onUserLoggedIn"
        v-if="isUserAlreadyRegistered"
      />
      <RegistrationWindow
        v-on:userLoggedIn="onUserLoggedIn"
        v-on:onShowLoginComponent="onShowLoginComponent"
        v-else
      />
    </div>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import LoginWindow from "./login-window.vue";
import RegistrationWindow from "./registration-window.vue";

@Component({
  components: {
    LoginWindow,
    RegistrationWindow
  }
})
export default class LoginPage extends Vue {
  private isUserAlreadyRegistered: boolean = true;

  private onShowLoginComponent() {
    this.isUserAlreadyRegistered = true;
  }

  private onShowRegistrationComponent() {
    this.isUserAlreadyRegistered = false;
  }

  private onUserLoggedIn() {
    this.$emit("userLoggedIn");
  }
}
</script>

<style>
.loginPage {
  height: 500px !important;
}
</style>

