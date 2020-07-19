<template>
  <div class="general-header-navbar">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <div class="nav-bar-in">
            <div class="lf-side">
              <div class="logo">
                <h1>
                 <a href="/"><img src="/img/logo-blue.png" alt="si.ge logo" /></a>
                </h1>
              </div>
              <div class="menu-item">
                <ul>
                  <li class="active">
                    <router-link :to="`/${$i18n.locale}`">მთავარი</router-link>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/about`"
                      >ჩვენ შესახებ</router-link
                    >
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/gameRules`"
                      >თამაშის წესები</router-link
                    >
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/faq`">FAQ</router-link>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/contact`"
                      >კონტაქტი</router-link
                    >
                  </li>
                </ul>
              </div>

              <div class="fullscreenMenuMobile" :class="{ active: mobileMenu }">
                <ul>
                  <li class="active">
                    <router-link :to="`/${$i18n.locale}`">მთავარი</router-link>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/about`"
                      >ჩვენ შესახებ</router-link
                    >
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/gameRules`"
                      >თამაშის წესები</router-link
                    >
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/faq`">FAQ</router-link>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/contact`"
                      >კონტაქტი</router-link
                    >
                  </li>
                </ul>
              </div>

              <div class="mobile-nav">
                <div
                  class="burger-menu"
                  @click="mobileMenuToggle"
                  :class="{ active: mobileMenu }"
                >
                  <div class="showMenu">
                    <svg
                      id="Layer_1"
                      enable-background="new 0 0 512 512"
                      height="512"
                      viewBox="0 0 512 512"
                      width="512"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        d="m464.883 64.267h-417.766c-25.98 0-47.117 21.136-47.117 47.149 0 25.98 21.137 47.117 47.117 47.117h417.766c25.98 0 47.117-21.137 47.117-47.117 0-26.013-21.137-47.149-47.117-47.149z"
                      />
                      <path
                        d="m464.883 208.867h-417.766c-25.98 0-47.117 21.136-47.117 47.149 0 25.98 21.137 47.117 47.117 47.117h417.766c25.98 0 47.117-21.137 47.117-47.117 0-26.013-21.137-47.149-47.117-47.149z"
                      />
                      <path
                        d="m464.883 353.467h-417.766c-25.98 0-47.117 21.137-47.117 47.149 0 25.98 21.137 47.117 47.117 47.117h417.766c25.98 0 47.117-21.137 47.117-47.117 0-26.012-21.137-47.149-47.117-47.149z"
                      />
                    </svg>
                  </div>
                  <div class="closeMenu">
                    <svg
                      height="329pt"
                      viewBox="0 0 329.26933 329"
                      width="329pt"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        d="m194.800781 164.769531 128.210938-128.214843c8.34375-8.339844 8.34375-21.824219 0-30.164063-8.339844-8.339844-21.824219-8.339844-30.164063 0l-128.214844 128.214844-128.210937-128.214844c-8.34375-8.339844-21.824219-8.339844-30.164063 0-8.34375 8.339844-8.34375 21.824219 0 30.164063l128.210938 128.214843-128.210938 128.214844c-8.34375 8.339844-8.34375 21.824219 0 30.164063 4.15625 4.160156 9.621094 6.25 15.082032 6.25 5.460937 0 10.921875-2.089844 15.082031-6.25l128.210937-128.214844 128.214844 128.214844c4.160156 4.160156 9.621094 6.25 15.082032 6.25 5.460937 0 10.921874-2.089844 15.082031-6.25 8.34375-8.339844 8.34375-21.824219 0-30.164063zm0 0"
                      />
                    </svg>
                  </div>
                </div>
                <div class="mobile-logo">
                  <img src="/img/logoMobile.png" alt="" />
                </div>
              </div>
            </div>

            <div class="right-nav">
              <div class="release-btn" @click="withdrawMoney">
                <div class="icon">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="14"
                    viewBox="0 0 16 14"
                  >
                    <g
                      id="Group_3663"
                      data-name="Group 3663"
                      transform="translate(-1392.033 -448)"
                    >
                      <path
                        id="Path_2737"
                        data-name="Path 2737"
                        d="M654,513H642a2.006,2.006,0,0,0-2,2v8a2.006,2.006,0,0,0,2,2h5a1,1,0,0,0,0-2h-5v-4h14v-4A2.006,2.006,0,0,0,654,513Zm0,4H642v-2h12Z"
                        transform="translate(752.033 -65)"
                        fill="#fff"
                      />
                      <path
                        id="Path_2738"
                        data-name="Path 2738"
                        d="M655,523h-1v-1a1,1,0,0,0-2,0v1h-1a1,1,0,0,0,0,2h1v1a1,1,0,0,0,2,0v-1h1a1,1,0,0,0,1-1v-1a1.871,1.871,0,0,1-.09.59A1,1,0,0,0,655,523Z"
                        transform="translate(752.033 -65)"
                        fill="#fff"
                      />
                      <path
                        id="Path_2739"
                        data-name="Path 2739"
                        d="M646,520h-1a1,1,0,0,0,0,2h2a1,1,0,0,0,0-2Z"
                        transform="translate(752.033 -65)"
                        fill="#fff"
                      />
                    </g>
                  </svg>
                </div>
                <span>გაანაღდება</span>
              </div>

              <div class="user-menu-btn" @click="toggleDropDown">
                <div class="icon">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="13.995"
                    height="16"
                    viewBox="0 0 13.995 16"
                  >
                    <path
                      id="Path_2999"
                      data-name="Path 2999"
                      d="M333.968,361.969a10.045,10.045,0,0,0-2.526-1.355,4.98,4.98,0,0,0-2.855-8.576,4.584,4.584,0,0,0-1.178,0,4.981,4.981,0,0,0-2.856,8.576,10.039,10.039,0,0,0-2.525,1.355,2.52,2.52,0,0,0,0,4.062,10.035,10.035,0,0,0,11.94,0,2.522,2.522,0,0,0,0-4.062ZM324.991,357a2.99,2.99,0,0,1,2.7-2.98,2.429,2.429,0,0,1,.622,0,3,3,0,1,1-3.318,2.98Zm7.783,7.424a8.025,8.025,0,0,1-9.552,0,.523.523,0,0,1,0-.849,8.029,8.029,0,0,1,9.552,0A.524.524,0,0,1,332.774,364.424Z"
                      transform="translate(-321 -352)"
                      fill="#fff"
                    />
                  </svg>
                  <!-- <div class="notifications">
                    8
                  </div> -->
                </div>
                <div class="txt">
                  {{ logedInUserName }}
                  <span class="arrow">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="9.919"
                      height="5.857"
                      viewBox="0 0 9.919 5.857"
                    >
                      <path
                        id="Path_2393"
                        data-name="Path 2393"
                        d="M453.825,748.967a.966.966,0,0,1-.69-.29,1,1,0,0,1,0-1.4l3.214-3.267-3.214-3.266a1,1,0,0,1,0-1.4.965.965,0,0,1,1.38,0l3.9,3.968a1,1,0,0,1,0,1.4l-3.9,3.968A.967.967,0,0,1,453.825,748.967Z"
                        transform="translate(748.967 -452.849) rotate(90)"
                        fill="#2f82fc"
                      />
                    </svg>
                  </span>
                </div>
                <div
                  :class="[dropDown ? 'active dropdown-Menu' : 'dropdown-Menu']"
                >
                  <ul>
                    <li>
                       <router-link :to="`/${$i18n.locale}/editProfile`">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="13.995"
                          height="16"
                          viewBox="0 0 13.995 16"
                        >
                          <path
                            id="Path_2999"
                            data-name="Path 2999"
                            d="M333.968,361.969a10.045,10.045,0,0,0-2.526-1.355,4.98,4.98,0,0,0-2.855-8.576,4.584,4.584,0,0,0-1.178,0,4.981,4.981,0,0,0-2.856,8.576,10.039,10.039,0,0,0-2.525,1.355,2.52,2.52,0,0,0,0,4.062,10.035,10.035,0,0,0,11.94,0,2.522,2.522,0,0,0,0-4.062ZM324.991,357a2.99,2.99,0,0,1,2.7-2.98,2.429,2.429,0,0,1,.622,0,3,3,0,1,1-3.318,2.98Zm7.783,7.424a8.025,8.025,0,0,1-9.552,0,.523.523,0,0,1,0-.849,8.029,8.029,0,0,1,9.552,0A.524.524,0,0,1,332.774,364.424Z"
                            transform="translate(-321 -352)"
                            fill="#fff"
                          />
                        </svg>
                        პროფილი
                      </router-link>
                    </li>
                    <!-- <li>
                      <a href="#">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="13.995"
                          height="16"
                          viewBox="0 0 13.995 16"
                        >
                          <path
                            id="Path_2999"
                            data-name="Path 2999"
                            d="M333.968,361.969a10.045,10.045,0,0,0-2.526-1.355,4.98,4.98,0,0,0-2.855-8.576,4.584,4.584,0,0,0-1.178,0,4.981,4.981,0,0,0-2.856,8.576,10.039,10.039,0,0,0-2.525,1.355,2.52,2.52,0,0,0,0,4.062,10.035,10.035,0,0,0,11.94,0,2.522,2.522,0,0,0,0-4.062ZM324.991,357a2.99,2.99,0,0,1,2.7-2.98,2.429,2.429,0,0,1,.622,0,3,3,0,1,1-3.318,2.98Zm7.783,7.424a8.025,8.025,0,0,1-9.552,0,.523.523,0,0,1,0-.849,8.029,8.029,0,0,1,9.552,0A.524.524,0,0,1,332.774,364.424Z"
                            transform="translate(-321 -352)"
                            fill="#fff"
                          />
                        </svg>
                        პარამეტრები
                      </a>
                    </li> -->
                    <li>
                      <a href="#" @click="logOut()">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="16"
                          height="16"
                          viewBox="0 0 16 16"
                        >
                          <g transform="translate(-1768.033 -277)">
                            <path
                              class="a"
                              d="M655,711a1,1,0,0,0-1,1v6H642v-6a1,1,0,0,0-2,0v7a1,1,0,0,0,1,1h14a1,1,0,0,0,1-1v-7A1,1,0,0,0,655,711Z"
                              transform="translate(2488.033 -363) rotate(90)"
                            />
                            <path
                              class="a"
                              d="M648.707,704.293a1,1,0,0,0-1.414,0l-3,3a1,1,0,0,0,1.414,1.414L647,707.414V715a1,1,0,0,0,2,0v-7.586l1.293,1.293a1,1,0,0,0,1.414-1.414Z"
                              transform="translate(2488.033 -363) rotate(90)"
                            />
                          </g>
                        </svg>
                        გამოსვლა
                      </a>
                    </li>
                  </ul>
                </div>
              </div>

              <div class="lang-switcher">
                <ol>
                  <li>
                    <a href="#" @click.prevent="setLocale('ka')">ქარ</a>
                  </li>
                  <li>
                    <a href="#" @click.prevent="setLocale('en')">Eng</a>
                  </li>
                </ol>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <modal name="wethdrawPop" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModalWethdrawPop">
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
              თანხის განაღდება!
            </h5>

            <p>
              ჩაწერეთ სასურველი თანხა
            </p>
            <input type="text" class="buyTimeInput" placeholder="მაგ: 100" />

            <div class="save-btn">
              შენახვა
            </div>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>
<script>
import Vue from "vue";
import axios from "axios";
import VModal from "vue-js-modal";
Vue.use(VModal);

export default {
  name: "DashboardHeader",
  data: function() {
    return {
      dropDown: false,
      logedInUserName: "",
      mobileMenu: false,
    };
  },
  methods: {
    withdrawMoney() {
      this.$modal.show("wethdrawPop");
    },
    hideModalWethdrawPop() {
      this.$modal.hide("wethdrawPop");
    },
    mobileMenuToggle() {
      this.mobileMenu = !this.mobileMenu;
    },
    setLocale(locale) {
      this.$i18n.locale = locale;
      this.$router.push({
        params: { lang: locale },
      });
    },
    toggleDropDown() {
      this.dropDown = !this.dropDown;
    },
    logOut() {
      // TODO: Logout service
      axios
        .post("/api/account/logout")
        .then(function(response) {
          console.log(response);
          localStorage.removeItem("authorisedUser");
          window.location.href = "/";
        })
        .catch(function(error) {
          console.log(error);
        });
    },
  },
  mounted: function() {
    this.logedInUserName = localStorage.getItem("authorisedUser");
  },
};
</script>

<style scoped>
.general-header-navbar {
}
</style>
