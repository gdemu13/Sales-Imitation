<template>
  <div id="app">
    <div class="main-content">
      <div class="general-page-wrapper">
        <d-header v-if="isLogedIn"></d-header>
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>


<script>
import DHeader from "./components/inc/dashboard_header";

export default {
  name: "App",
  components: {
    "d-header": DHeader
  },
  mounted: function() {
    this.isLogedIn = localStorage.getItem("authorisedUser");
  },
  data: function() {
    return {
      isLogedIn: false
    };
  }
};
</script>
