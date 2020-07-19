<template>
  <div class="general-page-wrapper">
    <d-header></d-header>

    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">
              <div class="left-side">
                <div class="progress-banner">
                  <div class="step-buttons-wrapper">
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 1,
                      }"
                    >1</div>
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 2,
                      }"
                    >2</div>
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 3,
                      }"
                    >3</div>
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 4,
                      }"
                    >4</div>
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 5,
                      }"
                    >5</div>
                    <div
                      :class="{
                        'step-button': true,
                        'blue-bg': player.currentLevel >= 6,
                      }"
                    >6</div>
                    <div
                      :class="{
                        'step-button ': true,
                        'blue-bg': player.currentLevel >= 7,
                        'with-arrow': !currentMission && dataIsLoaded,
                       // 'skipMissionLabel': !currentMission
                      }"
                    >
                      7
                      <div class="skip-missions" v-if="!currentMission">
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
                        </div>გამოტოვე 1-7 მისიები
                      </div>
                    </div>
                    <div
                      :class="{
                        'step-button yell-bg': true,
                        'blue-bg': player.currentLevel >= 8,
                      }"
                    >8</div>
                    <div
                      :class="{
                        'step-button yell-bg': true,
                        'blue-bg': player.currentLevel >= 9,
                      }"
                    >9</div>
                    <div
                      :class="{
                        'step-button yell-bg': true,
                        'blue-bg': player.currentLevel >= 10,
                      }"
                    >10</div>
                    <div
                      :class="{
                        'step-button yell-bg': true,
                        'blue-bg': player.currentLevel >= 11,
                      }"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="15.754"
                        height="15.048"
                        viewBox="0 0 15.754 15.048"
                      >
                        <path
                          id="Path_3092"
                          data-name="Path 3092"
                          d="M239.688,294.312a1.964,1.964,0,0,0-1.617-1.332l-3.059-.4-1.327-2.762a1.977,1.977,0,0,0-3.556,0l-1.326,2.762-3.059.4a1.963,1.963,0,0,0-1.617,1.332,1.942,1.942,0,0,0,.518,2.021l2.239,2.1-.564,3.008a1.945,1.945,0,0,0,.779,1.937,1.98,1.98,0,0,0,2.1.135l2.71-1.461,2.711,1.461a1.98,1.98,0,0,0,2.1-.135,1.947,1.947,0,0,0,.779-1.937l-.565-3.008,2.24-2.1A1.942,1.942,0,0,0,239.688,294.312Zm-4.89,3.438.761,4.052-3.652-1.969-3.651,1.969.76-4.052L226,294.916l4.121-.535,1.786-3.721,1.787,3.721,4.121.535Z"
                          transform="translate(-224.03 -288.707)"
                          fill="#fff"
                        />
                      </svg>
                    </div>
                  </div>

                  <div class="progress-row">
                    <div class="progress" v-bind:style="{ width: progress + '%' }"></div>
                    <div class="status-box" v-bind:style="{ left: progress - 5 + '%' }">
                      <span class="coin"></span>
                      <div class="amount">{{ player.coins }}₾</div>
                    </div>

                    <div
                      :class="player.avatar ? 'moving-boy' : 'moving-girl'"
                      v-bind:style="{ left: progress - 9 + '%' }"
                    ></div>
                  </div>
                </div>
                <div data-v-28a1a439 class="release-btn">
                  <div data-v-28a1a439 class="icon">
                    <svg
                      data-v-28a1a439
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="14"
                      viewBox="0 0 16 14"
                    >
                      <g
                        data-v-28a1a439
                        id="Group_3663"
                        data-name="Group 3663"
                        transform="translate(-1392.033 -448)"
                      >
                        <path
                          data-v-28a1a439
                          id="Path_2737"
                          data-name="Path 2737"
                          d="M654,513H642a2.006,2.006,0,0,0-2,2v8a2.006,2.006,0,0,0,2,2h5a1,1,0,0,0,0-2h-5v-4h14v-4A2.006,2.006,0,0,0,654,513Zm0,4H642v-2h12Z"
                          transform="translate(752.033 -65)"
                          fill="#fff"
                        />
                        <path
                          data-v-28a1a439
                          id="Path_2738"
                          data-name="Path 2738"
                          d="M655,523h-1v-1a1,1,0,0,0-2,0v1h-1a1,1,0,0,0,0,2h1v1a1,1,0,0,0,2,0v-1h1a1,1,0,0,0,1-1v-1a1.871,1.871,0,0,1-.09.59A1,1,0,0,0,655,523Z"
                          transform="translate(752.033 -65)"
                          fill="#fff"
                        />
                        <path
                          data-v-28a1a439
                          id="Path_2739"
                          data-name="Path 2739"
                          d="M646,520h-1a1,1,0,0,0,0,2h2a1,1,0,0,0,0-2Z"
                          transform="translate(752.033 -65)"
                          fill="#fff"
                        />
                      </g>
                    </svg>
                  </div>
                  <span data-v-28a1a439>გაანაღდება</span>
                </div>
                <currentMission
                  :init.sync="init"
                  :currentmission="currentMission"
                  v-if="currentMission"
                ></currentMission>
                <startMission :init.sync="init" :onstart="getCurrentMission" v-else></startMission>
              </div>

              <div class="right-side">
                <div class="super-bonus">
                  <div class="txt-content">
                    <div class="sm-txt">სუპერ ბონუსი</div>
                    <div class="amount-txt">
                      {{ bonus }}
                      <span>₾</span>
                    </div>
                  </div>
                </div>
                <div class="rating-box">
                  <div class="title">რეიტინგი</div>
                  <div class="rating-list">
                    <div class="my-rate">
                      <div class="lf">
                        <div class="position">{{ leaderboard.you.place }}</div>
                        <div class="avatar">
                          <div
                            class="img"
                            :style="{
                              'background-image': leaderboard.you.avatar
                                ? `url('/img/boy.png')`
                                : `url('/img/girl.png')`,
                            }"
                          ></div>
                          <div class="txt">შენ</div>
                        </div>
                      </div>
                      <div class="points">{{ leaderboard.you.coins }}</div>
                    </div>
                    <div class="others">
                      <perfect-scrollbar>
                        <div
                          class="user-item"
                          v-for="player in leaderboard.others"
                          :key="player.place"
                        >
                          <div class="lf">
                            <div class="position">{{ player.place }}</div>
                            <div class="avatar">
                              <div
                                class="img"
                                :style="{
                                  'background-image': player.avatar
                                    ? `url('/img/boy.png')`
                                    : `url('/img/girl.png')`,
                                }"
                              ></div>
                              <div class="txt">{{ player.name }}</div>
                            </div>
                          </div>
                          <div class="points">{{ player.coins }}</div>
                        </div>
                      </perfect-scrollbar>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <modal name="notification" class="si__style-pop">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="closeModal()">
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
            <!-- <h5>შეტყობინება</h5> -->
            <div class="icon" v-if="notification ? notification.type == 0 : false">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="85.682"
                height="85.682"
                viewBox="0 0 85.682 85.682"
              >
                <g id="Group_3663" data-name="Group 3663" transform="translate(-68.192 -3.159)">
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
            <h3>{{notification ? notification.title : ""}}</h3>
            <p>{{notification ?notification.description : ""}}</p>
          </div>
        </div>
      </div>
    </modal>

  </div>
