import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../../api-endpoints';

import { Loan } from './loan';
import { LoanMarkup } from './loanMarkup';

@Injectable()
export class LoansService {

    constructor(private http: HttpClient) { }

    getLoans(bankId: string, loanTypeId: string, showOnlyMarkupChanges: boolean): Promise<Loan[]> {
        var lt = '';
        var b = '';
        if(loanTypeId !== undefined) {
            lt = loanTypeId;
        }
        if(bankId !== undefined) {
            b = bankId;
        }
        return this.http.get(endpoints.loans + '?bankId=' + b + '&loanTypeId=' + lt + '&showOnlyMarkupChanges=' + showOnlyMarkupChanges)
            .toPromise()
            .then(response => response as Loan[])
            .catch(this.handleError);
    }

    getDetails(id: number): Promise<Loan> {
        return this.http.get(endpoints.loans + '/' + id)
            .toPromise()
            .then(response => response as Loan)
            .catch(this.handleError);
    }
    
    getMarkup(id: number): Promise<LoanMarkup> {
        return this.http.get(endpoints.loanMarkup + '/' + id)
            .toPromise()
            .then(response => response as LoanMarkup)
            .catch(this.handleError);
    }

    update(loan: Loan): Promise<string> {
        return this.http.post(endpoints.loan, loan)
            .toPromise()
            .then(response => response as string)
            .catch(this.handleError);
    }

    updateLoanMarkup(loanId: string): Promise<string> {
        return this.http.post(endpoints.updateMarkup + '?id=' + loanId, undefined)
            .toPromise()
            .then(response => response as string)
            .catch(this.handleError);
    }

    markLoanUpdated(loanId: string): Promise<any> {
        return this.http.post(endpoints.markLoanUpdated + '?id=' + loanId, undefined, {observe: 'response', responseType: 'text'})
            .toPromise()
            .catch(this.handleError);
    }

    scrapeAllLoans(): Promise<any> {
        return this.http.post(endpoints.scrapeLoans, undefined).toPromise().catch(this.handleError);
    }

    deleteLoan(loanId: string): Promise<any> {
        return this.http.delete(endpoints.loans + '/' + loanId, {observe: 'response', responseType: 'text'})
        .toPromise()
        .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        alert('Настана грешка');
        console.log(error);
        return Promise.reject(error.message || error);
    }
}