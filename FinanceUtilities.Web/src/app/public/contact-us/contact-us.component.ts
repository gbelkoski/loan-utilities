import { Title, Meta } from '@angular/platform-browser';

import { Component } from '@angular/core';
import { ContactUsService } from './contact-us.service';
import { GoogleAnalyticsEventsService } from '../../services/google-analytics-events.service';
import { ContactRequest } from '../contactRequest';

@Component({
	selector: 'contact-us',
	templateUrl: './contact-us.component.html'
})

export class ContactUsComponent {

    public personName: string;
    public personPhone: string;
    public personMail: string;
    public mailContent: string;
    public loading = false;
    public sending = false;
    public sent = false;
    public errorSending = false;
    public message: string;

    constructor(private contactUsService: ContactUsService, private googleAnalyticsEventsService: GoogleAnalyticsEventsService, 
        private titleService: Title, private metaTagService: Meta) { }

    ngOnInit() {
        this.titleService.setTitle("КредитИнфо:Контакт");
        this.metaTagService.updateTag({name: 'description', content: "Контактирајте не за дополнителни информации или бесплатен совет поврзан со кредитните произвоиди."});
    }

    public sendEmail() {
        if (this.sent) {
            this.message = 'Веќе испративте мејл.';
            return;
        }

        this.googleAnalyticsEventsService.emitEvent('misc', 'contactEmailSent', 'contactEmailSent');

        this.errorSending = false;
        this.sending = true;
        let contactRequest = new ContactRequest();
        contactRequest.Name = this.personName;
        contactRequest.Phone = this.personPhone;
        contactRequest.Email = this.personMail;
        contactRequest.Content = this.mailContent;
        this.contactUsService.sendContactEmail(contactRequest)
            .then(l => {
                this.sending = false;
                this.sent = true;
                alert("Пораката е успешно испратена!");
            }).catch(e => {
                this.sending = false;
                this.errorSending = true;
                this.message = 'Настана грешка при испраќање на мејлот.';
            });
    }
}