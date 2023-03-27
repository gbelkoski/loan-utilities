import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { endpoints } from '../../api-endpoints';
import { Loan } from '../loan';
import { AmortizationItem } from './amortization-item';

@Injectable()
export class LoanAmortizationScheduleService {
 
	constructor(private http: Http) { }
	 
	getAmortizationItems(years: number, amount: number, bankId: string, currency: string, loanTypeId: string, changeBank: string): Promise<Loan[]> {
        var urlToCall = endpoints.compareLoans +
            "?amount=" + amount +
            "&years=" + years +
            "&bankId=" + bankId +
            "&loanType=" + loanTypeId +
            "&currency=" + currency +
            "&willChangeBank=" + changeBank;
	  	return this.http.get(urlToCall)
	             .toPromise()
	             .then(response => response.json() as AmortizationItem[])
	             .catch(this.handleError);
	}
	 
	private handleError(error: any): Promise<any> {
	  return Promise.reject(error.message || error);
	}
}

