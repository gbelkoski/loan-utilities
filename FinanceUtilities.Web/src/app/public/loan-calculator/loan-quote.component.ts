import { Component, Input, ViewChild, ElementRef } from '@angular/core';
import { Loan } from '../../admin/loans/loan';
import { LoanQuoteService } from './loan-quote.service';
import { GoogleAnalyticsEventsService } from '../../services/google-analytics-events.service';
import { LoanQuote } from '../loanQuote';

@Component({
    selector: 'loan-quote',
    templateUrl: './loan-quote.component.html'
})

export class LoanQuoteComponent {

    @ViewChild('closeQuoteModal') closeQuoteModal: ElementRef;

    @Input() loanId: number;
    @Input() loanAmount: number;
    @Input() loanDuration: number;
    @Input() currency: string;

    public personName: string;
    public personPhone: string;
    public personMail: string;
    public personCity: string;
    public mailContent: string;
    public termsAccepted: boolean;
    public selectedLoan: Loan;
    public loading = false;
    public sending = false;
    public sent = false;
    public errorSending = false;
    public message: string;

    constructor(private loanQuoteService: LoanQuoteService, private googleAnalyticsEventsService: GoogleAnalyticsEventsService) {}

    public requestQuote() {

        this.googleAnalyticsEventsService.emitEvent('loans', 'quoteRequested', 'quoteRequested', this.loanId);

        this.errorSending = false;
        this.sending = true;
        let quote = new LoanQuote();
        quote.Name = this.personName;
        quote.Phone = this.personPhone;
        quote.City = this.personCity;
        quote.Email = this.personMail;
        quote.Content = this.mailContent;
        quote.LoanId = this.loanId;
        quote.LoanAmount = this.loanAmount;
        quote.Duration = this.loanDuration;
        this.loanQuoteService.askQuote(quote)
        .then(l => {
            this.sending = false;
            this.sent = true;
            this.closeQuoteModal.nativeElement.click();
        }).catch(e => {
            this.sending = false;
            this.errorSending = true;
            this.message = e._body;
        });
    }
}
