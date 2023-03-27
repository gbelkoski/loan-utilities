import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { UserProfileComponent } from './admin/user-profile/user-profile.component';
import { BanksComponent } from './admin/banks/banks.component';
import { LoansComponent } from './admin/loans/loans.component';
import { LoanDetailsComponent } from './admin/loans/loan-details.component';
import { CompareMarkupComponent } from './admin/loans/compare-markup.component';

const routes: Routes =[
    { path: 'user-profile',     component: UserProfileComponent },
    { path: 'banks',            component: BanksComponent },
    { path: 'manageloans',      component: LoansComponent },
    { path: 'manageloan/:id',   component: LoanDetailsComponent },
    { path: 'comparemarkup/:id',component: CompareMarkupComponent },
    { path: '',               redirectTo: 'landing', pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
