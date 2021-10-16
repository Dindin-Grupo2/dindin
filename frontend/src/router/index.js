import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/courses",
    name: "Courses",
    component: () =>
      import(/* webpackChunkName: "courses" */ "../views/Courses.vue"),
  },
  {
    path: "/backoffice",
    name: "Backoffice",
    component: () =>
      import(/* webpackChunkName: "backoffice" */ "../views/Backoffice.vue"),
  },
];

const router = new VueRouter({
  routes,
});

export default router;
