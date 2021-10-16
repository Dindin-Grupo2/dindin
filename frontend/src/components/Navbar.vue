<template>
  <nav id="nav">
    <router-link to="/">Home</router-link>
    <router-link to="/courses">Cursos</router-link>
    <router-link to="/backoffice">Painel Administrativo</router-link>
  </nav>
</template>

<script>
export default {
  name: "Navbar",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
