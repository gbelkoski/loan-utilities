import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AdminModule } from '../admin/admin.module';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LandingComponent } from './landing/landing.component';
import { LoanCalculatorComponent } from './loan-calculator/loan-calculator.component';
import { LoanCalculatorResultsComponent } from './loan-calculator/loan-calculator-results.component';
import { LoanComponent } from './loan-calculator/loan.component';
import { LoanQuoteComponent } from './loan-calculator/loan-quote.component';
import { DepositsComponent } from './deposits/deposits.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { FAQComponent } from './FAQ/faq.component';
import { TermsOfApplicationComponent } from './terms-of-application/terms-of-application.component';
import { LoanAmortizationScheduleComponent } from './loan-amortization/loan-amortization-schedule.component';
import { SpinnerComponent } from './spinner/spinner.component';

import { LoanCalculatorService } from './loan-calculator/loan-calculator.service';
import { BankService } from '../services/bank.service';
import { LoanTypeService } from '../services/loan-type.service';
import { LoanQuoteService } from './loan-calculator/loan-quote.service';
import { ContactUsService } from './contact-us/contact-us.service';
import { AuthenticationService } from '../services/authentication.service';
import { GoogleAnalyticsEventsService } from '../services/google-analytics-events.service';

import { AddHeaderInterceptor } from '../interceptors/add-header.interceptor';

const publicRoutes: Routes = [
        { path: '', component: LandingComponent },
        { path: 'loans', component: LoanCalculatorComponent },
        { path: 'loan/:id', component: LoanComponent },
        { path: 'deposits', component: DepositsComponent },
        { path: 'aboutus', component: AboutUsComponent },
        { path: 'contactus', component: ContactUsComponent },
        { path: 'termsofapplication', component: TermsOfApplicationComponent },
        { path: 'faq', component: FAQComponent },
        { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    CustomFormsModule,
    HttpClientModule,
    RouterModule.forRoot(publicRoutes),
    AdminModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    LandingComponent,
    LoanCalculatorComponent,
    LoanCalculatorResultsComponent,
    LoanComponent,
    LoanQuoteComponent,
    LoanAmortizationScheduleComponent,
    DepositsComponent,
    FAQComponent,
    ContactUsComponent,
    AboutUsComponent,
    TermsOfApplicationComponent,
    SpinnerComponent
  ],
  providers: [
    LoanCalculatorService,
    BankService,
    LoanTypeService,
    LoanQuoteService,
    ContactUsService,
    AuthenticationService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: AddHeaderInterceptor,
        multi: true,
    },
    GoogleAnalyticsEventsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
