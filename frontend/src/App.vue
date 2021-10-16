<template>
  <div id="app">
    <Navbar />
    <router-view />
    <Footer />
  </div>
</template>

<script>
import Footer from "@/components/Footer.vue";
import Navbar from "@/components/Navbar.vue";

export default {
  components: {
    Footer,
    Navbar,
  },
};
</script>

<style lang="scss"></style>
