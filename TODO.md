# Project TODOs

## Configuration Updates Needed

### JSON Configuration

- [ ] **File**: `MyApp.Client/src/_posts/config.json`
  - Update `publicBaseUrl` to your own public base URL when deployed
  - Current value: `https://vue-spa.web-templates.io`
  - Note: This is the original template reference that needs to be replaced

### ServiceStack License

- [ ] **File**: `MyApp/Configure.AppHost.cs`
  - Replace the ServiceStack license key with your own
  - Get a free license from: https://servicestack.net/free

## URL References to Update

### Demo/Asset URLs

- [ ] **File**: `README.md`

  - Replace demo URL and asset references with your own
  - Current demo: `http://vue-spa.web-templates.io`

- [ ] **File**: `MyApp.Client/src/components/SrcLink.vue`

  - Update GitHub base URL to your own repository
  - Current: `https://github.com/NetCoreTemplates/vue-spa/blob/main`

- [ ] **File**: `MyApp.Client/src/components/NavFooter.vue`
  - Update repository reference in the footer
  - Current: References original template repository

### Blog Post References

- [ ] **File**: `MyApp.Client/src/_posts/2024-03-01_vite-press-plugin.md`

  - Multiple instances of `vue-spa.web-templates.io` to be replaced
  - GitHub asset URLs to be updated

- [ ] **File**: `MyApp.Client/src/_posts/2024-02-28_markdown-components-in-vue.md`
  - Multiple GitHub repository references to update
  - Component example links need to point to your repository

## Code TODOs

### Backend

- [ ] **File**: `MyApp.ServiceInterface/RegisterService.cs`
  - Remove or implement email confirmation logic as needed
  - Currently has `//TODO: Remove to use force email confirmation`

## Notes

- Many of the TODOs are related to replacing template references with your own project-specific URLs and assets.
- The original references are kept for attribution and sourcing purposes until replaced.
