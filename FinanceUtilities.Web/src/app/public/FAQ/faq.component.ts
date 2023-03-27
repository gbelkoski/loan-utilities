import { Component } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';

@Component({
	selector: 'faq',
	templateUrl: './faq.component.html'
})

export class FAQComponent {

	constructor( private titleService: Title, private metaTagService: Meta) { }
		
    ngOnInit() {
        this.titleService.setTitle("КредитИнфо:ЧПП");
        this.metaTagService.updateTag({name: 'description', content: "Проверете ја секцијата ЧПП за општи информации за кредитите, каматни стапки, трошоци, амортизациони планови."});
    }
}
