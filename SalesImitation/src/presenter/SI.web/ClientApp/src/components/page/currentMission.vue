<template>
  <div class="mission-box">
    <div class="mission-header">
      <div class="lf">
        <div class="mission-step">
          <div class="step">{{ currentmission.level }}</div>
          <span>{{ currentmission.name }}</span>
        </div>
        <p>
          {{ currentmission.description }}
        </p>
      </div>
      <div class="rg">
        <div class="countdown-box">
          <countdown
            :time="time"
            :interval="100"
            tag="p"
            :transform="transform"
          >
            <template slot-scope="props">
              <div class="count-down-in">
                <div class="tm-item">
                  <div class="label">
                    დღე
                  </div>
                  {{ props.days }}
                </div>
                <div class="tm-item">
                  <div class="label">
                    სთ
                  </div>
                  {{ props.hours }}
                </div>
                <div class="tm-item">
                  <div class="label">
                    წთ
                  </div>
                  {{ props.minutes }}
                </div>
                <div class="tm-item">
                  <div class="label">
                    წმ
                  </div>
                  {{ props.seconds }}
                </div>
              </div>

              <div class="time-icon tltp" @click="showModal('timeModal')">
                  <span class="tooltiptext">დროის შეძენა</span>
                <svg
                  id="Group_1820"
                  data-name="Group 1820"
                  xmlns="http://www.w3.org/2000/svg"
                  width="16.003"
                  height="16.004"
                  viewBox="0 0 16.003 16.004"
                >
                  <path
                    id="Path_3115"
                    data-name="Path 3115"
                    d="M103.126,269.935a6.011,6.011,0,0,1-5-7.233,6,6,0,0,1,11.8.44.991.991,0,0,0,.982.851,1.006,1.006,0,0,0,1-1.139,8,8,0,1,0-9.052,9.062,1,1,0,0,0,.271-1.981Z"
                    transform="translate(-95.985 -255.992)"
                    fill="#2e81fb"
                  />
                  <path
                    id="Path_3116"
                    data-name="Path 3116"
                    d="M107.987,263.993a1,1,0,0,0-1-1h-2v-2a1,1,0,0,0-2,0v3a1,1,0,0,0,1,1h3A1,1,0,0,0,107.987,263.993Z"
                    transform="translate(-95.985 -255.992)"
                    fill="#2e81fb"
                  />
                  <path
                    id="Path_3117"
                    data-name="Path 3117"
                    d="M110.988,267.994h-1v-1a1,1,0,0,0-2,0v1h-1a1,1,0,1,0,0,2h1v1a1,1,0,0,0,2,0v-1h1a1,1,0,0,0,0-2Z"
                    transform="translate(-95.985 -255.992)"
                    fill="#2e81fb"
                  />
                </svg>
              </div>
            </template>
          </countdown>
        </div>
      </div>
    </div>

    <div class="mission-content">
      <div class="selected-category">
        <div class="selected-cat-row">
          <div class="title-item">
            კატეგორია
            <div class="label">
              {{ currentmission.category.name }}
            </div>
          </div>
          <div class="skip-tour" @click="showModal('confirmModalskipMission')">
            <div class="icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="10"
                viewBox="0 0 14 10"
              >
                <path
                  id="Path_2380"
                  data-name="Path 2380"
                  d="M206.2,742.4l-4-3A2,2,0,0,0,199,741v.5l-2.8-2.1A2,2,0,0,0,193,741v6a2,2,0,0,0,3.2,1.6l2.8-2.1v.5a2,2,0,0,0,3.2,1.6l4-3a2,2,0,0,0,0-3.2ZM195,747v-6l4,3Zm6,0v-6l4,3Z"
                  transform="translate(-193 -739)"
                  fill="#fff"
                />
              </svg>
            </div>
            ტურის გამოტოვება
          </div>
        </div>
        <div class="products-list">
          <perfect-scrollbar>
            <div class="product-item">
              <div class="pr-image">
                <img
                  :src="
                    `${currentmission.product1.imageUrl}`
                  "
                />
              </div>
              <div class="pr-info">
                <div class="pr-details">
                  <h4>
                    {{ currentmission.product1.name }}
                  </h4>
                  <div class="pr-specs">
                    <div class="spec-item">
                      <div class="label">
                        მაღაზია:
                      </div>
                      <div class="value">
                        {{ currentmission.product1.partnerName }}
                      </div>
                    </div>
                    <!-- <div class="spec-item">
                      <div class="label">
                        მისამართი:
                      </div>
                      <div class="value">
                        {{ currentmission.product1.partnetaAddress }}
                      </div>
                    </div> -->
                    <div class="spec-item">
                      <div class="label">
                        ფასი:
                      </div>
                        <div class="value"> {{ currentmission.product2.price }}₾</div>
                    </div>
                    <div class="spec-item">
                      <div class="label">
                        საჩუქარი:
                      </div>
                      <div class="value">
                        {{ currentmission.product1.gift }}
                      </div>
                    </div>
                  </div>
                  <div class="detail-btn">
                    დეტალურად
                  </div>
                </div>
                <div class="other-info">
                  <div class="promo-code">
                    <div class="label">
                      პრომო კოდი
                    </div>
                    <div class="value">
                      {{ currentmission.promoCode }}
                    </div>
                  </div>
                  <div class="points">
                    მისიის ქულა
                    <div class="point">
                      {{ currentmission.product1.expectedCoin }}
                      <span class="coin"></span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="product-item">
              <div class="pr-image">
                <img
                  :src="
                   `${currentmission.product2.imageUrl}`
                  "
                />
              </div>
              <div class="pr-info">
                <div class="pr-details">
                  <h4>
                    {{ currentmission.product2.name }}
                  </h4>
                  <div class="pr-specs">
                    <div class="spec-item">
                      <div class="label">
                        მაღაზია:
                      </div>
                      <div class="value">
                        {{ currentmission.product2.partnerName }}
                      </div>
                    </div>
                    <!-- <div class="spec-item">
                      <div class="label">
                        მისამართი:
                      </div>
                      <div class="value">
                        {{ currentmission.product2.partnetaAddress }}
                      </div>
                    </div> -->
                    <div class="spec-item">
                      <div class="label">
                        ფასი:
                      </div>
                      <div class="value"> {{ currentmission.product2.price }}₾</div>
                    </div>
                    <div class="spec-item">
                      <div class="label">
                        საჩუქარი:
                      </div>
                      <div class="value">
                        {{ currentmission.product2.gift }}
                      </div>
                    </div>
                  </div>
                  <div class="detail-btn">
                    დეტალურად
                  </div>
                </div>
                <div class="other-info">
                  <div class="promo-code">
                    <div class="label">
                      პრომო კოდი
                    </div>
                    <div class="value">
                      {{ currentmission.promoCode }}
                    </div>
                  </div>
                  <div class="points">
                    მისიის ქულა
                    <div class="point">
                      {{ currentmission.product2.expectedCoin }}
                      <span class="coin"></span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </perfect-scrollbar>
        </div>
      </div>
    </div>



    <modal name="Congrats" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('Congrats')">
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
          <div class="congrats-content">
            <h5>
              შეტყობინება
            </h5>
            <div class="icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="85.682"
                height="85.682"
                viewBox="0 0 85.682 85.682"
              >
                <g
                  id="Group_3663"
                  data-name="Group 3663"
                  transform="translate(-68.192 -3.159)"
                >
                  <path
                    id="Path_8342"
                    data-name="Path 8342"
                    d="M330.841,32a42.841,42.841,0,1,0,42.841,42.841A42.891,42.891,0,0,0,330.841,32Zm0,74.971a32.131,32.131,0,1,1,32.131-32.131A32.129,32.129,0,0,1,330.841,106.971Z"
                    transform="translate(-219.808 -28.841)"
                    fill="#00bd83"
                  />
                  <path
                    id="Path_8343"
                    data-name="Path 8343"
                    d="M325.7,38.57,308.066,56.2l-6.924-6.924a5.354,5.354,0,1,0-7.572,7.572l10.71,10.71a5.352,5.352,0,0,0,7.572,0l21.42-21.42A5.354,5.354,0,0,0,325.7,38.57Z"
                    transform="translate(-202.388 -7.066)"
                    fill="#00bd83"
                  />
                </g>
              </svg>
            </div>
            <h3>
              გილოცავთ!
            </h3>
            <p>
              {{ modalInfo.text }}
            </p>
          </div>
        </div>
      </div>
    </modal>

    <modal name="timeModal" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('timeModal')">
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
          <div class="congrats-content" style="margin-top: -15px;">
            <h5>
              დროის შეძენა
            </h5>

            <p>
              ქვემოთ მოცემულ ველში შეიყვანეთ დრო (საათი)
            </p>
            <input
              type="text"
              class="buyTimeInput"
              placeholder="მაგ: 1"
              v-model.number="buyTime"
              :style="{ borderColor: buyTimeError ? 'red' : '' }"
            />
            <p style="color: red" v-if="buyTimeError">
              {{ buyTimeError }}
            </p>
            <div class="save-btn" @click="buyTimeFunction">
              შენახვა
            </div>
          </div>
        </div>
      </div>
    </modal>

    <modal name="confirmModalskipMission" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('confirmModalskipMission')">
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
            <h5>
              ნამდვილად გსურთ ტურის გამოტოვება?
            </h5>

            <div class="confirm-btn" @click="skipMission">
              დიახ
            </div>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>
