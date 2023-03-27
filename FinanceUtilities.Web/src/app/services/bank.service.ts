import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../api-endpoints';

declare interface Bank {
    Name: string;
    Phone: string;
    Email: string;
}

@Injectable()
export class BankService {

    constructor(private http: HttpClient) { }

    getBanks(): Promise<Bank[]> {

        let promise = new Promise<Bank[]>((resolve, reject) => {
            if (window.localStorage.getItem('banks') != undefined) {
                resolve(JSON.parse(window.localStorage.getItem('banks')));
            } else {
                this.http.get(endpoints.banks)
                .toPromise()
                .then(
                    res => {
                        window.localStorage.setItem('banks', JSON.stringify(res));
                        resolve(res as Bank[]);
                    },
                        msg => {
                        reject(msg);
                    }
                );
            }
        });
        return promise;
    }

    private handleError(error: any): Promise<any> {
        return Promise.reject(error.message || error);
    }
}