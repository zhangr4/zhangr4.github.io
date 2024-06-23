import DefaultTheme from "vitepress/theme";
import Counter from "./counter.vue";
import { inBrowser } from "vitepress";
import busuanzi from "busuanzi.pure.js";

export default {
  extends: DefaultTheme,
  Layout: Counter,
  enhanceApp({ app, router, siteData }) {
    if (inBrowser) {
      router.onAfterRouteChanged = () => {
        busuanzi.fetch();
      };
    }
  },
};
