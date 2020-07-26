<template>
  <div class="mission-box start-mission">
    <div class="mission-header">
      <div class="lf">
        <div class="mission-step">
          <div class="step">1</div>
          <span>მისია</span>
        </div>
        <p>
          პივრელ მისიაში შენ მოგიწევს გაყიდო ნივთი 24 საათსა და 10 წუთში
          დასაწყებად გთხოვთ აირჩიოთ გასაყიდი ნივთის კატეგორია.
        </p>
      </div>
      <div class="rg">
        <div
          class="start-mission-btn"
          @click="startMission()"
          :style="{ backgroundColor: selectedColor }"
        >
          <div class="icon">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="15.914"
              height="16"
              viewBox="0 0 15.914 16"
            >
              <path
                id="Path_3083"
                data-name="Path 3083"
                d="M559.606,300.293a.991.991,0,0,0-1.407,0l-.288.29,0,0-1.87-1.88-.2-.2,1.005-1.01,1.77-1.78a1.012,1.012,0,0,0,0-1.42,1,1,0,0,0-1.412,0l-1.085,1.09-6.753-6.79a1.95,1.95,0,0,0-1.4-.59h-1.989a2,2,0,0,0-1.99,2v2a1.971,1.971,0,0,0,.587,1.41l6.754,6.79-1.085,1.09a1,1,0,0,0,1.413,1.42l1.77-1.78,1.005-1.01.2.2L556.5,302l-.288.29a1,1,0,0,0,0,1.414.99.99,0,0,0,1.406,0l.981-.986c.005-.005.012-.006.017-.011a.109.109,0,0,0,.011-.018l.981-.985A1,1,0,0,0,559.606,300.293ZM545.973,292v-2h1.989l6.753,6.79-1.989,2Z"
                transform="translate(-543.983 -288)"
                fill="#3285ff"
              />
            </svg>
          </div>
          <div class="txt">დაიწყე მისია</div>
        </div>
      </div>
    </div>

    <div class="mission-content">
      <perfect-scrollbar class="mission-items-desktop">
        <div class="mission-item" v-for="mission in missions" :key="mission.id">
          <input
            type="checkbox"
            @click="setMission(mission.id, mission.color)"
            :checked="isCheckedCategory(mission.id)"
          />
          <div class="mission-inner-box">
            <div class="img-item" :style="{ backgroundImage: 'url(' + mission.iconUrl + ')' }"></div>
            <div class="desc-info">
              <h4>{{ mission.name }}</h4>
              <div class="check-box">
                <div class="checker" :style="{ backgroundColor: mission.color }">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="15.799"
                    height="13.885"
                    viewBox="0 0 15.799 13.885"
                  >
                    <path
                      id="Path_2436"
                      data-name="Path 2436"
                      d="M581.942,718.978a.983.983,0,0,1-.7-.29l-4.937-4.959a1,1,0,0,1,0-1.4.984.984,0,0,1,1.4,0l4.132,4.15,8.2-10.987a.985.985,0,0,1,1.382-.2,1,1,0,0,1,.2,1.389l-8.887,11.9a.983.983,0,0,1-.72.394C581.989,718.977,581.965,718.978,581.942,718.978Z"
                      transform="translate(-576.018 -705.093)"
                      fill="#fff"
                    />
                  </svg>
                </div>
                <div class="label">{{ isCheckedCategory(mission.id) ? "არჩეულია" : "არჩევა" }}</div>
              </div>
            </div>
          </div>
        </div>
      </perfect-scrollbar>

      <div class="mission-carousel-mobile">
        <carousel>
          <slide v-for="mission in missions" :key="mission.id">
            <div class="mission-item">
              <input
                type="checkbox"
                @click="setMission(mission.id, mission.color)"
                :checked="isCheckedCategory(mission.id)"
              />
              <div class="mission-inner-box">
                <div class="img-item" :style="{ backgroundImage: 'url(' + mission.iconUrl + ')' }"></div>
                <div class="desc-info">
                  <h4>{{ mission.name }}</h4>
                  <div class="check-box">
                    <div class="checker" :style="{ backgroundColor: mission.color }">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="15.799"
                        height="13.885"
                        viewBox="0 0 15.799 13.885"
                      >
                        <path
                          id="Path_2436"
                          data-name="Path 2436"
                          d="M581.942,718.978a.983.983,0,0,1-.7-.29l-4.937-4.959a1,1,0,0,1,0-1.4.984.984,0,0,1,1.4,0l4.132,4.15,8.2-10.987a.985.985,0,0,1,1.382-.2,1,1,0,0,1,.2,1.389l-8.887,11.9a.983.983,0,0,1-.72.394C581.989,718.977,581.965,718.978,581.942,718.978Z"
                          transform="translate(-576.018 -705.093)"
                          fill="#fff"
                        />
                      </svg>
                    </div>
                    <div class="label">
                      {{
                      isCheckedCategory(mission.id) ? "არჩეულია" : "არჩევა"
                      }}
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </slide>
        </carousel>
      </div>
    </div>

    <modal name="infoPop" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal()">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="15.828"
              height="15.913"
              viewBox="0 0 15.828 15.913"
            >
              <path
                id="Path_2411"
                data-name="Path 2411"
                d="M521.353,712.03l6.225-6.259a1,1,0,0,0,0-1.407.986.986,0,0,0-1.4,0l-6.225,6.259-6.225-6.259a.986.986,0,0,0-1.4,0,1,1,0,0,0,0,1.407l6.225,6.259-6.225,6.259a1,1,0,0,0,0,1.406.986.986,0,0,0,1.4,0l6.225-6.259,6.225,6.259a.992.992,0,0,0,1.4-1.406Z"
                transform="translate(-512.04 -704.073)"
                fill="#fff"
              />
            </svg>
          </div>
        </div>
        <div class="content-wrapper-item">
          <div class="congrats-content" style="margin-top: 55px;">
            <h5>შეტყობინება</h5>

            <p>გთხოვთ აირჩიოთ კატეგორია</p>
          </div>
        </div>
      </div>
    </modal>

    <modal name="confirmMission" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModalConfirmMission()">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="15.828"
              height="15.913"
              viewBox="0 0 15.828 15.913"
            >
              <path
                id="Path_2411"
                data-name="Path 2411"
                d="M521.353,712.03l6.225-6.259a1,1,0,0,0,0-1.407.986.986,0,0,0-1.4,0l-6.225,6.259-6.225-6.259a.986.986,0,0,0-1.4,0,1,1,0,0,0,0,1.407l6.225,6.259-6.225,6.259a1,1,0,0,0,0,1.406.986.986,0,0,0,1.4,0l6.225-6.259,6.225,6.259a.992.992,0,0,0,1.4-1.406Z"
                transform="translate(-512.04 -704.073)"
                fill="#fff"
              />
            </svg>
          </div>
        </div>
        <div class="content-wrapper-item">
          <div class="congrats-content" style="margin-top: 55px;">
            <h5>ნამდვილად გსურთ მისიის დაწყება?</h5>

            <div class="confirm-btn" @click="letStartMission">დიახ</div>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>
