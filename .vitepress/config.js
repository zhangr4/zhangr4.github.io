import { defineConfig } from "vitepress";

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Personal Profile",
  text: "zhangr4",
  head: [
    [
      "link",
      {
        rel: "apple-touch-icon",
        sizes: "180x180",
        href: "/favicons/apple-touch-icon.png",
      },
    ],
    [
      "link",
      {
        rel: "icon",
        type: "image/png",
        sizes: "32x32",
        href: "/favicons/favicon-32x32.png",
      },
    ],
    [
      "link",
      {
        rel: "icon",
        type: "image/png",
        sizes: "16x16",
        href: "/favicons/favicon-16x16.png",
      },
    ],
    [
      "link",
      {
        rel: "icon",
        type: "image/png",
        sizes: "192x192",
        href: "/favicons/android-chrome-192x192.png",
      },
    ],
    ["link", { rel: "manifest", href: "/favicons/site.webmanifest" }],
    ["link", { rel: "preconnect", href: "https://fonts.googleapis.com" }],
    [
      "link",
      { rel: "preconnect", href: "https://fonts.gstatic.com", crossorigin: "" },
    ],
    [
      "link",
      {
        href: "https://fonts.googleapis.com/css2?family=Roboto&display=swap",
        rel: "stylesheet",
      },
    ],
  ],
  themeConfig: {
    nav: [
      { text: "Home", link: "/" },
      // { text: "Examples", link: "/markdown-examples" },
      { text: "About Me", link: "/about-me" },
    ],
    search: {
      provider: "local",
    },
    sidebar: [
      {
        text: "All blogs",
        items: [
          {
            text: "Use WebView2 In Console Application",
            link: "Blogs/use-webview2-in-console-application",
          },
          {
            text: "Verify Git Commit",
            link: "Blogs/verify-git-commit",
          },
          {
            text: "Time-based One-time Password (TOTP) Demystified",
            link: "Blogs/time-based-one-time-password",
          },
          {
            text: "Fixing .NET 8 Azure App Service TLS Issue",
            link: "Blogs/fixing-dotnet-8-azure-app-service-tls-Issue",
          }
        ]
      }
    ],
    socialLinks: [
      { icon: "github", link: "https://github.com/zhangr4" },
      {
        icon: {
          svg: '<svg role="img" viewBox="0 -6 24 24" xmlns="http://www.w3.org/2000/svg"><title>Dribbble</title><path d="M4.7 8.73v-1h3.52v5.69c-.78.37-1.95.64-3.59.64C1.11 14.06 0 11.37 0 8.03 0 4.69 1.13 2 4.63 2c1.62 0 2.64.33 3.28.66v1.05c-1.22-.5-2-.73-3.28-.73-2.57 0-3.48 2.21-3.48 5.06 0 2.85.91 5.05 3.47 5.05.89 0 1.98-.07 2.53-.34V8.73Zm10.98.69h.03c2.22.2 2.75.95 2.75 2.23 0 1.21-.76 2.41-3.14 2.41-.75 0-1.83-.19-2.33-.39v-.94c.47.17 1.22.36 2.33.36 1.62 0 2.06-.69 2.06-1.42 0-.71-.22-1.21-1.77-1.34-2.26-.2-2.73-1-2.73-2.08 0-1.11.72-2.31 2.92-2.31.73 0 1.56.09 2.25.39v.94c-.61-.2-1.22-.36-2.27-.36-1.55 0-1.88.57-1.88 1.34 0 .69.28 1.04 1.78 1.17Zm8.58-3.33v.85h-2.42v4.87c0 .95.53 1.34 1.5 1.34.2 0 .42 0 .61-.03v.89c-.17.03-.5.05-.69.05-1.31 0-2.5-.6-2.5-2.13v-5H19.2v-.48l1.56-.44V3.9l1.08-.31v2.5h2.42Zm-13.17-.03v6.41c0 .54.19.7.67.7v.89c-1.14 0-1.72-.47-1.72-1.72V6.06h1.05Zm.25-2.33c0 .44-.34.78-.78.78a.76.76 0 0 1-.77-.78c0-.44.32-.78.77-.78s.78.34.78.78Z"/></svg>',
        },
        link: "https://gist.github.com/zhangr4",
      },
    ],
  },
});
