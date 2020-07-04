module.exports = {
    runtimeCompiler:true,

    pluginOptions: {
      i18n: {
        locale: 'en',
        fallbackLocale: 'en',
        localeDir: 'locales',
        enableInSFC: false
      }
    },

    devServer: {
      open: process.platform === 'darwin',
      host: '0.0.0.0',
      port: 8080, // CHANGE YOUR PORT HERE!
      https: true,
      hotOnly: false,
      proxy: {
        // proxy all requests starting with /api to jsonplaceholder
        '/api': {
          target: 'http://test.si.ge/api/',
          changeOrigin: true,
          pathRewrite: {
            '^/api': ''
          },
          logLevel: 'debug'
        },
        '/media': {
          target: 'http://test.si.ge/media/',
          changeOrigin: true,
          pathRewrite: {
            '^/media': ''
          },
          logLevel: 'debug'
        }
      }
    }
}
