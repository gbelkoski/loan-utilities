import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../../api-endpoints';
import { LoanQuote } from '../loanQuote';

@Injectable()
export class LoanQuoteService {

    constructor(private http: Http) {}

    askQuote(quote: LoanQuote): Promise <any> {
        const urlToCall = endpoints.askQuote;

        return this.http.post(urlToCall, quote)
            .toPromise()
            .then(response => console.log(response))
            .catch(this.handleError);
    }

    private handleError(error: any): Promise < any > {
        return Promise.reject(error.message || error);
    }
}