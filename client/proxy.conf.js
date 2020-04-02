module.exports = {
  '/userProfileApiMs/*': {
    target: 'http://localhost:55622',
    secure: true,
    pathRewrite: {
      '^/userProfileApiMs': '',
    },
    changeOrigin: true,
  },


};
