import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/switchMap';

import { LoansService } from './loans.service';
import { BankService } from '../../services/bank.service';
import { LoanTypeService } from '../../services/loan-type.service';
import { ExpenseTypeService } from '../../services/expense-type.service';
import { ReferenceInterestService } from '../../services/reference-interest.service';
import { Loan } from './loan';
import { Currency } from '../currencies/currency';
import { InterestPeriod } from './interest-period';
import { LoanExpense } from './loan-expense';

@Component({
    selector: 'app-loan-details',
    templateUrl: './loan-details.component.html',
    styleUrls: ['./loan-details.component.css']
})
export class LoanDetailsComponent implements OnInit {
    @Input() loan: Loan;
    public banks = [];
    public loanTypes = [];
    public currencies = [];
    public interestTypes = [];
    public referenceInterestRates = [];
    public expenseTypes = [];
    public recurmentTypes = [];
    public selectedBank;
    public selectedLoanType;
    public dummyId = -1;
    public saveSuccess = false;

    constructor(private route: ActivatedRoute,
                private router: Router,
                private loanService: LoansService,
                private bankService: BankService,
                private loanTypeService: LoanTypeService,
                private expenseTypeService: ExpenseTypeService,
                private referenceInterestService: ReferenceInterestService) {
        this.bankService.getBanks().then(l => this.banks = l);
        this.loanTypeService.getLoanTypes().then(lt => this.loanTypes = lt);
        this.referenceInterestService.getReferenceInterests().then(l => this.referenceInterestRates = l);
        this.expenseTypeService.getExpenseTypes().then(e => this.expenseTypes = e);
        this.loadCurrencies();
        this.loadInterestTypes();
        this.loadRecurmentTypes();
    }

    ngOnInit() {
        let id = this.route.snapshot.paramMap.get('id');

        if (Number(id) == -1) {
            let newLoan = new Loan();
            newLoan.Id = '-1';
            this.loan = newLoan;
        } else {
            this.loanService.getDetails(Number(id)).then(l => {
                this.loan = l;
                this.loadFields();
            });
        }
    }

    goToLoans() {
        this.router.navigate(['/manageloans']);
    }

    private loadCurrencies() {
        this.currencies.push(new Currency('MKD', 'MKD'));
        this.currencies.push(new Currency('EUR', 'EUR'));
    }

    private loadInterestTypes() {
        this.interestTypes.push({Id: 0, Description: 'Фиксна'});
        this.interestTypes.push({Id: 1, Description: 'Варијабилна'});
    }

    private loadRecurmentTypes() {
        this.recurmentTypes.push({Id: 0, Description: 'Нема'});
        this.recurmentTypes.push({Id: 1, Description: 'Годишно'});
        this.recurmentTypes.push({Id: 2, Description: 'Месечно'});
    }

    loadFields() {
        if (this.loan !== undefined) {
            var bank = this.banks.find(x => x.Id === this.loan.BankId);
            var loanType = this.loanTypes.find(x => x.Id === this.loan.LoanTypeId);
            if (bank !== undefined) {
                this.selectedBank = bank.Id;
            }
            if (loanType !== undefined) {
                this.selectedLoanType = loanType.Id;
            }
        }
    }

    addInterestPeriod() {
        console.log('add interest period');
        const newPeriod = new InterestPeriod;
        newPeriod.Id = this.dummyId;
        newPeriod.LoanAmountFrom = this.loan.MinimumAmount;
        newPeriod.LoanAmountTo = this.loan.MaximumAmount;
        newPeriod.DurationFrom = this.loan.MinDuration;
        newPeriod.DurationTo = this.loan.MaxDuration;
        newPeriod.IsBankClient = true;
        newPeriod.CurrencyCode = this.loan.CurrencyCode;
        this.loan.InterestPeriods.push(newPeriod);
        this.dummyId = this.dummyId - 1;
    }

