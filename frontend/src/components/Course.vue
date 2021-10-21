<template>
  <article class="grid grid-cols gap-xl">
    <div class="g-col g-col-xs-12 g-col-md-4">
      <img v-if="course.capa" alt="img" :src="`images/${course.capa}`" />
      <img v-else alt="img-placeholder" src="images/temp-placeholder.jpg" />
    </div>
    <div class="grid gap-xl g-col g-col-xs-12 g-col-md-8">
      <h2 class="subtitle text-secondary">{{ course.titulo }}</h2>
      <p class="w-light">
        {{ course.descricao }}
      </p>
      <div>
        <router-link
          :to="`/course?id=${course.idcurso}`"
          class="button bg-primary button--lg button-radius button-p--lg"
          >começar agora</router-link
        >
      </div>
    </div>
  </article>
</template>

<script>
export default {
  name: "Course",
  props: {
    course: {
      required: true,
    },
  },
};
</script>

<style scoped lang="scss"></style>
