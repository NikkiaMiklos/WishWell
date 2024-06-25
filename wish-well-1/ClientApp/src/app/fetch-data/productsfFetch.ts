import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public Product: Product[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.Product = result;
    }, error => console.error(error));
  }
}

interface Product {
  Name: string;
  Url: URL;
  Price: number;
  UserID: string;
}
