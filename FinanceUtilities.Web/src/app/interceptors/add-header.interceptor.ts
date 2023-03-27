import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';

export class AddHeaderInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.search('calculatetotal') === -1 && req.url.search('amortizationSchedule') === -1 && req.url.search('askquote') === -1) {
            let globals = JSON.parse(localStorage.getItem('globals'));
            // Clone the request to add the new header
            req = req.clone({ headers: req.headers.set('Authorization', 'Basic ' + globals.currentUser.authdata) });
        }
        return next.handle(req);
    }
}