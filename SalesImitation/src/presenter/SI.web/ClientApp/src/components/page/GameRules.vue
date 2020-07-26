<template>

    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">

                <div class="general-page-title">
                  <h1>
                    თამაშის წესები
                  </h1>
                </div>

                <div class="general-page-content-wrapper" v-html="dataGameRules">

                </div>

            </div>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
import request from "@/Request";

export default {
  name: "Dashboard",
  components: {
  },
  data: function () {
    return {
      dataGameRules: ""
    }
  },
   mounted: function() {
      var self = this;
      request({
        url: "/api/Content/gamerules",
        method: "get"
    }).then(function(res) {
      self.dataGameRules = res.data.value;
    });
}
};
</script>