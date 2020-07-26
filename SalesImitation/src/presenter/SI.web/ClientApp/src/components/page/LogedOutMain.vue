<template>
  <div class="logout-full">
    <div
      class="fb-login-button"
      data-scope="public_profile,email,user_birthday"
      data-size="large"
      data-button-type="continue_with"
      data-layout="default"
      data-auto-logout-link="false"
      data-use-continue-as="false"
      data-width
    ></div>

    <kinesis-container>
      <div class="full-screen-view" id="full-screen-view">
        <div class="header-navbar">
          <div class="container">
            <div class="row">
              <div class="col-md-12">
                <div class="nav-bar-in">
                  <div class="lf-side">
                    <div class="logo">
                      <h1>
                        <img src="/img/logo-white.svg" alt="si.ge logo" />
                      </h1>
                    </div>
                    <div class="menu-item">
                      <ul>
                        <li class="active">
                          <router-link :to="`/${$i18n.locale}`">მთავარი</router-link>
                        </li>
                        <li>
                          <router-link :to="`/${$i18n.locale}/about`">ჩვენ შესახებ</router-link>
                        </li>
                        <li>
                          <router-link :to="`/${$i18n.locale}/gameRules`">თამაშის წესები</router-link>
                        </li>
                        <li>
                          <router-link :to="`/${$i18n.locale}/faq`">FAQ</router-link>
                        </li>
                        <li>
                          <router-link :to="`/${$i18n.locale}/contact`">კონტაქტი</router-link>
                        </li>
                      </ul>
                    </div>
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
                      <img src="/img/logoMobile.png" alt />
                    </div>
                  </div>

                  <div class="right-nav">
                    <div class="login-btn" @click="RegLogModalShow">
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
                      </div>
                      <div class="txt">შესვლა</div>
                    </div>

                    <!-- <div class="lang-switcher">
                      <ol>
                        <li>
                          <a href="#" @click.prevent="setLocale('ka')">ქარ</a>
                        </li>
                        <li>
                          <a href="#" @click.prevent="setLocale('en')">Eng</a>
                        </li>
                      </ol>
                    </div>-->
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="caption-item">
          <div class="sub-title">მხოლოდ ჩვენთან</div>
          <div class="main-title">გაყიდე და მიიღე უამრავი ბონუსი</div>
          <div class="btn-control">
            <div class="btn-item" @click="startGame">
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
              <div class="txt">დაიწყე</div>
            </div>
            <div class="btn-item" @click="showModal('videoModal')">
              <div class="icon-play">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="11.441"
                  height="12.938"
                  viewBox="0 0 11.441 12.938"
                >
                  <path
                    id="Path_3223"
                    data-name="Path 3223"
                    d="M614.51,194.634l4.852,8.172h-9.7l4.852-8.172m0-1.634a1.614,1.614,0,0,0-1.387.793l-4.852,8.172a1.647,1.647,0,0,0-.02,1.646,1.614,1.614,0,0,0,1.407.829h9.7a1.614,1.614,0,0,0,1.407-.829,1.649,1.649,0,0,0-.02-1.646l-4.852-8.172A1.615,1.615,0,0,0,614.51,193Z"
                    transform="translate(204.441 -608.041) rotate(90)"
                    fill="#fff"
                  />
                </svg>
              </div>
              <div class="txt">ნახე ვიდეო</div>
            </div>
          </div>
        </div>

        <!-- <div class="caption-item promo-code">
          <div class="main-title">
            შეიყვანე <br />
            მონაწილის კოდი
          </div>
          <div class="btn-control">
            <div class="btn-item">
              <div class="label">შეიყვანეთ 6 ნიშნა კოდი</div>
              <input type="text" />
            </div>
            <div class="btn-item check" @click="showModal()">
              <div class="txt">შემოწმება</div>
            </div>
          </div>
        </div>-->

        <div class="right-color"></div>
        <kinesis-element axis="x" :strength="30">
          <div class="bgfull-image"></div>
        </kinesis-element>
        <div class="shape-item"></div>
        <div class="people-moveing"></div>
        <img src="/img/bg.png" class="mobile-main-image" />
      </div>
    </kinesis-container>

    <div class="fullscreenMenuMobile" :class="{ active: mobileMenu }">
      <ul>
        <li class="active">
          <router-link :to="`/${$i18n.locale}`">მთავარი</router-link>
        </li>
        <li>
          <router-link :to="`/${$i18n.locale}/about`">ჩვენ შესახებ</router-link>
        </li>
        <li>
          <router-link :to="`/${$i18n.locale}/gameRules`">თამაშის წესები</router-link>
        </li>
        <li>
          <router-link :to="`/${$i18n.locale}/faq`">FAQ</router-link>
        </li>
        <li>
          <router-link :to="`/${$i18n.locale}/contact`">კონტაქტი</router-link>
        </li>
      </ul>
    </div>

    <modal name="videoModal" class="si__style-pop videoModal">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('videoModal')">
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
        <div class="video-content">
          <video
            autoplay
            width="100%"
            height="100%"
            controls
            ref="video"
            class="instructions-video"
          >
            <source src="/img/video.mp4" type="video/mp4" id="myVideo" />Your browser does not support the video tag.
          </video>
        </div>
      </div>
    </modal>

    <modal name="RegLogModal" class="si__style-pop RegLogModal">
      <div class="modal-content-item">
        <div class="close-btn" @click="RegLogModalHide">
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
        <div class="auth-content">
          <tabs :show.sync="showReg">
            <template>
              <div class="my-items">
                <a
                  href="#"
                  :class="{ 'my-item': true, active: showReg === 0 }"
                  @click.prevent="showReg = 0"
                >შესვლა</a>
                <a
                  href="#"
                  :class="{ 'my-item': true, active: showReg === 1 }"
                  @click.prevent="showReg = 1"
                >რეგისტრაცია</a>
              </div>
            </template>
            <tab title="შესვლა">
              <form action>
                <div
                  :class="
                    loginResponse.errorText ? 'input-item error' : 'input-item'
                  "
                >
                  <label for>მომხმარებელი</label>

                  <input type="text" name id v-model="loginModel.userName" />

                  <div class="sub-info-row">
                    <div
                      v-if="loginResponse.errorText"
                      class="error-txt"
                    >{{ loginResponse.errorText }}</div>

                    <!-- <div class="logwith-sms">SMS-ით შესვლა</div> -->
                  </div>
                </div>

                <div
                  :class="
                    loginResponse.errorText ? 'input-item error' : 'input-item'
                  "
                >
                  <label for>პაროლი</label>

                  <input
                    :type="LogPass ? 'password' : 'text'"
                    name
                    id
                    v-model="loginModel.password"
                  />

                  <div class="eye-icon" @click="toggleShowPass('LogPass')">
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
                  <div class="sub-info-row">
                    <div class="save-pass">
                      <div class="pretty p-svg p-curve">
                        <input type="checkbox" v-model="loginModel.stayLogedIn" />
                        <div class="state p-success">
                          <svg class="svg svg-icon" viewBox="0 0 20 20">
                            <path
                              d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                              style="stroke: white;fill:white;"
                            />
                          </svg>
                          <label>
                            <span>დამახსოვრება</span>
                          </label>
                        </div>
                      </div>
                    </div>
                    <div class="logwith-sms">პაროლის აღდგენა</div>
                  </div>
                </div>
                <div @click="submitLogin()" class="sb-button">შესვლა</div>
                <div class="info-text-row">
                  <p>ან გაიარეთ ავტორიზაცია სოციალური ქსელებით</p>

                  <div class="socials">
                    <a href="#">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="40"
                        height="40"
                        viewBox="0 0 40 40"
                      >
                        <g id="Group_3666" data-name="Group 3666" transform="translate(-135 -594)">
                          <rect
                            id="Rectangle_1278"
                            data-name="Rectangle 1278"
                            width="40"
                            height="40"
                            rx="20"
                            transform="translate(135 594)"
                            fill="#4568b2"
                          />
                          <g id="facebook-logo" transform="translate(200.394 603.861)">
                            <path
                              id="Path_211"
                              data-name="Path 211"
                              d="M32.691,0,30.046,0a4.646,4.646,0,0,0-4.893,5.02V7.335h-2.66a.416.416,0,0,0-.416.416v3.354a.416.416,0,0,0,.416.416h2.66v8.463a.416.416,0,0,0,.416.416h3.47a.416.416,0,0,0,.416-.416V11.521h3.11a.416.416,0,0,0,.416-.416V7.751a.416.416,0,0,0-.416-.416H29.455V5.373c0-.943.225-1.422,1.453-1.422h1.782a.416.416,0,0,0,.416-.416V.42A.416.416,0,0,0,32.691,0Z"
                              transform="translate(-73)"
                              fill="#fff"
                            />
                          </g>
                        </g>
                      </svg>
                    </a>
                    <a href="#">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="40"
                        height="40"
                        viewBox="0 0 40 40"
                      >
                        <g id="Group_585" data-name="Group 585" transform="translate(-196 -594)">
                          <g id="search" transform="translate(204.771 602.771)">
                            <path
                              id="Path_207"
                              data-name="Path 207"
                              d="M4.977,145.774,4.2,148.693l-2.857.06a11.248,11.248,0,0,1-.083-10.485h0l2.544.466,1.114,2.528a6.7,6.7,0,0,0,.063,4.512Z"
                              transform="translate(0 -132.203)"
                              fill="#fbbb00"
                            />
                            <path
                              id="Path_208"
                              data-name="Path 208"
                              d="M272.413,208.176a11.224,11.224,0,0,1-4,10.854h0l-3.2-.163-.453-2.831a6.692,6.692,0,0,0,2.879-3.417h-6v-4.442h10.785Z"
                              transform="translate(-250.153 -199.045)"
                              fill="#518ef8"
                            />
                            <path
                              id="Path_209"
                              data-name="Path 209"
                              d="M47.428,315.822h0a11.232,11.232,0,0,1-16.92-3.435l3.639-2.979a6.678,6.678,0,0,0,9.623,3.419Z"
                              transform="translate(-29.171 -295.838)"
                              fill="#28b446"
                            />
                            <path
                              id="Path_210"
                              data-name="Path 210"
                              d="M45.764,2.585,42.127,5.563a6.677,6.677,0,0,0-9.844,3.5L28.625,6.065h0a11.231,11.231,0,0,1,17.14-3.48Z"
                              transform="translate(-27.369)"
                              fill="#f14336"
                            />
                          </g>
                          <g
                            id="Rectangle_1278"
                            data-name="Rectangle 1278"
                            transform="translate(196 594)"
                            fill="none"
                            stroke="#dfe3e9"
                            stroke-width="1"
                          >
                            <rect width="40" height="40" rx="20" stroke="none" />
                            <rect x="0.5" y="0.5" width="39" height="39" rx="19.5" fill="none" />
                          </g>
                        </g>
                      </svg>
                    </a>
                  </div>
                </div>
              </form>
            </tab>
            <tab title="რეგისტრაცია">
              <div class="reg-content">
                <form action>
                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error: submitted && $v.registerModel.firstname.$error,
                    }"
                  >
                    <label for>სახელი</label>
                    <input
                      type="text"
                      name="firstname"
                      id="firstname"
                      v-model="registerModel.firstname"
                    />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.firstname.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error: submitted && $v.registerModel.lastname.$error,
                    }"
                    style="margin-right: 0;"
                  >
                    <label for>გვარი</label>
                    <input
                      type="text"
                      name="lastname"
                      id="lastname"
                      v-model="registerModel.lastname"
                    />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.lastname.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error: submitted && $v.registerModel.mail.$error,
                    }"
                  >
                    <label for>ელ. ფოსტა</label>
                    <input type="email" name="email" id="email" v-model="registerModel.mail" />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.mail.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error: submitted && $v.registerModel.phone.$error,
                    }"
                    style="margin-right: 0;"
                  >
                    <label for>ტელეფონი</label>
                    <input type="tel" name id v-model="registerModel.phone" />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.phone.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      error: submitted && $v.registerModel.username.$error,
                    }"
                  >
                    <label for>მომხმარებლის სახელი</label>
                    <input type="text" name id v-model="registerModel.username" />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.username.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error: submitted && $v.registerModel.password.$error,
                    }"
                  >
                    <label for>პაროლი</label>
                    <div class="eye-icon" @click="toggleShowPass('SetPass')">
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
                      name
                      id
                      v-model="registerModel.password"
                    />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="submitted && !$v.registerModel.password.required"
                      >მოცემული ველი აუცილებელია</div>
                    </div>
                  </div>

                  <div
                    :class="{
                      'input-item': true,
                      'db-item': true,
                      error:
                        submitted && $v.registerModel.confirmPassword.$error,
                    }"
                    style="margin-right: 0;"
                  >
                    <div class="eye-icon" @click="toggleShowPass('ConfirmPass')">
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
                      name
                      id
                      v-model="registerModel.confirmPassword"
                    />
                    <div class="sub-info-row">
                      <div
                        class="error-txt"
                        v-if="
                          submitted &&
                            !$v.registerModel.confirmPassword.sameAsPassword
                        "
                      >პაროლები უნდა ემთხვეოდნენ</div>
                    </div>
                  </div>

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

                  <div class="term-cond">
                    <div class="pretty p-svg p-curve">
                      <input type="checkbox" />
                      <div class="state p-success">
                        <svg class="svg svg-icon" viewBox="0 0 20 20">
                          <path
                            d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                            style="stroke: white;fill:white;"
                          />
                        </svg>
                        <label>
                          <span>ვეთანხმები</span>
                        </label>
                      </div>
                    </div>
                    <a href="#" @click="showModal('termsConditions')">წესებსა და პირობებს</a>
                  </div>
                  <div class="sb-button" @click="submitRegister()">რეგისტრაცია</div>
                  <div class="info-text-row">
                    <p>ან გაიარეთ ავტორიზაცია სოციალური ქსელებით</p>
                    <div class="socials">
                      <!-- <facebook-login
                        class="button"
                        appId="941695639601778"
                        version="v7.0"
                        @login="getUserDataFB"
                        @logout="onLogout"
                        @get-initial-status="getUserDataFB"
                      ></facebook-login>-->

                      <a href="#">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="40"
                          height="40"
                          viewBox="0 0 40 40"
                        >
                          <g
                            id="Group_3666"
                            data-name="Group 3666"
                            transform="translate(-135 -594)"
                          >
                            <rect
                              id="Rectangle_1278"
                              data-name="Rectangle 1278"
                              width="40"
                              height="40"
                              rx="20"
                              transform="translate(135 594)"
                              fill="#4568b2"
                            />
                            <g id="facebook-logo" transform="translate(200.394 603.861)">
                              <path
                                id="Path_211"
                                data-name="Path 211"
                                d="M32.691,0,30.046,0a4.646,4.646,0,0,0-4.893,5.02V7.335h-2.66a.416.416,0,0,0-.416.416v3.354a.416.416,0,0,0,.416.416h2.66v8.463a.416.416,0,0,0,.416.416h3.47a.416.416,0,0,0,.416-.416V11.521h3.11a.416.416,0,0,0,.416-.416V7.751a.416.416,0,0,0-.416-.416H29.455V5.373c0-.943.225-1.422,1.453-1.422h1.782a.416.416,0,0,0,.416-.416V.42A.416.416,0,0,0,32.691,0Z"
                                transform="translate(-73)"
                                fill="#fff"
                              />
                            </g>
                          </g>
                        </svg>
                      </a>
                      <a href="#">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="40"
                          height="40"
                          viewBox="0 0 40 40"
                        >
                          <g id="Group_585" data-name="Group 585" transform="translate(-196 -594)">
                            <g id="search" transform="translate(204.771 602.771)">
                              <path
                                id="Path_207"
                                data-name="Path 207"
                                d="M4.977,145.774,4.2,148.693l-2.857.06a11.248,11.248,0,0,1-.083-10.485h0l2.544.466,1.114,2.528a6.7,6.7,0,0,0,.063,4.512Z"
                                transform="translate(0 -132.203)"
                                fill="#fbbb00"
                              />
                              <path
                                id="Path_208"
                                data-name="Path 208"
                                d="M272.413,208.176a11.224,11.224,0,0,1-4,10.854h0l-3.2-.163-.453-2.831a6.692,6.692,0,0,0,2.879-3.417h-6v-4.442h10.785Z"
                                transform="translate(-250.153 -199.045)"
                                fill="#518ef8"
                              />
                              <path
                                id="Path_209"
                                data-name="Path 209"
                                d="M47.428,315.822h0a11.232,11.232,0,0,1-16.92-3.435l3.639-2.979a6.678,6.678,0,0,0,9.623,3.419Z"
                                transform="translate(-29.171 -295.838)"
                                fill="#28b446"
                              />
                              <path
                                id="Path_210"
                                data-name="Path 210"
                                d="M45.764,2.585,42.127,5.563a6.677,6.677,0,0,0-9.844,3.5L28.625,6.065h0a11.231,11.231,0,0,1,17.14-3.48Z"
                                transform="translate(-27.369)"
                                fill="#f14336"
                              />
                            </g>
                            <g
                              id="Rectangle_1278"
                              data-name="Rectangle 1278"
                              transform="translate(196 594)"
                              fill="none"
                              stroke="#dfe3e9"
                              stroke-width="1"
                            >
                              <rect width="40" height="40" rx="20" stroke="none" />
                              <rect x="0.5" y="0.5" width="39" height="39" rx="19.5" fill="none" />
                            </g>
                          </g>
                        </svg>
                      </a>
                    </div>
                  </div>
                </form>
              </div>
            </tab>
          </tabs>
        </div>
      </div>
    </modal>

    <modal name="Notificate" class="si__style-pop promo-code-modal">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('Notificate')">
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
          <div class="notification-header">
            <div class="promo-code-header">
              <h5>მონაწილის კოდი</h5>
              <div class="code">7 7 7 7 8 7</div>
            </div>
          </div>
          <div class="promo-code-content">
            <div class="pr-list">
              <perfect-scrollbar>
                <div class="pr-item">
                  <div class="pr-image">
                    <img src="/img/iphone.png" alt />
                  </div>
                  <div class="pr-info">
                    <div class="pr-details">
                      <h4>Apple iPhone 11 (64GB) Black</h4>
                      <div class="pr-specs">
                        <div class="spec-item">
                          <div class="label">მაღაზია:</div>
                          <div class="value">ზუმერი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">მისამართი:</div>
                          <div class="value">წერეთლის #1</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ფასი:</div>
                          <div class="value">3300 ლარი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ქულა:</div>
                          <div class="value">
                            33
                            <span class="coin"></span>
                          </div>
                        </div>
                      </div>
                      <div class="checker">
                        <div class="pretty p-svg p-curve">
                          <input type="checkbox" />
                          <div class="state p-success">
                            <svg class="svg svg-icon" viewBox="0 0 20 20">
                              <path
                                d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                style="stroke: white;fill:white;"
                              />
                            </svg>
                            <label>
                              <span>გაყიდვის დადასტურება</span>
                            </label>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="pr-item">
                  <div class="pr-image">
                    <img src="/img/iphone.png" alt />
                  </div>
                  <div class="pr-info">
                    <div class="pr-details">
                      <h4>Apple iPhone 11 (64GB) Black</h4>
                      <div class="pr-specs">
                        <div class="spec-item">
                          <div class="label">მაღაზია:</div>
                          <div class="value">ზუმერი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">მისამართი:</div>
                          <div class="value">წერეთლის #1</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ფასი:</div>
                          <div class="value">3300 ლარი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ქულა:</div>
                          <div class="value">
                            33
                            <span class="coin"></span>
                          </div>
                        </div>
                      </div>
                      <div class="checker">
                        <div class="pretty p-svg p-curve">
                          <input type="checkbox" />
                          <div class="state p-success">
                            <svg class="svg svg-icon" viewBox="0 0 20 20">
                              <path
                                d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                style="stroke: white;fill:white;"
                              />
                            </svg>
                            <label>
                              <span>გაყიდვის დადასტურება</span>
                            </label>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="pr-item">
                  <div class="pr-image">
                    <img src="/img/iphone.png" alt />
                  </div>
                  <div class="pr-info">
                    <div class="pr-details">
                      <h4>Apple iPhone 11 (64GB) Black</h4>
                      <div class="pr-specs">
                        <div class="spec-item">
                          <div class="label">მაღაზია:</div>
                          <div class="value">ზუმერი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">მისამართი:</div>
                          <div class="value">წერეთლის #1</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ფასი:</div>
                          <div class="value">3300 ლარი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ქულა:</div>
                          <div class="value">
                            33
                            <span class="coin"></span>
                          </div>
                        </div>
                      </div>
                      <div class="checker">
                        <div class="pretty p-svg p-curve">
                          <input type="checkbox" />
                          <div class="state p-success">
                            <svg class="svg svg-icon" viewBox="0 0 20 20">
                              <path
                                d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                style="stroke: white;fill:white;"
                              />
                            </svg>
                            <label>
                              <span>გაყიდვის დადასტურება</span>
                            </label>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="pr-item">
                  <div class="pr-image">
                    <img src="/img/iphone.png" alt />
                  </div>
                  <div class="pr-info">
                    <div class="pr-details">
                      <h4>Apple iPhone 11 (64GB) Black</h4>
                      <div class="pr-specs">
                        <div class="spec-item">
                          <div class="label">მაღაზია:</div>
                          <div class="value">ზუმერი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">მისამართი:</div>
                          <div class="value">წერეთლის #1</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ფასი:</div>
                          <div class="value">3300 ლარი</div>
                        </div>
                        <div class="spec-item">
                          <div class="label">ქულა:</div>
                          <div class="value">
                            33
                            <span class="coin"></span>
                          </div>
                        </div>
                      </div>
                      <div class="checker">
                        <div class="pretty p-svg p-curve">
                          <input type="checkbox" />
                          <div class="state p-success">
                            <svg class="svg svg-icon" viewBox="0 0 20 20">
                              <path
                                d="M7.629,14.566c0.125,0.125,0.291,0.188,0.456,0.188c0.164,0,0.329-0.062,0.456-0.188l8.219-8.221c0.252-0.252,0.252-0.659,0-0.911c-0.252-0.252-0.659-0.252-0.911,0l-7.764,7.763L4.152,9.267c-0.252-0.251-0.66-0.251-0.911,0c-0.252,0.252-0.252,0.66,0,0.911L7.629,14.566z"
                                style="stroke: white;fill:white;"
                              />
                            </svg>
                            <label>
                              <span>გაყიდვის დადასტურება</span>
                            </label>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </perfect-scrollbar>
            </div>
          </div>
        </div>
      </div>
    </modal>

    <modal name="termsConditions" class="si__style-pop promo-code-modal">
      <div class="modal-content-item">
        <div class="modal-item-header">
          <div class="close-btn" @click="hideModal('termsConditions')">
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
          <div class="notification-header">
            <h5>წესები და პირობები</h5>
          </div>

          <div class="termsAndConditions">
            <perfect-scrollbar>
              <div class="inner-termsAndCond">
                კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ
                სდფ სდჯ ფკლსდ ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ
                კსდლჯ კლსდ ფ სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ კდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლკდლჯ კლსდლ ს დ კსდლჯ კლსდ ფ
                სდფკ სჯდფკლ სკდფ სდ ფკსდლჯფ კლსდფ სდფ სდჯ ფკლსდ
                ფჯლსდფჯკლსდჯსდკლფკსდფ კლლსდკფლკსდფლ
              </div>
            </perfect-scrollbar>
          </div>
        </div>
      </div>
    </modal>
  </div>
