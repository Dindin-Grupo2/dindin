<template>
  <section class="page">
    <h1 class="title text-secondary">Cursos</h1>
    <p class="text-dark">Educação financeira é tudo de bom.</p>
    <main>
      <CourseItem v-for="(item, index) in res" :key="index" :item="item" />
    </main>
  </section>
</template>

<script>
import CourseItem from "@/components/CourseItem.vue";

export default {
  name: "Courses",
  components: {
    CourseItem,
  },
  data() {
    return {
      res: [
        {
          idcurso: 1,
          titulo: "Investimentos para iniciantes",
          capa: "temp-foto-curso-1.jpg",
          nome_professor: "",
          descricao:
            "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ullam molestiae est quaerat corrupti vitae qui natus, soluta dolore illo ato dio saepe perspiciatis excepturi nam tenetur? Eaque numquam provident quis.",
        },
        {
          idcurso: 2,
          titulo: "Poupando e Rendendo",
          capa: "temp-foto-curso-2.jpg",
          nome_professor: "",
          descricao:
            "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ullam molestiae est quaerat corrupti vitae qui natus, soluta dolore illo ato dio saepe perspiciatis excepturi nam tenetur? Eaque numquam provident quis. Lorem ipsum, dolor sit amet consectetur adipisicing elit",
        },
        {
          idcurso: 3,
          titulo: "Independência Financeira",
          capa: "temp-foto-curso-3.jpg",
          nome_professor: "",
          descricao:
            "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ullam molestiae est quaerat corrupti vitae qui natus, soluta dolore illo ato dio saepe perspiciatis excepturi nam tenetur? Eaque numquam provident quis. Ullam molestiae est quaerat corrupti vitae qui natus, soluta dolore illo ato dio saepe perspiciatis excepturi nam tenetur",
        },
      ],
    };
  },
};
</script>
