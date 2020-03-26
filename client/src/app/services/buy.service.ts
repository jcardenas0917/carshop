import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';

@Injectable({
  providedIn: 'root'
})
export class BuyService {
  readonly url = endPoints.buy.buyApi;
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.url);
  }
}
