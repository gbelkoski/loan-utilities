"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_component_1 = require("./app.component");
var loan_summary_component_1 = require("./loan-summary.component");
var landing_component_1 = require("./landing.component");
var loan_calculator_component_1 = require("./loan-calculator.component");
var loan_calculator_results_component_1 = require("./loan-calculator-results.component");
var deposits_component_1 = require("./deposits.component");
var loan_calculator_service_1 = require("./loan-calculator.service");
var bank_service_1 = require("./bank.service");
var loan_type_service_1 = require("./loan-type.service");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpModule,
                router_1.RouterModule.forRoot([
                    {
                        path: 'loans',
                        component: loan_calculator_component_1.LoanCalculatorComponent
                    },
                    {
                        path: 'deposits',
                        component: deposits_component_1.DepositsComponent
                    }
                ])
            ],
            declarations: [
                app_component_1.AppComponent,
                landing_component_1.LandingComponent,
                loan_summary_component_1.LoanSummaryComponent,
                loan_calculator_component_1.LoanCalculatorComponent,
                loan_calculator_results_component_1.LoanCalculatorResultsComponent,
                deposits_component_1.DepositsComponent
            ],
            providers: [
                loan_calculator_service_1.LoanCalculatorService,
                bank_service_1.BankService,
                loan_type_service_1.LoanTypeService
            ],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map