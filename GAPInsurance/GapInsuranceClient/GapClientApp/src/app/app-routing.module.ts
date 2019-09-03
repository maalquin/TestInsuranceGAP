import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PoliciesComponent } from './policies/policies.component';
import { PolicyComponent } from './policies/policy/policy.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in/sign-in.component';

import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path : '', redirectTo:'/login', pathMatch : 'full'},
   { path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    { path : '', redirectTo:'/login', pathMatch : 'full'},
    {path:'policies',component:PoliciesComponent},
    {path:'policy',canActivate:[AuthGuard],children:[ 
      {path:'',component:PolicyComponent},
      {path:'edit/:id',component:PolicyComponent},
    ]}
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
