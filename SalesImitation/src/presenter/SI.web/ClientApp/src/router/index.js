import VueRouter from "vue-router";
import i18n from "../i18n";
//components
import Index from "../components/page/Index";
import Contact from "../components/page/Contact";
import About from "../components/page/About";
import Faq from "../components/page/Faq";
import GameRules from "../components/page/GameRules";
import Dashboard from "../components/page/Dashboard";
import EditProfile from "../components/page/EditProfile";
import ChangePassword from "../components/page/changePassword";


const router = new VueRouter({
  mode: "history", 
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      redirect: `/${i18n.locale}`,
    },
    {
      path: "/:lang",
      component: {
        render(c) {
          return c("router-view");
        },
      },
      children: [
        {
          name: "Index",
          path: "/",
          component: Index,
        },
        {
          name: "Dashboard",
          path: "dashboard",
          component: Dashboard,
        }, 
        {
          name: "EditProfile",
          path: "editProfile", 
          component: EditProfile,
        },
        {
          name: "ChangePassword",
          path: "changePassword", 
          component: ChangePassword,
        },
        {
          name: "About",
          path: "about",
          component: About,
        },
        {
          name: "Faq",
          path: "faq",
          component: Faq,
        },
        {
          name: "GameRules",
          path: "gameRules",
          component: GameRules,
        },
        {
          name: "Contact",
          path: "contact",
          component: Contact,
        },
      ],
    },
  ],
});

export default router;
