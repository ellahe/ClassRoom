import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClerkComponent } from './clerks/clerk/clerk.component';
import { AppComponent } from './app.component';

const routes: Routes = [
	 {path: 'home' , component: AppComponent},
	 {path: 'addClerk' , component: ClerkComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule]
})
export class AppRoutingModule { }
