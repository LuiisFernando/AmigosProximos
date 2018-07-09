import { AmigoService } from './amigo/amigo.service';
import { UserService } from './shared/user.service';
import { HomeService } from './home/home.service';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { ToastrModule } from 'ngx-toastr';
import { ModalModule, BsDropdownModule } from 'ngx-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { DropdownModule } from 'primeng/dropdown';

import { appRoutes } from './routes';

import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AmigoComponent } from './amigo/amigo.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    ForbiddenComponent,
    HomeComponent,
    AmigoComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgSelectModule,
    DropdownModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    HomeService,
    UserService,
    AmigoService,
    AuthGuard,
    {
      // objeto para setar o interceptor sempre que tiver uma chamada pro backEnd coloca a autenticação junto (Bearer)
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
