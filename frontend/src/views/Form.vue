<template>
  <section class="page">
    <h1 class="title text-secondary">{{ title }} Curso</h1>
    <main class="grid grid-cols gap-xl m-t-xl">
      <div class="g-col g-col-xs-12 g-col-md-10">
        <form class="form" v-if="course">
          <div>
            <label for="title">Título</label>
            <input
              class="form-field"
              type="text"
              placeholder="Título do curso"
              id="title"
              v-model="form.titulo"
            />
          </div>
          <div class="m-t-xs">
            <label for="cover">Capa</label>
            <input
              class="form-field"
              type="text"
              placeholder="Insira a URL da Capa"
              id="cover"
              v-model="form.capa"
            />
          </div>
          <div class="m-t-xs">
            <label for="teacher">Professor</label>
            <input
              class="form-field"
              type="text"
              placeholder="Nome do professor"
              id="teacher"
              v-model="form.professor"
            />
          </div>
          <div class="m-t-xs">
            <label for="description">Descrição</label>
            <textarea
              class="form-field"
              placeholder="Acrescente uma breve descrição"
              id="description"
              v-model="form.descricao"
            ></textarea>
          </div>
          <div class="m-t-lg">
            <h2 class="subtitle text-secondary">Aula 1</h2>
            <div class="m-t-sm">
              <label for="lesson-title-1">Título</label>
              <input
                class="form-field"
                type="text"
                placeholder="Título do curso"
                id="lesson-title-1"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-link-1">Link</label>
              <input
                class="form-field"
                type="text"
                placeholder="Insira o link da aula"
                id="lesson-link-1"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-description-1">Descrição</label>
              <textarea
                class="form-field"
                placeholder="Acrescente uma breve descrição da aula"
                id="lesson-description-1"
              ></textarea>
            </div>
          </div>
          <div class="m-t-lg">
            <h2 class="subtitle text-secondary">Aula 2</h2>
            <div class="m-t-sm">
              <label for="lesson-title-2">Título</label>
              <input
                class="form-field"
                type="text"
                placeholder="Título do curso"
                id="lesson-title-2"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-link-2">Link</label>
              <input
                class="form-field"
                type="text"
                placeholder="Insira o link da aula"
                id="lesson-link-2"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-description-2">Descrição</label>
              <textarea
                class="form-field"
                placeholder="Acrescente uma breve descrição da aula"
                id="lesson-description-2"
              ></textarea>
            </div>
          </div>
          <div class="m-t-lg">
            <h2 class="subtitle text-secondary">Aula 3</h2>
            <div class="m-t-sm">
              <label for="lesson-title-3">Título</label>
              <input
                class="form-field"
                type="text"
                placeholder="Título do curso"
                id="lesson-title-3"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-link-3">Link</label>
              <input
                class="form-field"
                type="text"
                placeholder="Insira o link da aula"
                id="lesson-link-3"
              />
            </div>
            <div class="m-t-xs">
              <label for="lesson-description-3">Descrição</label>
              <textarea
                class="form-field"
                placeholder="Acrescente uma breve descrição da aula"
                id="lesson-description-3"
              ></textarea>
            </div>
          </div>
          <button
            @click="updateCourses"
            type="button"
            class="
              button
              bg-primary
              button--lg button-radius
              button-p--lg
              m-t-lg
            "
          >
            salvar
          </button>
        </form>
        <div v-else>
          <p class="text-dark">O curso procurado não foi encontrado.</p>
          <p class="text-dark">
            Certifique-se do endereço que consta na rota, se o mesmo é correto.
          </p>
          <p class="text-dark">
            Na dúvida retorne à página inicial e reinicie sua navegação.
          </p>
          <router-link to="/" class="button bg-secondary m-t-sm"
            >Voltar</router-link
          >
        </div>
      </div>
    </main>
  </section>
</template>

<script>
import Vue from "vue";
import Toast from "vue-toastification";
import { mapState } from "vuex";
import "vue-toastification/dist/index.css";

const options = {};

Vue.use(Toast, options);

export default {
  name: "Form",
  data() {
    return {
      form: {},
      title: "Novo",
    };
  },
  computed: {
    ...mapState({ courses: (state) => state.courses }),
    courseData() {
      return {
        titulo: "",
        capa: "",
        nomeProfessor: "",
        descricao: "",
      };
    },
    course() {
      if (this.$route.query.id) {
        if (!this.courses || this.courses.length <= 0) {
          return false;
        }
        const id = this.$route.query.id;
        const courses = this.courses && this.courses.length ? this.courses : [];
        const course = courses.find((c) => c.idcurso === id);
        if (!course) {
          return false;
        }
        this.getCourse(course);
        return true;
      }
      this.getCourse(this.courseData);
      return true;
    },
  },
  methods: {
    getCourse(data) {
      this.title = "Editar";
      this.form = data;
    },
    checkForm() {
      if (!this.form.titulo || !this.form.capa || !this.form.descricao) {
        return false;
      }
      return true;
    },
    updateCourses() {
      if (!this.checkForm()) {
        this.$toast("Verifique os campos novamente!");
        return false;
      }
      return false;
    },
  },
};
</script>
