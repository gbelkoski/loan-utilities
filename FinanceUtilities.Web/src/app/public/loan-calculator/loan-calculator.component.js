"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var loan_calculator_service_1 = require("./loan-calculator.service");
var bank_service_1 = require("./bank.service");
var loan_type_service_1 = require("./loan-type.service");
var LoanCalculatorComponent = /** @class */ (function () {
    function LoanCalculatorComponent(loanService, bankService, loanTypeService) {
        this.loanService = loanService;
        this.bankService = bankService;
        this.loanTypeService = loanTypeService;
        this.loans = [];
        this.banks = [];
        this.loanTypes = [];
    }
    LoanCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.bankService.getBanks().then(function (l) { return _this.banks = l; });
        this.loanTypeService.getLoanTypes().then(function (lt) { return _this.loanTypes = lt; });
        this.selectedChangeBank = 'yes';
        this.selectedCurrency = 'EUR';
        this.loanAmount = 50000;
        this.loanPeriod = 15;
    };
    LoanCalculatorComponent.prototype.compareLoans = function () {
        var _this = this;
        var willChangeBank = String(this.selectedChangeBank == 'yes');
        this.loanService.getLoanResults(this.loanPeriod, this.loanAmount, this.selectedBank, this.selectedCurrency, this.selectedLoanType, willChangeBank)
            .then(function (l) { return _this.loans = l; });
    };
    LoanCalculatorComponent.prototype.onCurrencySelectionChange = function (m) {
        console.log(m);
        this.selectedCurrency = m;
    };
    LoanCalculatorComponent.prototype.onChangeBankSelectionChange = function (entry) {
        this.selectedChangeBank = entry;
    };
    LoanCalculatorComponent = __decorate([
        core_1.Component({
            selector: 'loan-calculator',
            templateUrl: './loan-calculator.component.html'
        }),
        __metadata("design:paramtypes", [loan_calculator_service_1.LoanCalculatorService,
            bank_service_1.BankService,
            loan_type_service_1.LoanTypeService])
    ], LoanCalculatorComponent);
    return LoanCalculatorComponent;
}());
exports.LoanCalculatorComponent = LoanCalculatorComponent;
//# sourceMappingURL=loan-calculator.component.js.map