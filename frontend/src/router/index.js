import Vue from "vue";
import VueRouter from "vue-router";
import Courses from "../views/Courses.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Courses",
    component: Courses,
  },
  {
    path: "/backoffice",
    name: "Backoffice",
    component: () =>
      import(/* webpackChunkName: "backoffice" */ "../views/Backoffice.vue"),
  },
  {
    path: "/course",
    name: "Course",
    component: () =>
      import(/* webpackChunkName: "course" */ "../views/Course.vue"),
  },
  {
    path: "/form",
    name: "Form",
    component: () => import(/* webpackChunkName: "form" */ "../views/Form.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  routes,
});

export default router;
