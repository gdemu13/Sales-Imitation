<template>

    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">

                <div class="general-page-title">
                  <h1>
                    კონტაქტი
                  </h1>
                </div>

                <div class="general-page-content-wrapper" v-html="dataContact">

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
  data: function (){
    return {
      dataContact: ""
    }
  },
    mounted: function() {
      var self = this;
      request({
        url: "/api/Content/contactus",
        method: "get"
    }).then(function(res) {
      self.dataContact = res.data.value;
    });
}
};
</script>