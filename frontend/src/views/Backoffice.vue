<template>
  <section class="page">
    <h1 class="title text-secondary">Painel Administrativo</h1>
    <p class="text-dark">Educação financeira é tudo de bom.</p>
    <main class="grid gap-xl m-t-xl">
      <table class="table">
        <thead class="bg-light">
          <tr>
            <th><span class="text-dark w-bold">Cursos</span></th>
            <th><span class="text-dark w-bold">Ações</span></th>
          </tr>
        </thead>
        <tbody class="text-tiny">
          <tr v-for="(post, index) in posts" :key="index">
            <td>
              <span class="text-dark">
                <router-link :to="`/course?id=${post.idcurso}`">{{
                  post.titulo
                }}</router-link></span
              >
            </td>
            <td>
              <router-link
                :to="`/form?id=${post.idcurso}`"
                class="button bg-warning button--xs"
                >editar</router-link
              >
              <button
                @click="deleteCourse(post.idcurso)"
                class="button bg-negative button--xs m-l-desk m-t-mob"
              >
                excluir
              </button>
            </td>
          </tr>
        </tbody>
      </table>
      <div>
        <router-link :to="`/form`" class="button bg-positive button--lg"
          >adicionar novo</router-link
        >
      </div>
    </main>
  </section>
</template>

<script>
import { mapMutations, mapState } from "vuex";

export default {
  name: "Backoffice",
  computed: {
    ...mapState({ courses: (state) => state.courses }),
    posts() {
      if (!this.courses || !this.courses.length || this.courses.length <= 0) {
        return [];
      }
      const posts = this.courses && this.courses.length ? this.courses : [];
      return posts.length ? posts.filter((p) => !p.deleted) : [];
    },
  },
  methods: {
    ...mapMutations({ setCourses: "setCourses" }),
    deleteCourse(id) {
      const course = this.posts.find((p) => p.idcurso === id);
      course.deleted = true;
      const posts = this.posts.filter((p) => !p.deleted);
      this.setCourses(posts);
    },
  },
};
</script>
