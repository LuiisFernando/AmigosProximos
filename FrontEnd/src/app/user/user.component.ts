import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit() {
    localStorage.removeItem('token');
  }

  onSubmit(userName, password) {
    this.userService.userAuthentication(userName, password).subscribe(
      (data: any) => {
        localStorage.setItem('token', data.access_token);
        this.userService.isLogged(true);
        this.router.navigate(['/home']);
      },
      (err: HttpErrorResponse) => {
        console.log(err);
      });
  }

}
