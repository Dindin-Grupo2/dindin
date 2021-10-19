<template>
  <section class="page">
    <h1 class="title text-secondary">Novo Curso</h1>
    <main class="grid grid-cols gap-xl m-t-xl">
      <div class="g-col g-col-xs-12 g-col-md-10">
        <form class="form">
          <div>
            <label for="title">Título</label>
            <input
              class="form-field"
              type="text"
              placeholder="Título do curso"
              id="title"
            />
          </div>
          <div class="m-t-xs">
            <label for="cover">Capa</label>
            <input
              class="form-field"
              type="text"
              placeholder="Insira a URL da Capa"
              id="cover"
            />
          </div>
          <div class="m-t-xs">
            <label for="teacher">Professor</label>
            <input
              class="form-field"
              type="text"
              placeholder="Nome do professor"
              id="teacher"
            />
          </div>
          <div class="m-t-xs">
            <label for="description">Descrição</label>
            <textarea
              class="form-field"
              placeholder="Acrescente uma breve descrição"
              id="description"
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
      </div>
    </main>
  </section>
</template>

<script>
export default {
  name: "Form",
  computed: {},
  methods: {
    updateCourses() {
      return;
    },
  },
};
</script>
