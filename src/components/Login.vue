<template>
<div class="login">
  <form v-if="!isLoading && !isAuth" @submit.prevent>
    <StyledInput placeholder="Username" v-bind:value="user.username" @input="user.username = $event.target.value"/>
    <StyledInput type="password" placeholder="Password" v-bind:value="user.password" @input="user.password = $event.target.value"/>
    <StyledButton v-on:keydown.enter="login" @click="submit">Login</StyledButton>
  </form>
  <p v-if="isLoading">Loading</p>
  <p v-if="isAuth">{{ username }}</p>
</div>
</template>

<script>
import { mapGetters, mapMutations, mapState } from "vuex";
import axios from "axios";

const url = "https://localhost:7252";

export default {
  name:"Login",
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      isLoading: false,
    }
  },
  methods: {
    submit(){
      this.login(this.user);
      this.user.password = '';
      this.user.username = '';
    },
    login(user) {
      this.isLoading = true;
      axios.post(url + "/api/login", user)
        .then(value => this.auth(value))
        .catch(() => this.setAuth(false))
        .finally(() => this.isLoading = false);
    },
    tryLoginByJwt(token) {
      this.isLoading = true;
      axios.get(url + "api/login", { headers: {Authorization: 'Bearer ' + token}})
          .then(value => this.auth(value))
          .catch(() => this.setAuth(false))
          .finally(() => this.isLoading = false);
    },
    auth(response) {
      this.saveToken(response.token);
      this.setUsername(response.username());
      this.setAuth(true);
    },
    saveToken(token){
      this.setToken(token);
      localStorage.setItem("jwt", token);
    },
    ...mapMutations({
      setAuth: "setAuth",
      setToken: "setToken",
      setUsername: "setUsername"
    })
  },
  mounted() {
    this.tryLoginByJwt(this.token);
  },
  computed: {
    ...mapState({
      isAuth: state => state.isAuth,
      username: state => state.username,
      token: state => state.jwt
    }),
    ...mapGetters({
      coins: 'coinsString'
    })
  }
};
</script>

<style lang="scss" scoped>
.login {
  position: absolute;
  top: 10px;
  right: 10px;
}
</style>