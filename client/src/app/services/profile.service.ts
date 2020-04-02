import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';
import { AuthService } from '../auth/auth.service';
import { Observable } from 'rxjs';
import { IUser } from '../models/user.model';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  readonly urlGet = endPoints.profile.getUser;
  private urlPost = endPoints.profile.postUser;
  userProfile: any;
  email: string;
  constructor(public auth: AuthService, private http: HttpClient) { }

  getUser(sub) {
    return this.http.get<IUser>(this.urlGet + '?sub=' + sub).pipe(tap(t => console.log(t)));
  }

  postUser(user: IUser): Observable<IUser> {
    return this.http.post<IUser>(this.urlPost, user);
  }
}
