import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { LoansService } from './loans.service';
import { BankService } from '../../services/bank.service';
import { LoanTypeService } from '../../services/loan-type.service';
import { Loan } from './loan';

@Component({
    selector: 'app-loans',
    templateUrl: './loans.component.html',
    styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {
    public allLoans = [];
    public loans = [];
    public loanTypes = [];
    public banks = [];
    public selectedLoan: Loan;
    public selectedLoanId: number;
    public filter: LoanFilter;
    public left: string;
    public right: string;

    constructor(private loanService: LoansService,
                private router: Router,
                private bankService: BankService,
                private loanTypeService: LoanTypeService,
                ) {
                    this.bankService.getBanks().then(l => this.banks = l);
                    this.loanTypeService.getLoanTypes().then(lt => this.loanTypes = lt);
                    this.filter = new LoanFilter();
                }

    ngOnInit() {
        this.loanService.getLoans(null, '', false).then(l =>{
            this.loans = l;
            this.allLoans = l;
        });
    }

    filterLoans() {
        //this.loans = this.allLoans.filter(l=>l.BankId == this.filter.BankId);
        this.loanService.getLoans(this.filter.BankId, this.filter.LoanTypeId, this.filter.ShowOnlyMarkupChanges).then(l => this.loans = l);
    }

    clearFilters() {
        this.filter = new LoanFilter();
        this.filterLoans();
    }

    updateLoanMarkup(event, loanId) {
        this.loanService.updateLoanMarkup(loanId).then(r =>
        {
            var loan = this.loans.find(function(l){ return l.Id === loanId; });
            loan.HasChanges = r;
        });
    }

    markLoanUpdated(event, loanId) {
        this.loanService.markLoanUpdated(loanId).then(r =>
        {
            if (r.status === 200) {
                var loan = this.loans.find(function(l){ return l.Id === loanId; });
                loan.HasChanges = false;
            }
        });
    }

    openLoanDetails(loan): void {
        this.router.navigate(['/manageloan/' + loan.Id]);
    }

    compareLoanMarkup(event, loanId): void {
        this.selectedLoanId = loanId;
        //this.selectedLoan = this.loans.find(function(l){ return l.Id === loanId; });
        this.loanService.getMarkup(Number(loanId)).then(l => {
            this.left = l.OldMarkup;
            this.right = l.NewMarkup ? l.NewMarkup : "Нема содржина за овој производ";
        });
    }

    newLoan(): void {
        this.router.navigate(['/manageloan/' + -1]);
    }

    scrapeLoans(): void {
        this.loanService.scrapeAllLoans();
    }

    deleteLoan(loanId) {
        if(confirm('Избриши кредит? Дали сте сигурни?'))
        {
            this.loanService.deleteLoan(loanId).then(r =>
            {
                if (r.status === 200) {
                    this.loans = this.loans.filter(function(l){ return l.Id !== loanId; });
                }
            });
        }
    }
}

class LoanFilter{
    public BankId: string;
    public LoanTypeId: string;
    public ShowOnlyMarkupChanges: boolean;
}