"use strict";
var __decorate = (this && this.__decorate) || function(decorators, target, key, desc) {
    var c = arguments.length,
        r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
        d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else
        for (var i = decorators.length - 1; i >= 0; i--)
            if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function(k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/toPromise");
var appSettings_1 = require("./appSettings");
var LoanCalculatorService = /** @class */ (function() {
    function LoanCalculatorService(http) {
        this.http = http;
        this.loanCalculateUrl = appSettings_1.AppSettings.API_ENDPOINT + 'calculatetotal'; // URL to web api
    }
    LoanCalculatorService.prototype.getLoanResults = function(years, amount, bankId, currency, loanTypeId, changeBank) {

        var urlToCall = this.loanCalculateUrl + "?amount=" + amount + "&years=" + years + "&bankId=" + bankId + "&loanType=" + loanTypeId + "&currency=" + currency + "&willChangeBank=" + changeBank;
        return this.http.get(urlToCall)
            .toPromise()
            .then(function(response) { return response.json(); })
            .catch(this.handleError);
    };
    LoanCalculatorService.prototype.handleError = function(error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    };
    LoanCalculatorService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], LoanCalculatorService);
    return LoanCalculatorService;
}());
exports.LoanCalculatorService = LoanCalculatorService;
//# sourceMappingURL=loan-calculator.service.js.map