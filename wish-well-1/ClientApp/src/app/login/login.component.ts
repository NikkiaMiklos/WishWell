import { Input, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from './User';
import { LoginService,LoginResponse } from './LoginService';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {

  loginSvc: LoginService;
  state: string = "login";

  email: string = "";
  password: string = "";

  userCandidate: User =new User();

  httpClient: HttpClient;
  router: Router
  baseUrl: string;
  hideLoginError: boolean;
  hideCreateError: boolean;
  hidePasswordError: boolean;

  constructor(http: HttpClient, router: Router, @Inject('BASE_URL') baseUrl: string) {

    this.loginSvc = new LoginService(http, baseUrl);

    this.httpClient = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.userCandidate = {
      Name: "",
      Password: "",
      Email: ""
    }
    this.hideLoginError = true;
    this.hideCreateError = true;
    this.hidePasswordError = true;
  }
  private checkPassword() {
    /*let regex = /^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$"/
    if (regex.test(this.password) == false) {
      this.hidePasswordError = false;
      setTimeout(() => {
        this.hidePasswordError = true;
      },4000)
    }*/
  
  }
  public async tryLogin() {
    var attempt = await this.loginSvc.TryLogin(this.email, this.password);

    if (!!attempt && !!attempt.id) {
      this.router.navigateByUrl('/products');
    } else {
      this.hideLoginError = false;
      setTimeout(() => {
        this.hideLoginError = true;
      }, 4000);
    }
  }

  public async createUser() {
    let result: boolean;

    this.checkPassword();

    if (this.hidePasswordError == false) {
      return;
    }

    var attempt = await this.httpClient.post(this.baseUrl + 'user/create', {
      Name: this.userCandidate.Name,
      Email: this.userCandidate.Email,
      Password: this.userCandidate.Password
    }).toPromise();

    console.log(attempt, typeof attempt)

    if (attempt == true) {
      this.email = this.userCandidate.Email ? this.userCandidate.Email : "";
      this.password = this.userCandidate.Password ? this.userCandidate.Password : "";
      this.tryLogin();
    } else {
      this.hideCreateError = false;
      setTimeout(() => {
        this.hideLoginError = true;
      },4000)
    }
  }
}
