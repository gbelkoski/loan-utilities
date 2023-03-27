import axios, {AxiosRequestConfig } from 'axios';

export enum apiType {
    Public = '',
    Admin = 'admin'
}

export const publicApi = axios.create({
    baseURL: window.ENV.BaseApiUrl,
    timeout:5000
});

publicApi.defaults.headers['Content-Type'] = 'application/json';

publicApi.interceptors.request.use((config: AxiosRequestConfig) => {

    return config;

  }, function (error) {
    // Do something with request error
    return Promise.reject(error);
});

publicApi.interceptors.response.use(function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    
    return response;
  }, function (error) {

    error.response.data = {...error.response.data, 'api': apiType.Public}
    // Any status codes that falls outside the range of 2xx cause this function to trigger

    return Promise.reject(error);
});