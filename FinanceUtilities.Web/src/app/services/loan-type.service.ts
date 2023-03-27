import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../api-endpoints';

@Injectable()
export class LoanTypeService {
  constructor(private http: Http) { }

  getLoanTypes(): Promise<any> {

    let promise = new Promise((resolve, reject) => {
      if (window.localStorage.getItem('loanTypes') != undefined){
          resolve(JSON.parse(window.localStorage.getItem('loanTypes')));
      } else {
        this.http.get(endpoints.loanTypes)
        .toPromise()
        .then(
          res => {
            window.localStorage.setItem('loanTypes', res['_body']);
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

