import { Component } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';

@Component({
    selector: 'terms-of-application',
	templateUrl: './terms-of-application.component.html'
})

export class TermsOfApplicationComponent {
	constructor( private titleService: Title, private metaTagService: Meta) { }
		
    ngOnInit() {
        this.titleService.setTitle("КредитИнфо:Услови за аплицирање");
        this.metaTagService.updateTag({name: 'description', content: "Кредитинфо е вашиот бесплатен финансиски советник. Споредете ги кредитните производи на македоснкиот пазар. Пратете ги промените на каматните стапки. Информирајте се детално за трошоците и аморт планот за даден кредитен производ."});
    }
}