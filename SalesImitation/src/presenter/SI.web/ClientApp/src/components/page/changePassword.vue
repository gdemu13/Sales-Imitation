<template>

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
                    <router-link :to="`/${$i18n.locale}/editProfile`">
                      <span>პროფილის რედაქტირება</span>
                    </router-link>
                  </li>
                  <li>
                    <router-link
                      :to="`/${$i18n.locale}/changePassword`"
                      class="active"
                    >
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
                  <h3>
                    პაროლის შეცვლა
                  </h3>
                </div>
                <div class="edit-content">
                  <div class="edit-side">
                    <form action>
                      <div
                        :class="{
                          'input-item': true,
                          'db-item': true,
                          error:
                            submitted &&
                            $v.changePassModel.currentPassword.$error,
                        }"
                      >
                        <label for>მიმდინარე პაროლი</label>
                        <div
                          class="eye-icon"
                          @click="toggleShowPass('SetPass')"
                        >
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="16.001"
                            height="10"
                            viewBox="0 0 16.001 10"
                          >
                            <path
                              id="Eye"
                              d="M1.249,8.31Q4.83,4,9,4t7.751,4.31a1.08,1.08,0,0,1,0,1.38Q13.17,14,9,14T1.249,9.69a1.08,1.08,0,0,1,0-1.38ZM9,12.5A3.5,3.5,0,1,0,5.5,9,3.5,3.5,0,0,0,9,12.5Zm0-1A2.5,2.5,0,1,1,11.5,9,2.5,2.5,0,0,1,9,11.5Z"
                              transform="translate(-0.999 -4)"
                              fill="#c0c8d7"
                              fill-rule="evenodd"
                            />
                          </svg>
                        </div>
                        <input
                          :type="SetPass ? 'password' : 'text'"
                          v-model="changePassModel.currentPassword"
                        />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted &&
                                !$v.changePassModel.currentPassword.required
                            "
                          >
                            მოცემული ველი აუცილებელია
                          </div>
                        </div>
                      </div>

                      <div
                        :class="{
                          'input-item': true,
                          'db-item': true,
                          error:
                            submitted && $v.changePassModel.newPassword.$error,
                        }"
                        style="margin-right: 0"
                      >
                        <div
                          class="eye-icon"
                          @click="toggleShowPass('ConfirmPass')"
                        >
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="16.001"
                            height="10"
                            viewBox="0 0 16.001 10"
                          >
                            <path
                              id="Eye"
                              d="M1.249,8.31Q4.83,4,9,4t7.751,4.31a1.08,1.08,0,0,1,0,1.38Q13.17,14,9,14T1.249,9.69a1.08,1.08,0,0,1,0-1.38ZM9,12.5A3.5,3.5,0,1,0,5.5,9,3.5,3.5,0,0,0,9,12.5Zm0-1A2.5,2.5,0,1,1,11.5,9,2.5,2.5,0,0,1,9,11.5Z"
                              transform="translate(-0.999 -4)"
                              fill="#c0c8d7"
                              fill-rule="evenodd"
                            />
                          </svg>
                        </div>
                        <label for>გაიმეორეთ პაროლი</label>
                        <input
                          :type="ConfirmPass ? 'password' : 'text'"
                          v-model="changePassModel.newPassword"
                        />
                        <div class="sub-info-row">
                          <div
                            class="error-txt"
                            v-if="
                              submitted &&
                                !$v.changePassModel.newPassword.required
                            "
                          >
                             მოცემული ველი აუცილებელია და უნდა შედგებოდეს მინ. 6 სიმბოლოსგან
                          </div>
                        </div>
                      </div>
                    </form>
                  </div>
                  <div class="save-side">
                    <div class="btn-row">
                      <div class="btn-item" @click="resetData()">
                        გაუქმება
                      </div>
                      <div
                        class="btn-item save"
                        @click="changePasswordSubmit()"
                      >
                        შენახვა
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
            <h5>
              შეტყობინება
            </h5>

            <p>
                {{responseAlert}}
            </p>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>
<script>
import Vue from "vue";
import Vuelidate from "vuelidate";
import axios from "axios";
import VModal from "vue-js-modal";
import { required, minLength } from "vuelidate/lib/validators";
Vue.use(Vuelidate);
Vue.use(VModal);

export default {
  name: "ChangePassword",
  components: {
  },
  data: function() {
    return {
      SetPass: true,
      ConfirmPass: true,
      responseAlert: "",
      changePassModel: {
        newPassword: "",
        currentPassword: "",
      },
      submitted: false,
    };
  },
  validations: {
    changePassModel: {
      newPassword: {
        required,
        minLength: minLength(6),
      },
      currentPassword: {
        required,
        minLength: minLength(6),
      },
    },
  },
  methods: {
    hideModal() {
         this.$modal.hide("infoPop");
    },
    toggleShowPass: function(name) {
      switch (name) {
        case "SetPass":
          this.SetPass = !this.SetPass;
          break;
        case "ConfirmPass":
          this.ConfirmPass = !this.ConfirmPass;
          break;
      }
    },
    resetData() {
       this.changePassModel.newPassword = "";
       this.changePassModel.currentPassword = ""
    },
    changePasswordSubmit() {
      var self = this;
      self.submitted = true;

      self.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }
      axios
        .post("/api/account/ChangePassword", self.changePassModel)
        .then(function(response) {
          console.log("reg", response);
          if (response.data.isSuccess) {
            self.responseAlert = response.data.message;
            self.$modal.show("infoPop");
            self.changePassModel.newPassword = "";
            self.changePassModel.currentPassword = ""
          } else {
            self.responseAlert = response.data.message;
            self.$modal.show("infoPop");
              self.changePassModel.newPassword = "";
            self.changePassModel.currentPassword = ""
          }
        })
        .catch(function(error) {
          console.log(error);
        });
    },
  },
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
  margin-bottom: 15px;
}
.content-view .title-row h3 {
  color: #fff;
  font-size: 20px;
  font-family: "helv-65";
}
.edit-side {
  width: 100%;
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
  width: 100%;
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
