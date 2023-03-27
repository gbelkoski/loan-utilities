import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DiffMatchPatchModule } from 'ng-diff-match-patch';

import { AppRoutingModule } from '../app.routing';
import { ComponentsModule } from './components/components.module';

import { AdminComponent } from './admin.component';

import { UserProfileComponent } from './user-profile/user-profile.component';
import { BanksComponent } from './banks/banks.component';
import { LoansComponent } from './loans/loans.component';
import { LoanDetailsComponent } from './loans/loan-details.component';
import { CompareMarkupComponent } from './loans/compare-markup.component';
import { InterestPeriodComponent } from './loans/interest-period.component';

import { BankService } from '../services/bank.service';
import { LoansService } from './loans/loans.service';
import { LoanTypeService } from '../services/loan-type.service';
import { ExpenseTypeService } from '../services/expense-type.service';
import { ReferenceInterestService } from '../services/reference-interest.service';

@NgModule({
  declarations: [
    AdminComponent,
    UserProfileComponent,
    BanksComponent,
    LoansComponent,
    LoanDetailsComponent,
    CompareMarkupComponent,
    InterestPeriodComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    DiffMatchPatchModule
  ],
  providers: [
      BankService,
      LoansService,
      LoanTypeService,
      ExpenseTypeService,
      ReferenceInterestService
  ],
  bootstrap: [AdminComponent]
})
export class AdminModule { }
