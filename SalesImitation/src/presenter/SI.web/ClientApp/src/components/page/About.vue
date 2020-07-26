<template>

    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">

                <div class="general-page-title">
                  <h1>
                    შესახებ
                  </h1>
                </div>

                <div class="general-page-content-wrapper" v-html="dataAbout">

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
      dataAbout: ""
    }
  },
  mounted: function() {
      var self = this;
      request({
        url: "/api/Content/aboutus",
        method: "get"
    }).then(function(res) {
      self.dataAbout = res.data.value;
    });
}
}
</script>