</template>
<script>
import DHeader from "../inc/dashboard_header";
import currentMission from "./currentMission";
import startMission from "./startMission";
import { PerfectScrollbar } from "vue2-perfect-scrollbar";
import request from "@/Request";

import Vue from "vue";
import VModal from "vue-js-modal";

Vue.use(VModal);

export default {
  name: "LogedInMain",
  data: function() {
    return {
      progress: 0,
      dataIsLoaded: false,
      currentMission: null,
      bonus: 0,
      player: {
        avatar: 1,
        coins: 0,
        currentLevel: 0
      },
      leaderboard: {
        you: {
          coins: 115,
          avatar: 0,
          name: "player",
          place: 1
        },
        others: [
          {
            coins: 115,
            avatar: 1,
            name: "p*****r",
            place: 1
          }
        ]

      },
      notification: null,
    };
  },
  methods: {
    closeModal(){
      this.$modal.hide("notification");
    },
    getNotifications() {
      var self = this;
      request({
        url: "api/notifications/new",
        method: "get"
      })
        .then(function(response) {
          self.notification = response.data;
          if(self.notification)
              self.$modal.show("notification");
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    init() {
      let self = this;
      self.getCurrentMission();
      request({
        url: "api/Bonus/Current",
        method: "get"
      })
        .then(function(response) {
          console.log(response);
          self.bonus = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });

      request({
        url: "api/account/UserInfo",
        method: "get"
      })
        .then(function(response) {
          console.log(response);
          self.player = response.data;
          self.calculateProgress(self.player.currentLevel);
        })
        .catch(function(error) {
          console.log(error);
        });

      request({
        url: "/api/players/Leaderboard?quantity=10",
        method: "get"
      })
        .then(function(response) {
          console.log(response);
          self.leaderboard = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    calculateProgress(lvl) {
      let self = this;
      switch (lvl) {
        case 1:
          self.progress = 5;
          break;
        case 2:
          self.progress = 11;
          break;
        case 3:
          self.progress = 23;
          break;
        case 4:
          self.progress = 32;
          break;
        case 5:
          self.progress = 41;
          break;
        case 6:
          self.progress = 50;
          break;
        case 7:
          self.progress = 59;
          break;
        case 8:
          self.progress = 68;
          break;
        case 9:
          self.progress = 77;
          break;
      }
      console.log(lvl, self.progress);
    },
    getCurrentMission() {
      var self = this;
      request({
        url: "api/game/currentMission",
        method: "get"
      })
        .then(function(response) {
          console.log(response);
          self.currentMission = response.data;
          self.dataIsLoaded = true;
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  },
  components: {
    "d-header": DHeader,
    PerfectScrollbar,
    currentMission,
    startMission
  },
  mounted: function() {
    this.init();
    this.getNotifications();
  }
};
</script>
<style src="vue2-perfect-scrollbar/dist/vue2-perfect-scrollbar.css" />
