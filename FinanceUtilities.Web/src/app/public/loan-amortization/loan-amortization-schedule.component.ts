import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

import { LoanCalculatorService } from '../loan-calculator/loan-calculator.service';

import { AmortizationItem } from './amortization-item';
import { Loan } from '../loan';

@Component({
    selector: 'loan-amortization-schedule',
    templateUrl: './loan-amortization-schedule.component.html',
    styleUrls: ['./loan-amortization-schedule.component.css']
})

export class LoanAmortizationScheduleComponent implements OnChanges {

    @Input() loan: any;
    @Input() loanAmount: number;
    @Input() loanDuration: number;

    amortizationItems = [];
    loading = false;

    constructor(private loanService: LoanCalculatorService) {
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes.loan !== undefined) {
            this.getAmortSchedule();
        }
    }

    getAmortSchedule() {
        if (this.loan == undefined) return;
        this.amortizationItems = [];
        this.loading = true;
        this.loanService.getAmortizationItems(this.loan.Id, this.loanDuration,
                this.loanAmount, '1', this.loan.CurrencyCode, 'true')
            .then(l => {
            this.amortizationItems = l;
            this.loading = false;
        });
    }
}
