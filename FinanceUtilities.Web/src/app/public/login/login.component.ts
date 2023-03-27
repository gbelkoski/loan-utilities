import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { LoginRequest } from './login';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})


export class LoginComponent {
    public username;
    public password;

    constructor(private authenticationService: AuthenticationService, private router: Router) {
    }

    public login() {
        let login = new LoginRequest;
        login.UserName = this.username;
        login.Password = this.password;
        this.authenticationService.login(this.username, this.password)
            .then(l => {
                this.authenticationService.setCredential(this.username, this.password);
                alert('Успешно логирање!');
                this.router.navigate(['/manageloans/']);
            }).catch(e => {
                alert(e);
            });
    }
}
