import axios, {AxiosRequestConfig } from 'axios';

declare module 'axios' {
    export interface AxiosRequestConfig {
        anonymous?: boolean;
        development?: boolean;
    }

    export type method = 'get' | 'delete' | 'head' |  'options' | 'post'  | 'put' |  'patch' | 'link' | 'unlink'; 
}