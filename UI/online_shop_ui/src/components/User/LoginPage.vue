<template>
  <v-container>
    <LoginWindow/>
    <!-- <RegistrationWindow/> -->
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
export default class LoginPage extends Vue {}
</script>
