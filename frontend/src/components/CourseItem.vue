<template>
  <article class="grid grid-cols gap-xl">
    <div class="g-col g-col-xs-12 g-col-md-4">
      <img alt="img" :src="`images/${item.capa}`" />
    </div>
    <div class="grid gap-xl g-col g-col-xs-12 g-col-md-8">
      <h2 class="subtitle text-secondary">{{ item.titulo }}</h2>
      <p class="w-light">
        {{ item.descricao }}
      </p>
      <div>
        <router-link
          to="/"
          class="button bg-primary button--lg button-radius button-p--lg"
          >começar agora</router-link
        >
      </div>
    </div>
  </article>
</template>

<script>
export default {
  name: "CourseItem",
  props: {
    item: {
      required: true,
    },
  },
};
</script>

<style scoped lang="scss"></style>
