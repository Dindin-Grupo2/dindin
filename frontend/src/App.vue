<template>
  <div id="app">
    <Navbar />
    <section class="grid-container">
      <router-view />
    </section>
    <Footer />
  </div>
</template>

<script>
import Footer from "@/components/Footer.vue";
import Navbar from "@/components/Navbar.vue";

export default {
  name: "App",
  components: {
    Footer,
    Navbar,
  },
};
</script>

<style lang="scss"></style>
