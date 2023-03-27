import { environment } from '../environments/environment';
// import { relative } from 'path';

const relativeUrl: string = environment.domains.baseurl + environment.domains.api;

export const endpoints = {
    banks: relativeUrl + 'banks',
    expenseTypes: relativeUrl + 'expensetypes',
    loanTypes: relativeUrl + 'loanTypes',
    referenceIntrests: relativeUrl + 'referenceinterests',
    login: relativeUrl + 'authenticate',
    askQuote: relativeUrl + 'askquote',
    contactUs: relativeUrl + 'sendcontactmail',
    compareLoans: relativeUrl + 'calculatetotal',
    calculateLoan: relativeUrl + 'calculateloan',
    amortizationSchedule: relativeUrl + 'amortizationSchedule',

    loans: relativeUrl + 'loans',
    loan: relativeUrl + 'loan',
    loanMarkup: relativeUrl + 'loanmarkup',
    updateMarkup: relativeUrl + 'updateloanmarkup',
    scrapeLoans: relativeUrl + 'scrapeloans',
    markLoanUpdated: relativeUrl + 'markupdated'
};
