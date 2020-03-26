import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { endPoints } from 'src/environments/endPoints';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  readonly urlGet = endPoints.profile.gerUser;
  private urlPost = endPoints.profile.gerUser;
  userProfile: object;
  email: string;
  constructor(public auth: AuthService, private http: HttpClient) { }

  getUser() {
    this.auth.userProfile$.subscribe(
      profile => this.userProfile = profile
    );
    //return this.http.get(this.url);
    return this.userProfile;
  }

  postUser() {
    //return this.http.post(this.urlPost);
  }
}
