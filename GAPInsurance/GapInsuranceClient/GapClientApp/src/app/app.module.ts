import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoliciesComponent } from './policies/policies.component';
import { PolicyComponent } from './policies/policy/policy.component';
import { PolicyService } from './shared/policy.service';
import { PolicyItemsComponent } from './policies/policy-items/policy-items.component';


@NgModule({
  declarations: [
    AppComponent,
    PoliciesComponent,
    PolicyComponent,
    PolicyItemsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    HttpClientModule,
    BsDatepickerModule.forRoot(),
  ],
  entryComponents:[PolicyItemsComponent],
  providers: [
    PolicyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
