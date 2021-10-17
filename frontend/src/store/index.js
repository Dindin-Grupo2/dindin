import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    courses: [],
  },
  mutations: {
    setCourses(state, courses) {
      state.courses = courses;
    },
    addCourse(state, course) {
      const post = {
        idcurso: course.idcurso,
        titulo: course.titulo,
        capa: course.capa,
        nome_professor: course.nome_professor,
        descricao: course.descricao,
        aulas: [],
      };
      state.courses.push(post);
    },
  },
  actions: {
    async getCourses({ commit }) {
      try {
        const res = await axios.get(
          "http://localhost:8080/statics/courses.json"
        );
        const courses = res.data;
        commit("setCourses", courses);
      } catch (e) {
        console.log("Não foi possível consultar o catálogo de cursos.");
        commit("setCourses", { error: e });
      }
    },
    updateCourses({ commit }, course) {
      commit("addCourse", course);
    },
  },
});
