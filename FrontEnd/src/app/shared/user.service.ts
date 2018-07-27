import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class UserService {

  readonly rootUrl = 'http://localhost:58272';
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(
    private http: HttpClient
  ) { }

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  isLogged(logged: boolean) {

    this.loggedIn.next(logged ? true : false);
  }

  userAuthentication(userName, password) {

    const data = 'username=' + userName + '&password=' + password + '&grant_type=password';
    const reqHeader = new HttpHeaders({'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True'});

    return this.http.post(this.rootUrl + '/token', data, {headers: reqHeader});
  }
}
