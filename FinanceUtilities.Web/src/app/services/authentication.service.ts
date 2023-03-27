import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../api-endpoints';

import { LoginRequest } from '../public/login/login';

@Injectable()
export class AuthenticationService {
    constructor(private http: Http) { }

    login(username: string, password: string): Promise<any> {

        return this.http.post(endpoints.login, { username, password })
            .toPromise()
            .catch(this.handleError);
    }

  private handleError(error: any): Promise<any> {
    return Promise.reject(error.message || error);
  }

  setCredential(username, password) {
      var authdata = window.btoa(username + ':' + password);

      localStorage.setItem('globals', JSON.stringify({
          currentUser: {
              username: username,
              authdata: authdata
          }
      }));
  };

}

