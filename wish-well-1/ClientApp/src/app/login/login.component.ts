import { Input, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  @Input() state: string = "login";
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }
}
