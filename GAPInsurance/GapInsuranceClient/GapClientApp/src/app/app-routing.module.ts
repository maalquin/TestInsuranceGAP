import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PoliciesComponent } from './policies/policies.component';
import { PolicyComponent } from './policies/policy/policy.component';

const routes: Routes = [
  {path:'',redirectTo:'policy', pathMatch:'full'},
  {path:'policies',component:PoliciesComponent},
  {path:'policy',children:[ 
    {path:'',component:PolicyComponent},
    {path:'edit/:id',component:PolicyComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
