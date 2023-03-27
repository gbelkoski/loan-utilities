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
var LoanCalculatorResultsComponent = /** @class */ (function () {
    function LoanCalculatorResultsComponent(service) {
        this.service = service;
        this.loans = [];
    }
    LoanCalculatorResultsComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], LoanCalculatorResultsComponent.prototype, "loans", void 0);
    LoanCalculatorResultsComponent = __decorate([
        core_1.Component({
            selector: 'loan-results',
            templateUrl: './loan-calculator-results.component.html',
            styles: [".results {\n\n}\n    .item {\n        display: flex;\n    }\n        .item ul {\n            margin: 0;\n            padding: 0;\n            list-style: none;\n        }\n            .item.website {\n                width: 20 %\n}\n                .item.loan - percentage {\n                    width: 25 %;\n                }\n                    .item.installment {\n                        width: 20 %;\n                    }\n                        .item.details {\n        width: 35 %;\n    }"]
        }),
        __metadata("design:paramtypes", [loan_calculator_service_1.LoanCalculatorService])
    ], LoanCalculatorResultsComponent);
    return LoanCalculatorResultsComponent;
}());
exports.LoanCalculatorResultsComponent = LoanCalculatorResultsComponent;
//# sourceMappingURL=loan-calculator-results.component.js.map