<script setup>
import ListUsers from "./components/ListUsers.vue";
import { ref, computed } from "vue";
import LoginView from "./components/LoginView.vue";

const routes = {
  "/": ListUsers,
  "/login": LoginView,
};
const currentPath = ref(window.location.hash);

window.addEventListener("hashchange", () => {
  currentPath.value = window.location.hash;
});

const currentView = computed(() => {
  return routes[currentPath.value.slice(1) || "/"];
});
</script>

<template>
  <a href="#/">Home</a> | <a href="#/login">Login</a> |
  <a href="#/non-existent-path">Broken Link</a>
  <component :is="currentView" />

  <!-- <LoginView /> -->
  <!-- <header>
    <Sergio tela="header" />
    <img
      alt="Vue logo"
      class="logo"
      src="./assets/logo.svg"
      width="125"
      height="125"
    />

    <Sergio tela="conteudo" />
    <div class="wrapper">
      <HelloWorld msg="Oi thaleszin!" />
  </div>
 </header> -->

  <!-- <main>
    <TheWelcome />
  </main> -->

  <!-- <Sergio tela="rodape" /> -->
</template>

<!-- <style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style> -->
