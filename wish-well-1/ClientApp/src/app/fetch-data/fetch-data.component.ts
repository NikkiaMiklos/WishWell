import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public Products: Product[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product/ByUserId?userId=1').subscribe(result => {
      this.Products = result;
    }, error => console.error(error));
  }
}

interface Product {
  name: string;
  url: URL;
  price: number;
  userId: string;
}
