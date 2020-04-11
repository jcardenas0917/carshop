import { FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { SellService } from 'src/app/services/sell.service';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {
  public todos = [];
  todoForm: FormGroup;
  brews: object;
  constructor(private brewer: SellService) {
    this.todoForm = new FormGroup({
      add: new FormControl('')
    }
    );
  }

  ngOnInit() {
    this.brewer.getBeer().subscribe(data => {
      this.brews = data;
      console.log(this.brews);
    });
  }
  addItems() {
    this.todos.push(this.todoForm.value);
    this.todoForm.patchValue({ add: '' });
  }
  markComplete(todo) {
    this.todos.forEach((item, i) => {
      if (item.add === todo) {
        this.todos.splice(i, 1);
      }
    });
  }
}
