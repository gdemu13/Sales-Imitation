<template>
  <div id="app">
    <login v-if="!isLogedIn" />
    <confirm-sale v-if="isLogedIn" />
  </div>
</template>

<script>
import login from "./components/loginComponent.vue";
import confirmSale from "./components/confirmSale.vue";

export default {
  name: "App",
  data: function() {
    return {
      isLogedIn: false
    };
  },
  components: {
    login,
    confirmSale
  },
  mounted() {
    this.isLogedIn = localStorage.getItem("authorisedUser");
  }
};
</script>

<style>
html {
  height: 100%;
}
body {
  margin: 0;
  padding: 0;
  font-family: sans-serif;
  background: #3285ff;
}

input:-webkit-autofill,
input:-webkit-autofill:hover,
input:-webkit-autofill:focus,
input:-webkit-autofill:active {
  -webkit-box-shadow: 0 0 0 30px #0c131e inset !important;
}

/*Change text in autofill textbox*/
input:-webkit-autofill {
  -webkit-text-fill-color: white !important;
}
</style>
