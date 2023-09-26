<script>
export default {
  name: "LoginView",
  data() {
    return {
      username: "",
      password: "",
    };
  },
  methods: {
    login() {
      //make sure username OR password are not empty

      // requisicao para a API do backend
      // passar user e senha
      // se a resposta for OK, pode acessar o sistema retorna FOI
      let urlApi = "https://localhost:57022/Users/authenticate";

      fetch(urlApi, {
        method: "POST",
        headers: {
          Accept: "application/json, text/plain, */*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username: this.username,
          password: this.password,
        }),
      })
        .then((response) => {
          console.log(response);
          if (response.status == 200) {
            alert("FOI!!!");
          } else {
            alert("SENHA ERRADA MEU IRMAO");
          }
        })
        .catch((err) => {
          console.log(err);
          alert("Erro no sistema");
        });
    },
  },
};
</script>

<template>
  <form name="login-form">
    <!-- <p>Username is: {{ username }}</p>
    <p>Password is: {{ password }}</p> -->

    <div class="mb-3">
      <label for="username">Username: </label>
      <input type="text" v-model="username" placeholder="poe seu nome" />
    </div>
    <div class="mb-3">
      <label for="password">Password: </label>
      <input v-model="password" type="password" />
    </div>
    <button @click.prevent="login" class="btn btn-outline-dark" type="submit">
      Login
    </button>
  </form>
</template>
