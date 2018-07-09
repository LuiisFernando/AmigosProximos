import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {

  readonly rootUrl = 'http://localhost:58272';

  constructor(
    private http: HttpClient
  ) { }

  userAuthentication(userName, password) {

    const data = 'username=' + userName + '&password=' + password + '&grant_type=password';
    const reqHeader = new HttpHeaders({'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True'});

    return this.http.post(this.rootUrl + '/token', data, {headers: reqHeader});
  }
}
