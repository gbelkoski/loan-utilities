import {  AxiosRequestConfig, method } from 'axios';

export interface OnLoadRequestProps {
    api: any;
    method: method;
    url: string;
    data?: string | null | object;
    config?: AxiosRequestConfig  | null;
}
 
export interface RequestProps {
    api: any;
    method: method;
    config?: AxiosRequestConfig | null;
}
 
export interface ResponseProps<T> {
    response: T | null;
    error: string;
    isLoading: boolean;
}

export interface RequestResponseProps<T> {
    error: string;
    isLoading: boolean;
    request: (url: string, data?: string) => Promise<T>;
}
    
export interface Response<T> {
    data: T;
}