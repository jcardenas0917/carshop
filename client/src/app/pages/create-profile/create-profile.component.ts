import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services/profile.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create-profile',
  templateUrl: './create-profile.component.html',
  styleUrls: ['./create-profile.component.css']
})
export class CreateProfileComponent implements OnInit {
  userForm: FormGroup;
  email: string;
  submitted = false;
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
    this.auth.getUser$().subscribe(t => { this.userForm.patchValue({ email: t.email, sub: t.sub }); });
  }

  onSubmit() {
    if (this.userForm.valid) {
      this.user.postUser(this.userForm.value).subscribe();
      this.userForm.reset();
      this.router.navigate(['/profile']);
      alert('Submitted!');
    }
  }
  ngOnInit() {
  }
}

