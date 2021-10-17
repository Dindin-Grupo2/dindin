<template>
  <article class="grid grid-cols gap-xl">
    <div class="g-col g-col-xs-12 g-col-md-7 iframe">
      <iframe
        width="560"
        height="315"
        :src="`https://www.youtube-nocookie.com/embed/${getVideoCode(
          lesson.link
        )}?controls=0`"
        :title="lesson.titulo"
        frameborder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
        allowfullscreen
      >
      </iframe>
    </div>
    <div class="grid gap-xl g-col g-col-xs-12 g-col-md-5">
      <h2 class="subtitle text-secondary">{{ lesson.titulo }}</h2>
      <p class="w-light">
        {{ lesson.descricao }}
      </p>
    </div>
  </article>
</template>

<script>
export default {
  name: "Lesson",
  props: {
    lesson: {
      required: true,
    },
  },
  methods: {
    getVideoCode(link) {
      if (!link) return;
      const arr = link.split("/");
      return arr[arr.length - 1];
    },
  },
};
</script>

<style scoped lang="scss">
.iframe {
  overflow: hidden;
  padding-top: 56.25%;
  position: relative;
  width: 100%;
  iframe,
  video {
    height: 100%;
    left: 0;
    position: absolute;
    top: 0;
    width: 100%;
  }
}
</style>
