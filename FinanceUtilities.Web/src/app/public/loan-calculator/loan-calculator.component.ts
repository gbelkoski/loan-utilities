import { Component, OnInit, Input } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';
import { LoanCalculatorService } from './loan-calculator.service';
import { GoogleAnalyticsEventsService } from '../../services/google-analytics-events.service';
import { LoanTypeService } from '../../services/loan-type.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { Loan } from '../loan';
import { LoanType } from '../loan-type';
import { stringify } from 'querystring';

@Component({
    selector: 'loan-calculator',
    templateUrl: './loan-calculator.component.html',
    styleUrls: ['./loan-calculator.component.css']
})

export class LoanCalculatorComponent implements OnInit{
    public loanAmount;
    public loanDuration;
    public amountUsedInCalculation: number;
    public durationUsedInCalculation: number;
    public loans = [];
    public selectedLoanType;
    public selectedCurrency;
    public loanTypes = [];
    public loading = false;
    public noResults = false;
    public errorMessage: string;

    constructor(private loanService: LoanCalculatorService,
        private loanTypeService: LoanTypeService, private route: ActivatedRoute, private location: Location,
        private googleAnalyticsEventsService: GoogleAnalyticsEventsService, private titleService: Title,
        private metaTagService: Meta, private router: Router) {
    }

    ngOnInit() {
        this.titleService.setTitle("КредитИнфо:Спореди кредити");
        this.metaTagService.updateTag({name: 'description', content: "Пополнете ја формата и добијте брза споредба на сите кредитни производи моментално на пазарот."});
        this.metaTagService.updateTag({name: 'keywords', content: "kredit info,kreditinfo,kredit kalkulator,kalkulator,sporedba,sporedba krediti,krediti sporedba,споредба кредити,кредити споредба,кредитен калкулатор,калкулатор за кредити,кредитни производи,аморт план,amort plan,амортизациски план,трошоци кредит,trosoci kredit"});
        
        this.loanTypeService.getLoanTypes().then(lt => {
            this.loanTypes = lt;
            this.route.queryParams.subscribe(params => {
                this.selectedLoanType = params['type'];
                this.selectedCurrency = params['currency'];
                this.loanAmount = params['amount'];
                this.loanDuration = params['period'];
                if(this.selectedLoanType !== undefined && this.selectedCurrency !== undefined) {
                    this.compareLoans();
                }
                else {
                    this.loadParameters();
                    this.navigateCalculator();
                }
              });
        });
    }

    resolveLoanTypeParameters() {
        if (this.selectedLoanType === 'Hous') {
            this.loanAmount = 30000;
            this.loanDuration = 20;
            this.selectedCurrency = 'EUR';
        } else if (this.selectedLoanType === 'Cons') {
            this.loanAmount = 10000;
            this.loanDuration = 10;
            this.selectedCurrency = 'EUR';
        }
    }

    loadParameters() {
        if (window.sessionStorage.getItem('loanType') != undefined) {
            this.selectedLoanType = window.sessionStorage.getItem('loanType');
        }
        else {
            this.selectedLoanType = 'Hous'
            this.resolveLoanTypeParameters();
            return;
        }

        if (window.sessionStorage.getItem('currency') != undefined)
        {
            this.selectedCurrency = window.sessionStorage.getItem('currency');
        } else {
            this.selectedCurrency = 'EUR';
        }

        if (window.sessionStorage.getItem('loanAmount') != undefined)
        {
            this.loanAmount = window.sessionStorage.getItem('loanAmount');
        } else {
            this.loanAmount = 50000;
        }

        if (window.sessionStorage.getItem('loanDuration') != undefined)
        {
            this.loanDuration = window.sessionStorage.getItem('loanDuration');
        } else {
            this.loanDuration = 15;
        }
    }

    public navigateCalculator() {
        console.log(this.loanAmount);
        this.router.navigate( ['loans'], { queryParams: { type: this.selectedLoanType, currency: this.selectedCurrency, amount: this.loanAmount, period: this.loanDuration }});
    }

    public compareLoans() {

        if(!this.validateCalculator()) return;

        if (this.loading) { return; }

        this.googleAnalyticsEventsService.emitEvent('loans', 'calculateLoans', this.selectedLoanType, 10);

        this.loading = true;
        this.loanService.getLoanResults(this.loanDuration,
            this.loanAmount,
            this.selectedCurrency,
            this.selectedLoanType)
        .then(l => {
            window.sessionStorage.setItem('loanType', this.selectedLoanType);
            window.sessionStorage.setItem('currency', this.selectedCurrency);
            window.sessionStorage.setItem('loanAmount', this.loanAmount);
            window.sessionStorage.setItem('loanDuration', this.loanDuration);
            window.sessionStorage.setItem('loanResults', JSON.stringify(l));
            this.amountUsedInCalculation = this.loanAmount;
            this.durationUsedInCalculation = this.loanDuration;
            this.loading = false;
            this.loans = l;
            this.noResults = l.length === 0;
            this.errorMessage = "Ниту еден кредитен производ не ги исполнува зададените критиериуми.<br> Ве молиме направете промена во износот и/или времетраењето.";
        })
        .catch(e => {
            this.loading = false;
            this.noResults = true;
            this.errorMessage = "Настана грешка при вашето барање. Ве молиме обидете се подоцна. Доколку проблемот сеуште постои ве молиме контактирајте не.";
        });
    }

    validateCalculator(): boolean {
        var result = true;

        if(this.loanTypes.find(lt => lt.Id == this.selectedLoanType) == undefined) {
            result = false;
            this.noResults = true;
            this.errorMessage = "Ве молиме изберете валиден тип на кредит.";
        }

        return result;
    }
}
