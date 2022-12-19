import { ProductsComponent } from './products/products/products.component';
import { PointOfSaleComponent } from './bills/point-of-sale/point-of-sale.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { CreateKupacComponent } from './buyers/create-kupac/create-kupac.component';
import { RegisterComponent } from './register/register/register.component';
import { BillListComponent } from './bills/bill-list/bill-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [

  {
    path: '',
    runGuardsAndResolvers: 'always',
    children: [  
      {path:'',component:LoginComponent},
      { path: 'register', component: RegisterComponent },
      {path: 'create-kupac', component: CreateKupacComponent,canActivate:[AuthGuard]},
      {path: 'products', component: ProductsComponent,canActivate:[AuthGuard]},
      {path: 'pos', component: PointOfSaleComponent,canActivate:[AuthGuard]},
      {path: 'bills', component: BillListComponent,canActivate:[AuthGuard]}
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
