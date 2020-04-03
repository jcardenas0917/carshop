import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';
import { AuthService } from '../auth/auth.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { IUser } from '../models/user.model';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  readonly urlGet = endPoints.profile.getUser;
  private urlPost = endPoints.profile.postUser;
  public readonly userExist$ = new BehaviorSubject<boolean>(false);
  constructor(public auth: AuthService, private http: HttpClient) { }

  getUser(sub) {
    return this.http.get<IUser>(`${this.urlGet}?sub=${sub}`).pipe(tap(t => this.userExist$.next(!!t)));
  }

  postUser(user: IUser): Observable<IUser> {
    return this.http.post<IUser>(this.urlPost, user).pipe(tap(t => this.userExist$.next(true)));
  }

  updateUser(user: IUser): Observable<IUser> {
    console.log(user.id);
    return this.http.put<IUser>(`${this.urlPost}?id=${user.id}`, user).pipe(tap(t => this.userExist$.next(true)));
  }
}
