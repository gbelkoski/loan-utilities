import { Component, OnInit } from '@angular/core';

import { BankService } from '../../services/bank.service';

@Component({
  selector: 'app-banks',
  templateUrl: './banks.component.html',
  styleUrls: ['./banks.component.css']
})
export class BanksComponent implements OnInit {
    public banks = [];

    constructor(private bankService: BankService) { }

    ngOnInit() {
        this.bankService.getBanks().then(l => this.banks = l);
    }
}
