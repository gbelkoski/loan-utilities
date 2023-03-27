import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ViewChild, ElementRef} from '@angular/core';

import { LoanCalculatorService } from './loan-calculator.service';
import { LoanQuoteService } from './loan-quote.service';
import { Loan } from '../loan';
import {LoanAmortizationScheduleComponent} from '../loan-amortization/loan-amortization-schedule.component';


@Component({
    selector: 'loan-results',
    templateUrl: './loan-calculator-results.component.html',
    styleUrls: ['./loan-calculator-results.component.css']
})

export class LoanCalculatorResultsComponent {

    @ViewChild('closeQuoteModal') closeQuoteModal: ElementRef;

    @Input() loans = [];
    @Input() loanAmount: number;
    @Input() loanDuration: number;
    @Input() currency: string;
    @Input() bankId: string;
    @Input() noResults: boolean;
    @Input() errorMessage: string;
    @Input() loadingResults: boolean;

    @ViewChild('amortSchedule') amortSchedule: LoanAmortizationScheduleComponent;

    public selectedLoan: Loan;
    public selectedLoanId: number;
    public selectedCurrencyCode: string;
    public loading = false;
    public amortizationItems = [];

    constructor(private loanQuoteService: LoanQuoteService,
        private loanCalculatorService: LoanCalculatorService,
        private router: Router) {
    }

    public loanDetails(loan) {
        this.router.navigate(['/loan', loan.Id], { queryParams: { amount: this.loanAmount, duration: this.loanDuration } });
    }

    public selectLoan(item) {
        if (this.selectedLoan != item) {
            this.selectedLoan = item;
            if (item !== undefined) {
                this.selectedLoanId = item.Id;
                this.selectedCurrencyCode = item.CurrencyCode;
            }
        }
    }
}
