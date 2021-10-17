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
import { mapActions } from "vuex";
import Footer from "@/components/Footer.vue";
import Navbar from "@/components/Navbar.vue";

export default {
  name: "App",
  components: {
    Footer,
    Navbar,
  },
  methods: {
    ...mapActions({ getCourses: "getCourses" }),
  },
  async mounted() {
    await this.getCourses({ v: this }).then(() => {});
  },
};
</script>

<style lang="scss"></style>
