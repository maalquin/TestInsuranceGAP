import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';
import { environment } from 'src/environments/environment';
 
@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }
 
  registerUser(user : User){
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    return this.http.post(environment.ApiUrl + 'Account/Register', body);
  }
  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    debugger;
    return this.http.post(environment.UrlToken + 'token', data, { headers: reqHeader });
  }

  getUserClaims(){
    return  this.http.get(environment.ApiUrl+'Account/GetUserClaims');
   }
 
}
