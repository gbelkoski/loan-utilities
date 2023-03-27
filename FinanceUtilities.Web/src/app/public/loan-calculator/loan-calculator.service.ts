import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../../api-endpoints';
import { Loan } from '../loan';
import { AmortizationItem } from '../loan-amortization/amortization-item';

@Injectable()
export class LoanCalculatorService {

    constructor(private http: HttpClient) { }

    getLoanResults(years: number, amount: number,
        currency: string, loanTypeId: string): Promise<Loan[]> {
        const urlToCall = endpoints.compareLoans + '?amount=' + amount + '&years=' + years +
         '&loanType=' + loanTypeId + '&currency=' + currency;
        return this.http.get(urlToCall)
            .toPromise()
            .then(response => response as Loan[])
            .catch(this.handleError);
    }

	getAmortizationItems(loanId: number, years: number, amount: number,
		bankId: string, currency: string, changeBank: string): Promise<AmortizationItem[]> {
        const urlToCall = endpoints.amortizationSchedule + '?amount=' + amount + '&years=' + years + '&loanId=' + loanId
		+ '&bankId=' + bankId + '&currency=' + currency + '&willChangeBank=' + changeBank;
	  	return this.http.get(urlToCall)
	             .toPromise()
	             .then(response => response as AmortizationItem[])
	             .catch(this.handleError);
	}
	 
	private handleError(error: any): Promise<any> {
	  return Promise.reject(error.message || error);
	}
}

