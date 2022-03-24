const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    port: 80
  },
  publicPath: process.env.NODE_ENV === 'production'
    ? '/my-project/'
    : '/'
})