<script>
import Vue from "vue";
import VModal from "vue-js-modal";
import { PerfectScrollbar } from "vue2-perfect-scrollbar";
import VueCountdown from "@chenfengyuan/vue-countdown";
import request from "@/Request";

Vue.component(VueCountdown.name, VueCountdown);
Vue.use(VModal);
import axios from "axios";
export default {
  name: "currentMission",
  data: function() {
    var now = new Date();
    var deadline = new Date(this.currentmission.deadlineDate);

    return {
      progress: 0,
      counting: false,
      time: deadline - now,
      buyTime: "",
      buyTimeError: "",
      modalInfo: {
        title: "",
        text: "",
        icon: "",
      },
    };
  },
  components: {
    PerfectScrollbar
  },
  methods: {
    startCountdown: function() {
      this.counting = true;
    },
    handleCountdownEnd: function() {
      this.counting = false;
    },
    showModal(name) {
      switch (name) {
        case "timeModal":
          this.$modal.show("timeModal");
          break;
        case "Notificate":
          this.$modal.show("Notificate");
          break;
        case "confirmModalskipMission":
          this.$modal.show("confirmModalskipMission");
          break;
      }
    },
    hideModal(name) {
      switch (name) {
        case "timeModal":
          this.$modal.hide("timeModal");
          break;
        case "Notificate":
          this.$modal.hide("Notificate");
          break;
        case "confirmModalskipMission":
          this.$modal.hide("confirmModalskipMission");
          break;
        case "Congrats":
          this.$modal.hide("Congrats");
          break;
      }
    },
    transform(props) {
      Object.entries(props).forEach(([key, value]) => {
        // Adds leading zero
        const digits = value < 10 ? `0${value}` : value;

        props[key] = `${digits}`;
      });

      return props;
    },
    skipMission() {
      var self = this;
      axios
        .post("/api/game/skipMission")
        .then(function(response) {
          console.log(response);
          self.$modal.hide("confirmModalskipMission");
          self.init();
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    buyTimeFunction() {
      var self = this;

      request({
        url: "/api/game/buyExtraTime",
        method: "post",
        data: {
          hours: self.buyTime,
        },
      })
        .then((res) => {
          console.log(res);
          if (res.data.isSuccess) {
            self.init();
            self.$modal.hide("timeModal");
            self.$modal.show("Congrats");
            self.modalInfo.text =
              "თქვენ წარმატებით შეიძინეთ დრო: " + self.buyTime + " საათი.";
            self.buyTime = "";
            self.buyTimeError = "";
          }
        })
        .catch((err) => {
          if (err.response.status == 400) {
            self.buyTimeError = err.response.data.message;
          }
        });
    },
  },
  watch: {
    currentmission: {
      deep: true,
      handler: function(nv) {
        var now = new Date();
        var deadline = new Date(nv.deadlineDate);
        this.time = deadline - now;
      },
    },
  },
  props: ["currentmission", "init"],
  mounted: function() {},
};
</script>
<style scoped>
.tltp {
  position: relative;
  display: inline-block;
  border-bottom: 1px dotted black;
}

.tltp .tooltiptext {
  font-family: "helv-65";
  visibility: hidden;
  width: 120px;
  background-color: #3083fd;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px 0;
  position: absolute;
  z-index: 1;
  bottom: 150%;
  left: 50%;
  font-size: 13px;
  margin-left: -60px;
}

.tltp .tooltiptext::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border-color: #3083fd transparent transparent transparent;
}

.tltp:hover .tooltiptext {
  visibility: visible;
}
</style>
