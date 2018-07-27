import { Observable } from 'rxjs/observable';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/do';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (req.headers.get('No-Auth') === 'True') {
            console.log('NoAuth');
            return next.handle(req.clone());
        }

        const token = localStorage.getItem('token');

        if (token) {
            const clone = req.clone({
                headers: req.headers.set('Authorization', `Bearer ${token}`)
            });

            return next.handle(clone)
            .do(
                succ => { },
                err => {
                    if (err.status === 401 || err.status === 402) {
                        this.router.navigateByUrl('/forbidden');
                    }
                }
            );
        } else {
            return next.handle(req);
        }
    }
}
