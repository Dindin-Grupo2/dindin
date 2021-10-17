<template>
  <nav class="nav bg-primary">
    <router-link to="/">
      <img alt="Dindin" class="logo" src="../assets/logo.png" />
    </router-link>
    <div class="menu">
      <router-link to="/">Cursos</router-link>
      <router-link to="/backoffice"
        >Painel <span class="hidden-sm"> Administrativo</span></router-link
      >
    </div>
  </nav>
</template>

<script>
export default {
  name: "Navbar",
  props: {},
};
</script>

<style scoped lang="scss">
.nav {
  align-items: center;
  display: flex;
  justify-content: space-between;
  padding: 7px 20px;
  @media screen and (min-width: 992px) {
    padding: 20px 80px;
  }
}
.logo {
  @media screen and (max-width: 991px) {
    max-width: 110px;
  }
}
.menu {
  display: flex;
  gap: 20px;
  justify-content: space-between;
  @media screen and (min-width: 992px) {
    gap: 42px;
  }
  a {
    color: var(--color-white);
    font-size: 1rem;
    font-weight: 700;
    opacity: 1;
    padding: 10px 0;
    text-transform: uppercase;
    transition: opacity 0.3s ease;
    @media screen and (min-width: 992px) {
      font-size: 1.25rem;
    }
    &:hover {
      opacity: 0.8;
    }
  }
}
</style>
