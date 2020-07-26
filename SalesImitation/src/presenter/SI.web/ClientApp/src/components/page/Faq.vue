<template>

    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">
              <div class="general-page-title">
                <h1>
                  FAQ
                </h1>
              </div>

              <div class="general-page-content-wrapper">
                <VueFaqAccordion :items="myItems" activeColor='#2f82fc' />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
import VueFaqAccordion from "vue-faq-accordion";

export default {
  name: "Dashboard",
  components: {
    VueFaqAccordion,
  },
  data: function() {
    return {
      myItems: [
        {
          title: "How many time zones are there in all?",
          value:
            "Given a 24-hour day and 360 degrees of longitude around the Earth",
        },
        {
          title: "How long is a day and year on Venus?",
          value:
            "Venus takes 224.7 Earth days to complete one orbit around the Sun.",
        },
        {
          title: "What animal smells like popcorn?",
          value: "Binturongs smell like popcorn.",
        },
      ],
    };
  },
};
</script>
