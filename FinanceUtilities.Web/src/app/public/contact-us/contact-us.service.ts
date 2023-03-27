import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../../api-endpoints';
import { ContactRequest } from '../contactRequest';

@Injectable()
export class ContactUsService {

    constructor(private http: Http) {}

    sendContactEmail(contactRequest: ContactRequest): Promise <any> {
        const urlToCall = endpoints.contactUs;

        return this.http.post(urlToCall, contactRequest)
            .toPromise()
            .then(response => console.log(response))
            .catch(this.handleError);
    }

    private handleError(error: any): Promise < any > {
        return Promise.reject(error.message || error);
    }
}