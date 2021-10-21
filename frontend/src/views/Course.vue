<template>
  <section class="page" v-if="course">
    <article class="grid grid-cols gap-xl">
      <div class="grid gap-xl g-col g-col-xs-12 g-col-md-6">
        <h1 class="title text-secondary">{{ course.titulo }}</h1>
        <p class="w-light text-dark">
          {{ course.descricao }}
        </p>
      </div>
      <div class="g-col g-col-xs-12 g-col-md-5">
        <img v-if="course.capa" alt="img" :src="`images/${course.capa}`" />
        <img v-else alt="img-placeholder" src="images/temp-placeholder.jpg" />
      </div>
    </article>
    <section class="grid gap-xl m-t-xl">
      <div
        v-for="(lesson, index) in course.aulas"
        :key="lesson.idaula"
        class="grid gap-xl"
      >
        <Lesson :lesson="lesson" />
        <hr v-if="index < course.aulas.length - 1" />
      </div>
    </section>
  </section>
</template>

<script>
import { mapState } from "vuex";
import Lesson from "@/components/Lesson.vue";

export default {
  name: "Course",
  components: {
    Lesson,
  },
  data() {
    return {};
  },
  computed: {
    ...mapState({ courses: (state) => state.courses }),
    course() {
      if (
        !this.courses ||
        !this.courses.length ||
        this.courses.length <= 0 ||
        !this.$route.query.id
      ) {
        return;
      }
      const id = this.$route.query.id;
      const courses = this.courses && this.courses.length ? this.courses : [];
      const course = courses.find((c) => c.idcurso === id);

      return course ? course : this.$router.replace("/");
    },
  },
};
</script>
