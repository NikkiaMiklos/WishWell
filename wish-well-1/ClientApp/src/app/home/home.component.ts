import { Input, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  name: string = "";
  url: string = "" ;
  price: string = "" ;
  userId?: number;

  httpClient: HttpClient;
  router: Router
  baseUrl: string;

  constructor(http: HttpClient, router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.router = router;
    this.baseUrl = baseUrl;
  }

  public async newProduct() {
    let result: boolean;

    await this.httpClient.post(this.baseUrl + 'product/create', {
      Name: this.name,
      Url: this.url,
      Price: this.price +"",
      UserId: 2,
    }).subscribe((success) => {
      if (success == 'true') {
        this.router.navigateByUrl('wishes');
      }
    });
  }
}

interface Product {
  name: string;
  url: string;
  price: string;
  userId: number;
}
