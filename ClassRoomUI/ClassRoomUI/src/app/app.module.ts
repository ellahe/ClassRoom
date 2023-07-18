import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ClerkComponent } from './clerks/clerk/clerk.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { ClerkService } from './clerks/clerk/clerk.service';
import { MenuComponent } from './menu/menu.component';
import { ErrorHandleService } from './Infrastructure/error-handle-service';
import { ResponseInterceptor } from './Infrastructure/ResponseInterceptor ';
import { HeaderInterceptor } from './Infrastructure/headerInterceptor';

@NgModule({
  declarations: [
    AppComponent,
    ClerkComponent,
    MenuComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule
  ],
  providers: [
    ClerkService,
    ErrorHandleService,
    { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true } , 
    {provide:HTTP_INTERCEPTORS,useClass:ResponseInterceptor,multi:true}  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

