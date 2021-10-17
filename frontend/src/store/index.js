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

/* create table curso(
idcurso int not null primary key auto_increment,
titulo VARCHAR(150) NOT NULL,
capa VARCHAR(2048) NULL,
nome_professor VARCHAR(190) NOT NULL,
descricao VARCHAR(500) NOT NULL
)Engine=InnoDB;

create table aula(
idaula int not null primary key auto_increment,
titulo VARCHAR(150) NOT NULL,
link VARCHAR(2048) NOT NULL,
descricao VARCHAR(500) NOT NULL,
id_curso INT NOT NULL
)Engine=InnoDB; */
