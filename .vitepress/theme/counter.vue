<script setup>
import DefaultTheme from "vitepress/theme";

const { Layout } = DefaultTheme;
</script>

<template>
  <Layout>
    <template #layout-bottom>
    <div class="container">
      <span id="busuanzi_container_site_pv">
        本站总访问量
        <span id="busuanzi_value_site_pv"></span>
        次
      </span>
    </div>
    </template>
  </Layout>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center; /* Center horizontally */
  align-items: center; /* Center vertically */
  text-align: center;
}

#busuanzi_container_site_pv {
  font-family: var(--vp-font-family, sans-serif);
  color: var(--vp-c-text, black);
}
</style>