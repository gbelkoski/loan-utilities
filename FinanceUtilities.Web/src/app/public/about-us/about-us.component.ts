import { Component } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';

@Component({
	selector: 'about-us',
	templateUrl: './about-us.component.html'
})

export class AboutUsComponent {
	constructor( private titleService: Title, private metaTagService: Meta) { }
		
    ngOnInit() {
        this.titleService.setTitle("КредитИнфо:За нас");
        this.metaTagService.updateTag({name: 'description', content: "Кредитинфо е вашиот бесплатен финансиски советник. Споредете ги кредитните производи на македоснкиот пазар. Пратете ги промените на каматните стапки. Информирајте се детално за трошоците и аморт планот за даден кредитен производ."});
    }
}