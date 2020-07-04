import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import router from "./router"
import i18n from './i18n'

Vue.config.productionTip = false

Vue.use(VueRouter);

// use beforeEach route guard to set the language
router.beforeEach((to, from, next) => {

  // use the language from the routing param or default language
  let language = to.params.lang;
  if (!language) {
    language = 'en'
  }

  // set the current language for i18n.
  i18n.locale = language
  next()
})
new Vue({
  render: h => h(App),
  i18n,
  router
}).$mount('#app')
