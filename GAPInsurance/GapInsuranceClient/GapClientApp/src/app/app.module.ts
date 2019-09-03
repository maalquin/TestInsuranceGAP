import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';


import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoliciesComponent } from './policies/policies.component';
import { PolicyComponent } from './policies/policy/policy.component';
import { PolicyService } from './shared/policy.service';
import { PolicyItemsComponent } from './policies/policy-items/policy-items.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './auth/auth.guard';
import { SignInComponent } from './user/sign-in/sign-in/sign-in.component';
import { HomeComponent } from './home/home/home.component';
import { UserService } from './shared/user.service';
import { AuthInterceptor } from './auth/auth.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    PoliciesComponent,
    PolicyComponent,
    PolicyItemsComponent,
    UserComponent,
    SignInComponent,
    HomeComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    HttpClientModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot()

  ],
  entryComponents:[PolicyItemsComponent],
  providers: [
    PolicyService,
    AuthGuard,
    UserService,
   ,{
    provide : HTTP_INTERCEPTORS,
    useClass : AuthInterceptor,
    multi : true
   }],
  bootstrap: [AppComponent]
})
export class AppModule { }
