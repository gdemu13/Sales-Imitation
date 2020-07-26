<template>
  <LogedInMain v-if="isLogedIn"></LogedInMain>
  <LogedOutMain v-else></LogedOutMain>
</template>
<script>
import LogedInMain from "./LogedInMain";
import LogedOutMain from "./LogedOutMain";

export default {
  name: "Index",
  data: function() {
    return {
      isLogedIn: false
    };
  },
  components: {
    LogedInMain,
    LogedOutMain
  },
  mounted() {
    this.isLogedIn = localStorage.getItem("authorisedUser");
  }
};
</script>
