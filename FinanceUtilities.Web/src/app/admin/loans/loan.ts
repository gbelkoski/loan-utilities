import { InterestPeriod } from './interest-period';
import { LoanExpense } from './loan-expense';

export class Loan {
    Id: string;
    Name: string;
    BankId: number;
    BankName: string;
    LoanTypeId: string;
    LoanType: string;
    LastChange: Date;
    Link: string;
    CurrencyCode: string;
    MinDuration: number;
    MaxDuration: number;
    MinimumAmount: number;
    MaximumAmount: number;
    NewMarkupDate: Date;
    ParticipationPercentage: number;
    InterestPeriods: InterestPeriod[];
    LoanExpenses: LoanExpense[];

    constructor() {
        this.InterestPeriods = new Array();
        this.LoanExpenses = new Array();
    }
}