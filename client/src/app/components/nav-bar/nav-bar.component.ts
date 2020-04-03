import { Observable, BehaviorSubject } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { faUser, faPowerOff } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'src/app/auth/auth.service';
import { ProfileService } from 'src/app/services/profile.service';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  isCollapsed = true;
  faUser = faUser;
  faPowerOff = faPowerOff;
  profile$: Observable<any>;
  userExist$: BehaviorSubject<boolean>;
  constructor(public auth: AuthService, private user: ProfileService) { }

  ngOnInit() {
    this.userExist$ = this.user.userExist$;
  }

}
