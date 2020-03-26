import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';

@Injectable({
  providedIn: 'root'
})
export class SellService {

  private url = endPoints.sell.sellApi;
  constructor(private http: HttpClient) { }

  postCar() {
  }
}
