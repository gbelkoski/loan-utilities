export class LoanExpense {
    Id: number;
    ExpenseTypeId: number;
    Reccuring: boolean;
    RecurmentType: number;
    Percentage: number;
    Amount: number;
    Minimum: number;
    Maximum: number;
    CurrencyCode: string;
    IsBankClient: boolean;
    LoanAmountFrom: number;
    LoanAmountTo: number;
    DurationFrom: number;
    DurationTo: number;
}