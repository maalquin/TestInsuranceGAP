import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private Http:HttpClient) { }

  getCustomerList(){
    return this.Http.get(environment.ApiUrl + 'insurance/GetCustomers').toPromise();
  }
}
