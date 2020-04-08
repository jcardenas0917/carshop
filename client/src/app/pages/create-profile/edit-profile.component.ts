import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services/profile.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth/auth.service';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./create-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  userForm: FormGroup;
  email: string;
  submitted = false;
  getProfile$: Observable<any>;

  constructor(private user: ProfileService, public auth: AuthService, private router: Router) {
    this.userForm = new FormGroup({
      id: new FormControl(''),
      email: new FormControl(''),
      fullName: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      state: new FormControl('', Validators.required),
      sub: new FormControl('', Validators.required),
    });
    this.getProfile$ = this.auth.getUser$().pipe(switchMap((t => this.user.getUser(t.sub))));
    this.getProfile$.subscribe(t => {
      this.userForm.patchValue({
        id: t.id,
        email: t.email,
        fullName: t.fullName,
        address: t.address,
        city: t.city,
        state: t.state,
      });
    });
  }
  onSubmit() {
    this.user.updateUser(this.userForm.value).subscribe();
    this.userForm.reset();
    this.router.navigate(['/profile']);
    alert('Submitted!');
  }
  ngOnInit() {
  }
}

