import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClerkComponent } from './clerks/clerk/clerk.component';

const routes: Routes = [
   {path: '', pathMatch: 'full', redirectTo: 'contacts'},
	 {path: 'addClerk' , component: ClerkComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
