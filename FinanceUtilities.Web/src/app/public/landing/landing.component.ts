import { Component } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})

export class LandingComponent {

  public loanAmount;
  public loanDuration
  public selectedLoanType;
  public currency : string;

  constructor(private router: Router, private titleService: Title,
    private metaTagService: Meta) {
  }

  ngOnInit() {
    this.titleService.setTitle("КредитИнфо:Почетна");
    this.metaTagService.updateTag({name: 'description', content: "Кредитинфо е вашиот бесплатен финансиски советник. Споредете ги кредитните производи на македоснкиот пазар. Пратете ги промените на каматните стапки. Информирајте се детално за трошоците и аморт планот за даден кредитен производ."});
  }

  navigate(type: string) {
    this.setDefaultLoanTypeParameters(type);
    this.router.navigate( ['loans'], { queryParams: { type: type, currency: this.currency, amount: this.loanAmount, period: this.loanDuration }});
  }

  setDefaultLoanTypeParameters(type: string) {
    if (type === 'Hous') {
        this.loanAmount = 30000;
        this.loanDuration = 20;
        this.currency = 'EUR';

    } else if (type === 'Cons') {
        this.loanAmount = 10000;
        this.loanDuration = 7;
        this.currency = 'EUR';

    } else if (type === 'Auto') {
      this.loanAmount = 10000;
      this.loanDuration = 5;
      this.currency = 'EUR';
    }
  }

}