<script>
import Vue from "vue";
import VModal from "vue-js-modal";
import VueCarousel from "vue-carousel";
import { Carousel, Slide } from "vue-carousel";
import request from "@/Request";
Vue.use(VueCarousel);
Vue.use(VModal);

import { PerfectScrollbar } from "vue2-perfect-scrollbar";
export default {
  name: "startMission",
  data: function() {
    return {
      missions: [],
      selectedCategory: "",
      selectedColor: ""
    };
  },
  methods: {
    setMission(id, color) {
      if (this.selectedCategory == id) {
        this.selectedCategory = "";
        this.selectedColor = "#3083fd";
      } else {
        this.selectedCategory = id;
        this.selectedColor = color;
      }
    },
    isCheckedCategory(id) {
      return id == this.selectedCategory;
    },
    hideModal() {
      this.$modal.hide("infoPop");
    },
    hideModalConfirmMission() {
      this.$modal.hide("confirmMission");
    },
    startMission() {
      var self = this;
      if (!self.selectedCategory) {
        this.$modal.show("infoPop");
      } else {
        this.$modal.show("confirmMission");
      }
    },
    letStartMission() {
      var self = this;
      request({
        url: "/api/game/startMission",
        method: "post",
        data: {
          selectedCategoryID: self.selectedCategory
        }
      })
        .then(function(response) {
          console.log(response);
          self.$modal.hide("confirmMission");
          self.onstart(true);
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  },
  components: {
    PerfectScrollbar,
    Carousel,
    Slide
  },
  props: ["onstart"],
  mounted() {
    var self = this;
    request({
        url: "/api/game/getAvaliableCategories",
        method: "get"
      })
      .then(function(response) {
        console.log(response);
        self.missions = response.data;
      })
      .catch(function(error) {
        console.log(error);
      });
  }
};
</script>
