module.exports = {
    runtimeCompiler:true,
    outputDir: '../wwwroot',
    devServer: {
      open: process.platform === 'darwin',
      host: '0.0.0.0',
      port: 8080, // CHANGE YOUR PORT HERE!
      https: true,
      hotOnly: false,
      proxy: {
        // proxy all requests starting with /api to jsonplaceholder
        '/api': {
          target: 'https://localhost:5001/api/',
          changeOrigin: true,
          pathRewrite: {
            '^/api': ''
          },
          logLevel: 'debug'
        },
        '/media': {
          target: 'https://localhost:5001/media/',
          changeOrigin: true,
          pathRewrite: {
            '^/media': ''
          },
          logLevel: 'debug'
        }
      }
    }
}
