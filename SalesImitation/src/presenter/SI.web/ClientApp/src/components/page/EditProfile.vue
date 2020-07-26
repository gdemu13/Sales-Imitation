<template>
  <div class="general-page-wrapper">
    <div class="page-content-wrapper">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="content-wrapper">
              <div class="sidebar-menu">
                <ul>
                  <li>
                    <a href="#">
                      <span>ისტორია</span>
                    </a>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/editProfile`" class="active">
                      <span>პროფილის რედაქტირება</span>
                    </router-link>
                  </li>
                  <li>
                    <router-link :to="`/${$i18n.locale}/changePassword`">
                      <span>პაროლის შეცვლა</span>
                    </router-link>
                  </li>
                  <li>
                    <a href="#">
                      <span>ჩემი მისიები</span>
                    </a>
                  </li>
                  <li>
                    <a href="#">
                      <span>წესები და პირობები</span>
                    </a>
                  </li>
                </ul>
              </div>
              <div class="content-view">
                <div class="title-row">
                  <h3>პროფილის რედაქტირება</h3>
                </div>
                <div class="edit-content">
                  <div class="edit-side">
                    <form action>
                      <div
                        :class="{
                          'input-item': true,
                          'db-item-short': true,
                          error:
                            submitted && $v.editProfileModel.firstname.$error,
                        }"
                      >
                        <label for>სახელი</label>
                        <input type="text" name id v-model="editProfileModel.firstname" />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted &&
                                !$v.editProfileModel.firstname.required
                            "
                          >მოცემული ველი აუცილებელია</div>
                        </div>
                      </div>
                      <div
                        :class="{
                          'input-item': true,
                          'db-item-short': true,
                          error:
                            submitted && $v.editProfileModel.lastname.$error,
                        }"
                        style="margin-right: 0;"
                      >
                        <label for>გვარი</label>
                        <input type="text" name id v-model="editProfileModel.lastname" />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted &&
                                !$v.editProfileModel.lastname.required
                            "
                          >მოცემული ველი აუცილებელია</div>
                        </div>
                      </div>

                      <div
                        :class="{
                          'input-item': true,
                          'db-item': true,
                          error: submitted && $v.editProfileModel.mail.$error,
                        }"
                      >
                        <label for>ელ. ფოსტა</label>
                        <input type="email" name id v-model="editProfileModel.mail" />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted && !$v.editProfileModel.mail.required
                            "
                          >მოცემული ველი აუცილებელია</div>
                        </div>
                      </div>

                      <div
                        :class="{
                          'input-item': true,
                          'db-item': true,
                          error: submitted && $v.editProfileModel.phone.$error,
                        }"
                        style="margin-right: 0;"
                      >
                        <label for>ტელეფონი</label>
                        <input type="tel" name id v-model="editProfileModel.phone" />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted && !$v.editProfileModel.phone.required
                            "
                          >მოცემული ველი აუცილებელია</div>
                        </div>
                      </div>
                      <!--
                      <div
                        :class="{
                          'input-item': true,
                          error: submitted && $v.editProfileModel.username.$error,
                        }"
                      >
                        <label for>მომხმარებლის სახელი</label>
                        <input
                          type="text"
                          name
                          id
                          v-model="editProfileModel.username"
                        />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted &&
                                !$v.editProfileModel.username.required
                            "
                          >
                            მოცემული ველი აუცილებელია
                          </div>
                        </div>
                      </div>-->

                      <div class="choose-avatar">
                        <div class="label-item">აირჩიეთ ავატარი</div>
                        <div class="avatar-item">
                          <div class="pretty p-svg p-curve">
                            <input type="checkbox" v-model="gender.girl" @click="setAavatar()" />
                            <div class="state p-success">
                              <svg class="svg svg-icon" viewBox="0 0 20 20">
                                <path
                                  d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                  style="stroke: white;fill:white;"
                                />
                              </svg>
                              <label></label>
                            </div>
                            <div class="avatar-img">
                              <div class="img-item" style="background-image: url('/img/boy.png')"></div>
                            </div>
                          </div>
                        </div>

                        <div class="avatar-item">
                          <div class="pretty p-svg p-curve">
                            <input type="checkbox" v-model="gender.boy" @click="setAavatar()" />
                            <div class="state p-success">
                              <svg class="svg svg-icon" viewBox="0 0 20 20">
                                <path
                                  d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                  style="stroke: white;fill:white;"
                                />
                              </svg>
                              <label></label>
                            </div>
                            <div class="avatar-img">
                              <div class="img-item" style="background-image: url('/img/girl.png')"></div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </form>
                  </div>
                  <div class="save-side">
                    <div class="icon">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="313"
                        height="313"
                        viewBox="0 0 313 313"
                      >
                        <path
                          id="Path_2989"
                          data-name="Path 2989"
                          d="M284.5,352C198.21,352,128,422.21,128,508.5a157.409,157.409,0,0,0,74.044,132.908l.254.215.156.078.137.1a156.2,156.2,0,0,0,164.11-.176C412.419,613.551,441,562.473,441,508.5,441,422.21,370.79,352,284.5,352Zm0,273.875a115.373,115.373,0,0,1-61.426-17.411,97.74,97.74,0,0,1,122.852,0A115.374,115.374,0,0,1,284.5,625.875ZM245.375,508.5A39.125,39.125,0,1,1,284.5,547.625,39.114,39.114,0,0,1,245.375,508.5Zm129.719,74.22a38.508,38.508,0,0,0-4.676-4.774,137.57,137.57,0,0,0-28.248-17,78.251,78.251,0,1,0-115.34,0,137.572,137.572,0,0,0-28.248,17,38.492,38.492,0,0,0-4.675,4.774,117.376,117.376,0,1,1,181.188,0Z"
                          transform="translate(-128 -352)"
                          fill="#1f2242"
                          opacity="0.2"
                        />
                      </svg>
                    </div>

                    <div class="btn-row">
                      <div class="btn-item" @click="resetData()">გაუქმება</div>
                      <div class="btn-item save" @click="submitEditProfile()">შენახვა</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
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

            <p>{{ responseAlert }}</p>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>
<script>
import Vue from "vue";

import Vuelidate from "vuelidate";
import { required, email, minLength } from "vuelidate/lib/validators";
import request from "@/Request";
Vue.use(Vuelidate);
//Vue.use(VModal);
export default {
  name: "EditProfile",
  components: {},
  data: function() {
    return {
      responseAlert: "",
      editProfileModel: {
        firstname: "",
        lastname: "",
        phone: "",
        avatar: 1,
        mail: ""
      },
      gender: {
        girl: true,
        body: false
      },
      submitted: false
    };
  },
  validations: {
    editProfileModel: {
      firstname: {
        required,
        minLength: minLength(2)
      },
      lastname: {
        required
      },
      phone: {
        required
      },
      mail: {
        required,
        email
      }
    }
  },
  methods: {
    hideModal() {
      this.$modal.hide("infoPop");
    },
    setAavatar() {
      if (this.gender.girl) {
        this.gender.girl = false;
        this.gender.boy = true;
        this.registerModel.avatar = 0;
      } else {
        this.gender.girl = true;
        this.gender.boy = false;
        this.registerModel.avatar = 1;
      }
    },
    resetData() {
      this.editProfileModel.firstname = "";
      this.editProfileModel.lastname = "";
      this.editProfileModel.phone = "";
      this.editProfileModel.mail = "";
    },
    getCurrentData() {
      var self = this;

      request({
        url: "/api/account/UserInfo",
        method: "get"
      })
        .then(function(response) {
          self.editProfileModel.firstname = response.data.firstname;
          self.editProfileModel.lastname = response.data.lastname;
          self.editProfileModel.avatar = response.data.avatar;
          self.editProfileModel.mail = response.data.mail;
          self.editProfileModel.phone = response.data.phone;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    submitEditProfile() {
      var self = this;
      self.submitted = true;

      self.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }

      request({
        url: "/api/account/UpdateInfo",
        method: "post",
        data: self.editProfileModel
      })
        .then(function(response) {
          self.submitted = false;
          if (response.data.isSuccess) {
            self.$modal.show("infoPop");
            self.responseAlert = response.data.message;
            self.resetData();
          } else {
            self.responseAlert = response.data.message;
            self.resetData();
          }
          self.getCurrentData();
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  },
  mounted: function() {
    this.getCurrentData();
  }
};
</script>

<style scoped>
.sidebar-menu {
  width: 310px;
  float: left;
  background: #2b305a;
  border-radius: 15px;
}
.sidebar-menu ul {
  padding: 25px;
  margin: 0;
  list-style: none;
}
.sidebar-menu ul li {
  margin-bottom: 20px;
}
.sidebar-menu ul li:last-child {
  margin: 0;
}
.sidebar-menu ul li a {
  color: #6a6d8b;
  font-size: 14px;
  font-family: "helv-65";
  text-decoration: none;
  padding-left: 10px;
  position: relative;
  transition: all 0.3s;
  width: 100%;
  display: inline-block;
}
.sidebar-menu ul li a.active {
  color: #fff;
}
.sidebar-menu ul li a span {
  position: relative;
  z-index: 1;
}
.sidebar-menu ul li a:before {
  content: "";
  position: absolute;
  top: -14px;
  left: -25px;
  background: #2f82fc;
  height: 50px;
  width: 256px;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  transition: all 0.3s;
  opacity: 0;
  visibility: hidden;
}
.sidebar-menu ul li a.active:before {
  opacity: 1;
  visibility: visible;
  transition: all 0.3s;
}

.sidebar-menu ul li a:hover {
  color: #fff;
  transition: all 0.3s;
}
.content-view {
  background: #2c315b;
  border-radius: 15px;
  width: calc(100% - 330px);
  float: right;
  height: auto;
  min-height: 500px;
  padding: 30px;
}
.content-view .title-row {
  display: inline-block;
  width: 100%;
  margin-bottom: 10px;
}
.content-view .title-row h3 {
  color: #fff;
  font-size: 20px;
  font-family: "helv-65";
}
.edit-side {
  width: 50%;
  float: left;
}
.edit-side .input-item.error input {
  color: #ff0000;
  font-size: 14px;
  font-family: "helv-65";
  border-color: #ff0000;
}

.edit-side .input-item.error .error-txt {
  color: #ff0000;
  font-size: 14px;
  font-family: "helv-65";
}

.edit-side .input-item.success input {
  color: #169825;
  font-size: 14px;
  font-family: "helv-65";
  border-color: #169825;
}

.edit-side .input-item.success input::placeholder {
  color: #bbbfcd;
}

.edit-side .input-item .sub-info-row {
  display: flex;
  align-items: baseline;
  justify-content: space-between;
  margin-top: 8px;
}

.edit-side .input-item .sub-info-row .logwith-sms {
  color: #3285ff;
  font-size: 14px;
  font-family: "helv-65";
  cursor: pointer;
}

.edit-side .input-item .sub-info-row .save-pass {
  display: flex;
  align-items: center;
}

.edit-side .input-item .sub-info-row .save-pass .pretty.p-svg .state .svg {
  top: 0;
  width: calc(1em + 0px);
}

.edit-side .pretty .state label:after,
.edit-side .pretty .state label:before {
  top: 1px;
  border: none;
  background: #edeef0;
}

.edit-side .pretty input:checked ~ .state.p-success label:after,
.edit-side .pretty.p-toggle .state.p-success label:after {
  background-color: #3285ff !important;
}

.edit-side .input-item .sub-info-row .save-pass .pretty label span {
  display: inline;
  position: relative;
  left: 5px;
}

.edit-side .pretty.p-curve .state label:after,
.edit-side .pretty.p-curve .state label:before {
  border-radius: 30%;
}

.edit-side .input-item.db-item {
  margin-right: 20px;
  float: left;
}

.edit-side .input-item.db-item-short {
  width: calc(100% / 2 - 10px);
  margin-right: 20px;
  float: left;
}

.edit-side .choose-avatar {
  display: inline-block;
  width: 100%;
  margin-top: 0;
}

.edit-side .choose-avatar .label-item {
  display: inline-block;
  width: 100%;
  color: #fff;
  font-family: "helv-65";
  font-size: 14px;
  margin-bottom: 15px;
}

.edit-side .choose-avatar .avatar-item {
  width: 125px;
  float: left;
  display: flex;
  margin-right: 8px;
}

.edit-side .choose-avatar .avatar-item .avatar-img {
  width: 80px;
  height: 80px;
  background: #edeef0;
  border-radius: 15px;
}
.edit-side .choose-avatar .avatar-item svg * {
  fill: #c0c8d7 !important;
}
.edit-side .choose-avatar .avatar-item .avatar-img .img-item {
  width: 80px;
  height: 80px;
  background-size: contain;
  background-position: center;
  margin: 0 auto;
}

.edit-side .choose-avatar .avatar-item .pretty {
  display: flex;
  align-items: center;
  margin: 0;
}

.edit-side .choose-avatar .avatar-item .pretty input {
  cursor: pointer;
  width: 105px;
}

.edit-side .choose-avatar .avatar-item .pretty .state {
  position: absolute;
  right: -30px;
}

.edit-side .choose-avatar .avatar-item .pretty .state svg {
  top: 1px;
}

.edit-side
  .choose-avatar
  .avatar-item
  .pretty.p-svg
  input:checked
  ~ .avatar-img {
  background: #3285ff;
}
.edit-side .input-item {
  display: inline-block;
  width: 100%;
  margin-bottom: 15px;
  position: relative;
}

.edit-side .input-item .eye-icon {
  position: absolute;
  right: 15px;
  top: 42.5px;
  cursor: pointer;
}

.edit-side .input-item label {
  display: inline-block;
  width: 100%;
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
}

.edit-side .input-item input {
  width: 100%;
  height: 50px;
  border-radius: 15px;
  border: none;
  background: #1f2242;
  padding-left: 15px;
  font-size: 14px;
  border: 2px solid transparent;
  color: #fff;
  font-family: "helv-65";
}

.edit-side .input-item input:focus {
  outline: none;
}
.edit-content .save-side .btn-row {
  display: inline-block;
  width: 100%;
  margin-top: 75px;
  text-align: right;
}
.edit-content .save-side {
  width: 50%;
  float: right;
}
.edit-content .save-side .icon {
  display: flex;
  width: 100%;
  padding: 40px;
  align-items: center;
  justify-content: center;
}
.edit-content .save-side .icon svg {
  width: 80%;
}
.edit-content .save-side .btn-item {
  display: inline-flex;
  background: #1f2242;
  margin-left: 10px;
  padding: 15px 30px;
  border-radius: 10px;
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
  cursor: pointer;
  transition: all 0.3s;
}
.edit-content .save-side .btn-row .btn-item:hover {
  opacity: 0.8;
  transition: all 0.3s;
}
.edit-content .save-side .btn-row .btn-item.save {
  background: #3285ff;
}
</style>
