import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoanCalculatorService } from './loan-calculator.service';
import { Loan } from '../../admin/loans/loan';
import {LoanAmortizationScheduleComponent} from '../loan-amortization/loan-amortization-schedule.component';
import {Location} from '@angular/common';

@Component({
    selector: 'loan',
    templateUrl: './loan.component.html',
    styleUrls: ['./loan-calculator-results.component.css']
})

export class LoanComponent implements OnInit {

    loanAmount: number;
    loanDuration: number;
    loanId: number;
    loan: any;
    hasExpenses: boolean;
    @ViewChild('amortSchedule') amortSchedule: LoanAmortizationScheduleComponent;

    private sub: any;

    constructor(private route: ActivatedRoute, private loanCalculatorService: LoanCalculatorService, private _location: Location) {}

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            var loanId = +params['id'];
            this.loanId = loanId;
            var results = window.sessionStorage.getItem('loanResults');
            var loans = JSON.parse(results);
            this.loan = loans.find(function(element) {
                    return element.Id === loanId;
                });
        });
        this.route.queryParams.subscribe(params => {
            this.loanAmount = params['amount'];
            this.loanDuration = params['duration'];
        });
        this.hasExpenses = this.loan.LoanExpenses.length > 0;
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    showAmortSchedule() {
        if (this.loan !== undefined) {
            this.amortSchedule.getAmortSchedule();
        }
    }
  
    backClicked() {
      this._location.back();
    }
}
