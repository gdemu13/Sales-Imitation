import axios from 'axios'

const service = axios.create({
  baseURL: '',
  headers: {},
  withCredentials: true,
})

// request interceptor
service.interceptors.request.use(config => {
  // ...
  return config
}, err => {
  return Promise.reject(err)
})

// response interceptor
service.interceptors.response.use(response => {
  // ...
  return response
}, err => {
  if(err.response.status == 401) {
    localStorage.removeItem("authorisedUser");
    window.location.href = "/";
  }
  return Promise.reject(err)
})

export default service