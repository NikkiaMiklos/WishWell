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
      name: this.name;
      url: this.url;
      price: this.price;
      userId: this.userId;
    }).subscribe((success) => {
      if (success) {
        this.router.navigateByUrl('/products')
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