</template>

<script>
import Vue from "vue";
import VModal from "vue-js-modal";
import { KinesisContainer, KinesisElement } from "vue-kinesis";
import { PerfectScrollbar } from "vue2-perfect-scrollbar";
import { Tabs, Tab } from "@hiendv/vue-tabs";
import Vuelidate from "vuelidate";
import { required, email, minLength, sameAs } from "vuelidate/lib/validators";
import request from "@/Request";
Vue.use(Vuelidate);
Vue.use(VModal);
// import facebookLogin from "facebook-login-vuejs";

export default {
  name: "LogedOutMain",
  components: {
    KinesisContainer,
    KinesisElement,
    PerfectScrollbar,
    Tabs,
    Tab
    // facebookLogin
  },
  data: function() {
    return {
      baseUrl: "http://test.si.ge",
      LogPass: true,
      mobileMenu: false,
      SetPass: true,
      ConfirmPass: true,
      showReg: 0,
      loginModel: {
        userName: "",
        password: "",
        stayLogedIn: true
      },
      registerModel: {
        firstname: "",
        lastname: "",
        username: "",
        password: "",
        phone: "",
        confirmPassword: "",
        avatar: 1,
        mail: ""
      },
      loginResponse: {
        errorText: ""
      },
      gender: {
        girl: true,
        body: false
      },
      submitted: false
    };
  },
  validations: {
    registerModel: {
      firstname: {
        required,
        minLength: minLength(2)
      },
      lastname: {
        required
      },
      username: {
        required
      },
      phone: {
        required
      },
      mail: {
        required,
        email
      },
      password: {
        required,
        minLength: minLength(6)
      },
      confirmPassword: {
        required,
        sameAsPassword: sameAs("password")
      }
    }
  },
  methods: {
    mobileMenuToggle() {
      this.mobileMenu = !this.mobileMenu;
    },
    getUserDataFB() {
      this.FB.api(
        "/me",
        "GET",
        { fields: "id,name,email," },
        userInformation => {
          console.log(userInformation);
        }
      );
    },
    sdkLoaded(payload) {
      this.isConnected = payload.isConnected;
      this.FB = payload.FB;
      if (this.isConnected) this.getUserDataFB();
    },
    onLogin() {
      this.isConnected = true;
      this.getUserDataFB();
    },
    onLogout() {
      this.isConnected = false;
    },
    toggleShowPass: function(name) {
      switch (name) {
        case "LogPass":
          this.LogPass = !this.LogPass;
          break;
        case "SetPass":
          this.SetPass = !this.SetPass;
          break;
        case "ConfirmPass":
          this.ConfirmPass = !this.ConfirmPass;
          break;
      }
    },
    showModal(name) {
      switch (name) {
        case "videoModal":
          this.$modal.show("videoModal");
          this.playVideo;
          break;
        case "Notificate":
          this.$modal.show("Notificate");
          break;
        case "termsConditions":
          this.$modal.show("termsConditions");
          break;
      }
    },
    hideModal(name) {
      switch (name) {
        case "videoModal":
          this.$modal.hide("videoModal");
          break;
        case "Notificate":
          this.$modal.hide("Notificate");
          break;
        case "termsConditions":
          this.$modal.hide("termsConditions");
          break;
      }
    },
    RegLogModalShow() {
      this.$modal.show("RegLogModal");
      this.showReg = 0;
    },
    playVideo() {
      this.$refs.video.play();
    },
    startGame() {
      this.$modal.show("RegLogModal");
      this.showReg = 1;
    },
    RegLogModalHide() {
      this.$modal.hide("RegLogModal");
      this.showReg = 0;
    },
    getUserData() {
      request({
        url: "/api/Bonus/Current",
        method: "get"
      })
        .then(function(response) {
          console.log(response);
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    submitLogin() {
      var self = this;
      request({
        url: "/api/account/login",
        method: "post",
        data: self.loginModel
      })
        .then(function(response) {
          console.log(response);
          if (!response.data.isSuccess) {
            self.loginResponse.errorText = response.data.message;
          } else {
            self.loginResponse.errorText = "";
            localStorage.setItem("authorisedUser", response.data.data.userName);
            location.reload();
          }
        })
        .catch(function(error) {
          console.log(error);
        });
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
    submitRegister() {
      var self = this;
      self.submitted = true;

      self.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }

      request({
        url: "/api/account/register",
        method: "post",
        data: self.registerModel
      })
        .then(function(response) {
          console.log("reg", response);
          if (response.data.isSuccess) {
            localStorage.setItem("authorisedUser", response.data.data.userName);
            location.reload();
          }
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  },
  mounted: function() {
    document.addEventListener("keyup", event => {
      if (event.keyCode === 13) {
        this.submitLogin();
      }
    });
  }
};
</script>


<style scoped>
body{
  background-color: #3285ff !important;
}

.general-page-wrapper {
 background-color: #3285ff;
}

@media (min-width: 1920px) {
  .right-color {
    height: 100vw;
    width: 50vw;
    position: absolute;
    background-color: #aeb1ac;
    right: 0;
  }
}

.fullscreenMenuMobile {
  position: fixed;
  right: 0;
  top: 0;
  height: 100%;
  background: #1f2242;
  z-index: 9;
  padding: 15px;
  width: 75%;
  transform: translateX(100%);
  transition: all 0.3s;
  opacity: 0;
  visibility: hidden;
}
.fullscreenMenuMobile.active {
  transform: translateX(0);
  transition: all 0.3s;
  opacity: 1;
  visibility: visible;
  -webkit-transform: translateX(0);
  -moz-transform: translateX(0);
  -ms-transform: translateX(0);
  -o-transform: translateX(0);
}
.fullscreenMenuMobile ul {
  padding: 15px;
}
.fullscreenMenuMobile ul li {
  margin-bottom: 15px;
}
.fullscreenMenuMobile ul li a {
  color: #fff;
  font-family: "helv-65";
  font-size: 16px;
  text-decoration: none;
}

.si__style-pop .promo-code-header h5 {
  text-align: left;
  margin-bottom: 10px;
}
.si__style-pop .promo-code-header .code {
  display: inline-flex;
  background: #edeef0;
  padding: 15px 25px;
  font-size: 14px;
  font-family: "helv-65";
  font-weight: bold;
  border-radius: 10px;
}
.si__style-pop .promo-code-header {
  margin-bottom: 10px;
}
.si__style-pop .promo-code-content {
  display: inline-block;
  width: 100%;
  margin-top: 25px;
}
.si__style-pop .promo-code-content .pr-list {
  display: inline-block;
  width: 100%;
}

.si__style-pop .promo-code-content .pr-item {
  display: inline-block;
  width: calc(100% - 20px);
  margin-bottom: 15px;
}
.si__style-pop .promo-code-content .pr-item .pr-image {
  width: 200px;
  float: left;
  height: 240px;
  background: #fff;
  display: flex;
  align-items: center;
  justify-content: center;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
}
.si__style-pop .promo-code-content .pr-item .pr-image img {
  max-width: 80%;
}
.si__style-pop .promo-code-content .pr-item .pr-info {
  height: 240px;
  width: calc(100% - 200px);
  float: right;
  padding-left: 20px;
  background: #1f2242;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-details {
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  margin-top: 15px;
  padding-right: 15px;
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-details h4 {
  color: #fff;
  font-size: 22px;
  font-family: "kirovi";
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-specs {
  display: flex;
  flex-wrap: wrap;
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-specs .spec-item {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
  margin-bottom: 5px;
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-specs .label {
  color: #6a6d8b;
  font-size: 16px;
  font-family: "helv-65";
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-specs .value {
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
  margin-left: 5px;
  position: relative;
  top: 2px;
}
.si__style-pop .promo-code-content .pr-item .pr-info .pr-specs .value .coin {
  background-image: url(/img/coin.svg);
  background-repeat: no-repeat;
  background-size: contain;
  width: 16px;
  height: 16px;
  display: inline-block;
  position: absolute;
  top: 4px;
  right: -20px;
}
.si__style-pop .promo-code-content .pr-item .pr-info .checker {
  display: inline-block;
  margin-top: 10px;
}
.si__style-pop .promo-code-content .pr-item .pretty .state label:after,
.si__style-pop .promo-code-content .pr-item .pretty .state label:before {
  background: #1f2242;
  width: 40px !important;
  height: 40px !important;
  border: 2px solid #3285ff;
  border-radius: 15px !important;
}
.si__style-pop .promo-code-content .pr-item .pr-info .checker svg {
  width: 22px;
  height: 22px;
  top: 10px;
  left: 10px;
  opacity: 1;
}
.si__style-pop .promo-code-content .pr-item .pr-info .checker svg * {
  fill: #707070 !important;
  stroke: #707070 !important;
}
.si__style-pop .promo-code-content .pr-item .pr-info .checker label span {
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
  position: relative;
  top: 11px;
  left: 30px;
}
.si__style-pop
  .promo-code-content
  .pr-item
  .pr-info
  .checker
  .pretty
  input:checked
  ~ .state.p-success
  .svg
  * {
  fill: #fff !important;
  stroke: #fff !important;
}
.si__style-pop .promo-code-content .pr-item .pr-info .checker input {
  height: 40px;
}
.video-content {
  display: inline-block;
  width: 100%;
}
.video-content video {
  width: 100%;
}
.full-screen-view {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100vh;
  overflow: hidden;
}
.full-screen-view .bgfull-image {
  background-image: url(/img/bg-full.png);
  background-size: cover;
  background-position: 50vw 0;
  position: absolute;
  top: calc(100vh - 1071px);
  left: 50px;
  width: 100%;
  height: 1072px;
}
@media (min-width: 1920px) {
  .full-screen-view .bgfull-image {
    background-image: url(/img/bg-full.png);
    background-size: cover;
    position: fixed;
    top: calc(100vh - 1090px);
    width: 1920px;
    height: 1090px;
    right: 0;
    bottom: 0;
    left: 50px;
  }
}
.full-screen-view .bgfull-image::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  background: rgba(0, 0, 0, 0.2);
  width: 100%;
  height: 100%;
}

.full-screen-view .people-moveing {
  z-index: 3;
  background-image: url(/img/people.svg);
  width: 41vw;
  height: 35vw;
  background-size: contain;
  background-position: center;
  position: absolute;
  right: 82px;
  bottom: 26px;
  background-repeat: no-repeat;
}
/* @media (min-width: 1920px) {
  .full-screen-view .people-moveing {
    width: 900px;
    height: 827px;
  }
} */
.full-screen-view .caption-item {
  position: absolute;
  top: 50%;
  z-index: 9;
  left: 25%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  width: 350px;
}
.full-screen-view .caption-item.promo-code .main-title {
  font-size: 50px;
}
.full-screen-view .caption-item.promo-code .btn-control {
  margin-top: 15px;
}
.full-screen-view .caption-item.promo-code .btn-control .btn-item {
  display: inline-flex;
  position: relative;
  flex-wrap: wrap;
  margin-right: 0;
  width: 165px;
}
.full-screen-view .caption-item.promo-code .btn-control .label {
  display: inline-block;
  width: 100%;
  font-size: 12px;
  font-family: "helv-65";
  margin-bottom: 10px;
  color: #fff;
}
.full-screen-view .caption-item.promo-code .btn-control input {
  display: inline-block;
  width: 100px;
  height: 50px;
  background: rgba(237, 238, 240, 0.2);
  border: 2px solid #fff;
  border-radius: 8px;
  padding: 5px 0;
  font-family: "helv-65";
  text-align: center;
  color: #fff;
}
.full-screen-view .caption-item.promo-code .btn-control input:focus {
  outline: none;
}
.full-screen-view .caption-item.promo-code .btn-control .check {
  background: #fff;
  text-align: center;
  border-radius: 8px;
  height: 50px;
  margin-top: 29px;
  left: -50px;
  transition: all 0.3s;
}
.full-screen-view .caption-item.promo-code .btn-control .check:hover {
  transition: all 0.3s;
  background: rgba(237, 238, 240, 0.2);
  transition: all 0.3s;
}
.full-screen-view .caption-item.promo-code .btn-control .check:hover .txt {
  color: #fff;
  transition: all 0.3s;
}
.full-screen-view .caption-item.promo-code .btn-control .check .txt {
  color: #3285ff;
  text-align: center;
  width: 100%;
  font-size: 14px;
  transition: all 0.3s;
}

.full-screen-view .caption-item .sub-title {
  color: #fff;
  font-family: "helv-65";
  font-size: 20px;
}
.full-screen-view .caption-item .main-title {
  font-family: "kirovi";
  color: #fff;
  font-size: 60px;
  max-width: 100%;
  line-height: normal;
}
.full-screen-view .caption-item .btn-control {
  display: flex;
  align-items: center;
  margin-top: 40px;
}
.full-screen-view .caption-item .btn-control .btn-item {
  display: flex;
  align-items: center;
  margin-right: 35px;
  cursor: pointer;
}

.full-screen-view .caption-item .btn-control .btn-item .icon-play {
  width: 40px;
  height: 40px;
  border: 2px solid #fff;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-align: center;
  -ms-flex-align: center;
  align-items: center;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  justify-content: center;
  border-radius: 15px;
  margin-right: 15px;
}

.full-screen-view .caption-item .btn-control .btn-item .icon-play svg {
  margin-left: 5px;
  margin-top: 2px;
}
.full-screen-view .caption-item .btn-control .btn-item .icon {
  width: 40px;
  height: 40px;
  background: #fff;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 15px;
  margin-right: 15px;
  box-shadow: 0 0 0 rgba(255, 255, 255, 0.7);
  animation: pulse 1.5s infinite;
}
@-webkit-keyframes pulse {
  0% {
    -webkit-box-shadow: 0 0 0 0 rgba(255, 255, 255, 0.7);
  }
  70% {
    -webkit-box-shadow: 0 0 0 10px rgba(255, 255, 255, 0);
  }
  100% {
    -webkit-box-shadow: 0 0 0 0 rgba(255, 255, 255, 0);
  }
}
@keyframes pulse {
  0% {
    -moz-box-shadow: 0 0 0 0 rgba(255, 255, 255, 0.7);
    box-shadow: 0 0 0 0 rgba(255, 255, 255, 0.7);
  }
  70% {
    -moz-box-shadow: 0 0 0 10px rgba(255, 255, 255, 0);
    box-shadow: 0 0 0 10px rgba(255, 255, 255, 0);
  }
  100% {
    -moz-box-shadow: 0 0 0 0 rgba(255, 255, 255, 0);
    box-shadow: 0 0 0 0 rgba(255, 255, 255, 0);
  }
}
.full-screen-view .caption-item .btn-control .btn-item .txt {
  color: #fff;
  font-family: "helv-65";
  font-size: 16px;
}
.full-screen-view .shape-item {
  position: absolute;
  top: 0;
  left: 0;
  width: 85vw;
  height: 100%;
  background-image: url(/img/blue.svg);
  background-size: 100%;
  background-repeat: no-repeat;
  background-size: cover;
  background-position-x: right;
}
/* @media (min-width: 1920px) {
  .full-screen-view .shape-item {
    background-size: 102%;
    background-position: -32px 0;
  }
} */
.full-screen-view .header-navbar {
  position: absolute;
  top: 0;
  z-index: 4;
  left: 0;
  width: 100%;
}
.full-screen-view .nav-bar-in {
  position: absolute;
  left: 0;
  top: 0;
  height: 110px;
  display: flex;
  width: calc(100% - 240px);
  align-items: center;
  justify-content: space-between;
}
@media (min-width: 1920px) {
  .full-screen-view .nav-bar-in {
    width: calc(100% - 110px);
  }
}
.full-screen-view .nav-bar-in .lf-side {
  display: flex;
  align-items: center;
}
.full-screen-view .nav-bar-in .right-nav {
  display: flex;
  align-items: center;
}
.full-screen-view .nav-bar-in .right-nav .login-btn {
  display: flex;
  align-items: center;
  cursor: pointer;
}
.full-screen-view .nav-bar-in .right-nav .login-btn .txt {
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
}
.full-screen-view .nav-bar-in .right-nav .login-btn .icon {
  border: 2px solid #fff;
  width: 40px;
  height: 40px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 15px;
  margin-right: 10px;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher {
  display: flex;
  align-items: center;
  margin-left: 20px;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher ol {
  list-style: none;
  padding: 0;
  margin: 0;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher ol li {
  display: inline-flex;
  align-items: center;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher ol li:last-child:after {
  content: none;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher ol li:after {
  content: "/";
  color: #fff;
  margin: 0 5px;
  font-weight: bold;
}
.full-screen-view .nav-bar-in .right-nav .lang-switcher ol li a {
  color: #fff;
  font-family: "helv-65";
  font-size: 14px;
  text-decoration: none;
}
.full-screen-view .logo h1 {
  margin: 0;
}
.full-screen-view .logo h1 img {
  max-width: 100%;
}
.full-screen-view .menu-item {
  height: 100%;
  display: flex;
  align-items: center;
}
.full-screen-view .menu-item ul {
  margin: 0;
  padding: 0;
  margin-left: 50px;
  list-style: none;
  display: flex;
}
.full-screen-view .menu-item ul li {
  margin: 0 8px;
  padding: 0;
}
.full-screen-view .menu-item ul li a {
  text-decoration: none;
  color: #fff;
  font-size: 14px;
  font-family: "helv-65";
}
.full-screen-view .menu-item ul li a.router-link-exact-active {
  color: #fff;
}

@media (min-width: 1025px) {
  .full-screen-view .nav-bar-in .mobile-nav {
    display: none;
  }
  .fullscreenMenuMobile {
    display: none;
  }
}

@media (max-width: 1024px) {
  .full-screen-view .nav-bar-in .right-nav .login-btn .icon {
    width: 55px;
    height: 55px;
    border: 2px solid #fff;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: center;
    border-radius: 15px;
    position: relative;
    margin-right: 0;
  }

  .full-screen-view .nav-bar-in .lf-side {
    display: none;
  }
  .full-screen-view .nav-bar-in .mobile-nav {
    display: flex;
    width: calc(50% + 40px);
    justify-content: space-between;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu {
    display: flex;
    align-items: center;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .showMenu {
    width: 55px;
    height: 55px;
    border: 2px solid #fff;
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 15px;
    position: relative;
  }
  .full-screen-view .nav-bar-in .right-nav .login-btn .txt {
    display: none;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .showMenu svg {
    width: 20px;
    height: 20px;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .showMenu svg * {
    fill: #fff;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .closeMenu {
    width: 55px;
    height: 55px;
    border: 2px solid #fff;
    align-items: center;
    justify-content: center;
    border-radius: 15px;
    position: relative;
    display: none;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu.active .closeMenu {
    display: flex;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu.active .showMenu {
    display: none;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .closeMenu svg {
    width: 20px;
    height: 20px;
  }

  .full-screen-view .nav-bar-in .mobile-nav .burger-menu .closeMenu svg * {
    fill: #fff;
  }

  .full-screen-view .nav-bar-in .mobile-nav .mobile-logo img {
    max-width: 80px;
  }
  .full-screen-view .nav-bar-in .right-nav .user-menu-btn .icon {
    width: 55px;
    height: 55px;
    border: 2px solid #2b305a;
  }

  .full-screen-view .right-nav {
    width: calc(50% - 20px);
    justify-content: flex-end;
  }
  .full-screen-view .nav-bar-in {
    width: calc(100% - 30px);
    left: 15px;
  }
}
/* @media (min-width: 1025px) and (max-width: 1365px) {
  .full-screen-view .shape-item {
    width: 100%;
  }
  .full-screen-view .nav-bar-in {
    width: 100%;
    padding: 0 30px;
  }
  .full-screen-view .bgfull-image {
    background-position: 1077px 0;
  }
  .full-screen-view .shape-item {
    background-size: cover;
    width: 100vw;
  }
} */

.instructions-video:focus {
  outline: none;
}
@media (min-width: 768px) and (max-width: 1024px) {
  .full-screen-view .people-moveing {
    display: none;
  }
  .full-screen-view .shape-item {
    background: #3285ff;
    width: 100%;
  }
  .full-screen-view .nav-bar-in {
    width: 100%;
    left: 0;
  }
  .full-screen-view .nav-bar-in .lf-side .logo {
    max-width: 115px;
  }
  .full-screen-view .menu-item ul {
    margin-right: 0;
    margin-left: 15px;
  }
  .full-screen-view .menu-item ul li a {
    font-size: 12px;
  }
  .full-screen-view .caption-item {
    left: 35%;
  }
}
@media (max-width: 1024px) {
  .full-screen-view .shape-item {
    display: none;
  }
  .full-screen-view .people-moveing {
    display: none;
  }
  .full-screen-view .bgfull-image::before {
    content: none;
  }
  .full-screen-view .bgfull-image {
    background-image: unset;
    background-color: #3285ff;
  }
  .full-screen-view .caption-item {
    transform: translateY(-50%);
    left: 15px;
  }
  .full-screen-view .caption-item .btn-control {
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
    margin-top: 20px;
  }
  .full-screen-view .caption-item .btn-control .btn-item {
    margin-bottom: 20px;
    margin-right: 0;
  }
  .full-screen-view .caption-item .main-title {
    font-size: 40px;
  }
  .full-screen-view .caption-item .sub-title {
    font-size: 18px;
  }
  .si__style-pop .vm--modal {
    padding: 30px 15px;
    width: calc(100% - 10px) !important;
    max-width: 500px;
  }
  .si__style-pop .input-item.db-item {
    width: 100% !important;
  }
}

@media (max-width: 1024px) and (max-height: 900px) {
  .mobile-main-image {
    width: 735px;
    height: 735px;
    transform: translateY(-735px);
  }
}
@media (max-width: 768px) and (max-height: 900px) {
  .mobile-main-image {
    width: 535px;
    height: 535px;
    transform: translateY(-535px);
  }
}
@media (max-width: 1024px) and (max-height: 500px) {
  .mobile-main-image {
    width: 435px;
    height: 435px;
    transform: translateY(-435px);
  }
}

@media (min-width: 1025px) {
  .mobile-main-image {
    display: none;
  }
}
@media (min-width: 1025px) and (max-height: 500px) {
  .mobile-main-image {
    display: block;
    width: 435px;
    height: 435px;
    transform: translateY(-435px);
  }
  .full-screen-view .shape-item {
    background-color: #3285ff;
    width: 100vw;
  }
  .full-screen-view .people-moveing {
    display: none;
  }
}
</style>
