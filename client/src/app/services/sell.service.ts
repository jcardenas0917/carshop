import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';

@Injectable({
  providedIn: 'root'
})
export class SellService {

  constructor(private http: HttpClient) { }

  postCar() {
  }
}
