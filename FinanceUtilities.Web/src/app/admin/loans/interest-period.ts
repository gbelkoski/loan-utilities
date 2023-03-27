export class InterestPeriod {
    Id: number;
    OrderNo: number;
    ReferenceInterestId: string;
    Duration: number;
    InterestPercentage: number;
    IRType: string;
    Minimum: number;
    Maximum: number;
    CurrencyCode: string;
    IsBankClient: boolean;
    LoanAmountFrom: number;
    LoanAmountTo: number;
    DurationFrom: number;
    DurationTo: number;

    // private irTypeM: string;
    get IRTypeM(): string {
        return this.IRType;
    }
    set IRTypeM(irType: string) {
        this.IRType = irType;
    }
}