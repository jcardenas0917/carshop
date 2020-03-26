import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { BuyService } from 'src/app/services/buy.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {

  users: object;
  constructor(public auth: AuthService, private buy: BuyService) { }

  ngOnInit() {
    this.buy.getUsers().subscribe(data => {
      this.users = data;
      console.log(this.users);
    });
  }

}
