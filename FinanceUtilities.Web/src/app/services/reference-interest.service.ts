import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../api-endpoints';

declare interface ReferenceInterest {
    Name: string;
    Phone: string;
    Email: string;
}

@Injectable()
export class ReferenceInterestService {
 
    constructor(private http: Http) { }

    getReferenceInterests(): Promise<ReferenceInterest[]> {
        let promise = new Promise<ReferenceInterest[]>((resolve, reject) => {
            if (window.localStorage.getItem('referenceIntrests') != undefined){
                resolve(JSON.parse(window.localStorage.getItem('referenceIntrests')));
            } else {
                this.http.get(endpoints.referenceIntrests)
                .toPromise()
                .then(
                    res => {
                    window.localStorage.setItem('referenceIntrests', res['_body']);
                    resolve(res.json() as ReferenceInterest[]);
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