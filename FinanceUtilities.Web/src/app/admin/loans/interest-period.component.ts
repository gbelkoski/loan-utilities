import { Component, OnInit, Input } from '@angular/core';

import { Currency } from '../currencies/currency';

@Component({
    selector: 'app-interest-period',
    templateUrl: './interest-period.component.html',
    styleUrls: ['./interest-period.component.css']
})
export class InterestPeriodComponent implements OnInit {
    @Input() interestPeriod: any;
    public currencies = [];
    public selectedIRType;

    constructor() {
        this.loadCurrencies();
    }

    ngOnInit() {
    }

    private loadCurrencies() {
        this.currencies.push(new Currency("MKD", "MKD"));
        this.currencies.push(new Currency("EUR", "EUR"));
    }
}
