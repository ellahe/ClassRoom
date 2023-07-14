import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { EditCustomerComponent } from './edit-customer/edit-customer.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
const routes: Routes = [
        {path: '', pathMatch: 'full', redirectTo: 'contacts'},
	 {path: 'customers' , component: CustomerListComponent},
	 {path: 'editCustomer/:email' , component: EditCustomerComponent},
	 {path: 'addCustomer' , component: AddCustomerComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
