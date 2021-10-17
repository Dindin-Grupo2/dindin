<template>
  <section class="page">
    <h1 class="title text-secondary">Cursos</h1>
    <p class="text-dark">Educação financeira é tudo de bom.</p>
    <main class="grid gap-xl m-t-xl">
      <div
        v-for="(post, index) in posts"
        :key="post.idcurso"
        class="grid gap-xl"
      >
        <Course :course="post" />
        <hr v-if="index < posts.length - 1" />
      </div>
    </main>
  </section>
</template>

<script>
import { mapState } from "vuex";
import Course from "@/components/Course.vue";

export default {
  name: "Courses",
  components: {
    Course,
  },
  data() {
    return {};
  },
  computed: {
    ...mapState({ courses: (state) => state.courses }),
    posts() {
      if (!this.courses || !this.courses.length || this.courses.length <= 0) {
        return [];
      }
      const posts = this.courses && this.courses.length ? this.courses : [];
      return posts.length ? posts : [];
    },
  },
};
</script>
