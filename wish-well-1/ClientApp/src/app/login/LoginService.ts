import { HttpClient } from '@angular/common/http';
import { GetCookie, SetCookie } from '../utility/Cookies';

export class LoginResponse {
  name?: string;
  id?: string;
  token?: string;
}

export class LoginService{
  http: HttpClient;
  loginResponse: LoginResponse | undefined;
  session: string | undefined;
  baseUrl: string;
  constructor(httpClient: HttpClient, baseUrl:string) {
    this.http = httpClient;
    this.baseUrl = baseUrl;
    this.setSession();
  }

  private setSession() {
    let session: string | null = GetCookie("session");
    if (session && typeof session == "string" && session.length > 0 && session != "null") {
      this.loginResponse = JSON.parse(session) as LoginResponse;
    }
  }

  public async TryLogin(email: string, password: string) {
    try {
      if (this.loginResponse instanceof LoginResponse) {
        this.loginResponse;
      }

      let response:LoginResponse = await this.http.post<LoginResponse>(this.baseUrl + 'session/login', {
        Email: email,
        Password: password
      }).toPromise() as LoginResponse;

      this.loginResponse = response;
      SetCookie("session", JSON.stringify(response));

      return this.loginResponse;

    } catch (e: any) {
      return;
    }
  }

  public IsLoggedIn(){
    return !!this.loginResponse;
  }

}