    addLoanExpense() {
        console.log('add loan expense');
        const newExpense = new LoanExpense;
        newExpense.Id = this.dummyId;
        newExpense.LoanAmountFrom = this.loan.MinimumAmount;
        newExpense.LoanAmountTo = this.loan.MaximumAmount;
        newExpense.DurationFrom = this.loan.MinDuration;
        newExpense.DurationTo = this.loan.MaxDuration;
        newExpense.IsBankClient = true;
        newExpense.CurrencyCode = this.loan.CurrencyCode;
        this.loan.LoanExpenses.push(newExpense);
        this.dummyId = this.dummyId - 1;
    }

    removeInterestPeriod(event, periodId) {
        this.loan.InterestPeriods = this.loan.InterestPeriods.filter(ip => ip.Id !== periodId);
    }

    removeLoanExpense(event, expenseId) {
        this.loan.LoanExpenses = this.loan.LoanExpenses.filter(e => e.Id !== expenseId);
    }

    copyInterestPeriod(id: number) {
        var interestPeriod = this.loan.InterestPeriods.find(function(ip) {
            return ip.Id === id;
          });
          const newPeriod = new InterestPeriod;
          newPeriod.Id = this.dummyId;
          newPeriod.IRType = interestPeriod.IRType;
          newPeriod.InterestPercentage = interestPeriod.InterestPercentage;
          newPeriod.Duration = interestPeriod.Duration;
          newPeriod.ReferenceInterestId = interestPeriod.ReferenceInterestId;
          newPeriod.Minimum = interestPeriod.Minimum;
          newPeriod.Maximum = interestPeriod.Maximum;
          newPeriod.LoanAmountFrom = interestPeriod.LoanAmountFrom;
          newPeriod.LoanAmountTo = interestPeriod.LoanAmountTo;
          newPeriod.DurationFrom = interestPeriod.DurationFrom;
          newPeriod.DurationTo = interestPeriod.DurationTo;
          newPeriod.IsBankClient = interestPeriod.IsBankClient;
          newPeriod.CurrencyCode = interestPeriod.CurrencyCode;
          this.loan.InterestPeriods.push(newPeriod);
          this.dummyId = this.dummyId - 1;
    }

    copyLoanExpense(id: number) {
        var loanExpense = this.loan.LoanExpenses.find(function(e) {
            return e.Id === id;
          });
        const newExpense = new LoanExpense;
        newExpense.Id = this.dummyId;
        newExpense.ExpenseTypeId = loanExpense.ExpenseTypeId;
        newExpense.Percentage = loanExpense.Percentage;
        newExpense.Amount = loanExpense.Amount;
        newExpense.Reccuring = loanExpense.Reccuring;
        newExpense.RecurmentType = loanExpense.RecurmentType;
        newExpense.LoanAmountFrom = loanExpense.LoanAmountFrom;
        newExpense.LoanAmountTo = loanExpense.LoanAmountTo;
        newExpense.DurationFrom = loanExpense.DurationFrom;
        newExpense.DurationTo = loanExpense.DurationTo;
        newExpense.IsBankClient = loanExpense.IsBankClient;
        newExpense.CurrencyCode = loanExpense.CurrencyCode;
        this.loan.LoanExpenses.push(newExpense);
        this.dummyId = this.dummyId - 1;
    }

    save(loan): void {
        this.loan.BankId = this.selectedBank;
        this.loan.LoanTypeId = this.selectedLoanType;
        this.loanService.update(loan).then(id => {
            this.saveSuccess = true;
            this.loan.Id = id;
            alert('снимањето е успешно!');
        });
    }

    onIRTypeChange(newValue, interestPeriod) {
        console.log('ir change: ' + newValue);
        if (newValue == 0) {
            interestPeriod.ReferenceInterestId = 'NL00NL';
        }
    }

    onInterestPercentageChange(newValue, interestPeriod) {
        console.log('ip change: ' + newValue);
        if (interestPeriod.IRType == 0) {
            interestPeriod.Minimum = newValue;
            interestPeriod.Maximum = newValue;
        }
    }
}
