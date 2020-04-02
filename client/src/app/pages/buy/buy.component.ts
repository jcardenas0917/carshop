import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { BuyService } from 'src/app/services/buy.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {
  names = ['mike', 'john', 'luis', 'emily'];
  completed: boolean;
  fullNames = [{
    name: 'Mike',
    last: 'Smith'
  },
  {
    name: 'Will',
    last: 'Jackson'
  },
  {
    name: 'Mark',
    last: 'Anthony'
  }
  ];
  constructor(public auth: AuthService, private buy: BuyService) { }
  ngOnInit() {
    this.completed = false;
  }
  onClick(clickedName) {
    this.completed = !this.completed;
    console.log(clickedName);
    console.log(this.completed);
  }
}
