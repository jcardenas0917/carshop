import { FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {
  public todos = [];
  todoForm: FormGroup;
  constructor() {
    this.todoForm = new FormGroup({
      add: new FormControl('')
    }
    );
  }

  ngOnInit() {

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
