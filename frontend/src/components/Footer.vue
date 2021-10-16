<template>
  <nav class="nav bg-primary">
    <router-link to="/">
      <img alt="Dindin" class="logo-full" src="../assets/logo-full.png" />
    </router-link>
  </nav>
</template>

<script>
export default {
  name: "Footer",
  props: {},
};
</script>

<style scoped lang="scss">
.nav {
  align-items: center;
  display: flex;
  justify-content: center;
  padding: 15px 20px;
  @media screen and (min-width: 992px) {
    justify-content: space-between;
    padding: 53px 128px;
  }
}
.logo-full {
  @media screen and (max-width: 991px) {
    max-width: 140px;
  }
}
</style>
