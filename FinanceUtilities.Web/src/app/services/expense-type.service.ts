import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../api-endpoints';

@Injectable()
export class ExpenseTypeService {
	 
	constructor(private http: Http) { }
	 
	getExpenseTypes(): Promise<any> {
        let promise = new Promise((resolve, reject) => {
            if (window.localStorage.getItem('expenseTypes') != undefined){
                resolve(JSON.parse(window.localStorage.getItem('expenseTypes')));
            } else {
                this.http.get(endpoints.expenseTypes)
                .toPromise()
                .then(
                    res => {
                    window.localStorage.setItem('expenseTypes', res['_body']);
                    resolve(res.json());
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

