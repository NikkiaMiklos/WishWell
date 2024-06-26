import { Input, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  state: string = "login";

  email: string = "";
  password: string = "";

  httpClient: HttpClient;
  router: Router
  baseUrl: string;

  constructor(http: HttpClient,router:Router, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.router = router;
    this.baseUrl = baseUrl;
  }

  public async tryLogin() {
    let result: boolean;

    await this.httpClient.post(this.baseUrl + 'session/login', {
      Email: this.email,
      Password: this.password
    }).subscribe((success) => {
      if (success) {
        this.router.navigateByUrl('/products')
      }
    });
  }
}

interface User {
  ID?: number,
  Name?: string,
  Email: string,
  Password: string
}
