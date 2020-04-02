import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services/profile.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth/auth.service';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userForm: FormGroup;
  profile$: Observable<any>;
  constructor(private user: ProfileService, public auth: AuthService) {

  }

  ngOnInit() {
    this.profile$ = this.auth.getUser$().pipe(switchMap((t => this.user.getUser(t.sub))));
  }
}
