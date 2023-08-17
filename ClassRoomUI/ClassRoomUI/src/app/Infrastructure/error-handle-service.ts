import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ErrorDetails } from './error-happened-exception';

@Injectable()
export class ErrorHandleService implements ErrorHandler {

    constructor(private injector: Injector) { }

    handleError(error: any) {
        let router = this.injector.get(Router);
        console.log('URL: ' + router.url);
       

        if (error instanceof ErrorDetails) {
            //Backend returns unsuccessful response codes such as 404, 500 etc.				  
            console.error('ErrorDetails: ', error.status);
            console.error('ErrorMessage body:', error.message);
            console.error('ErrorDetails body:', error.detailMessage);
        } 
        if (error instanceof HttpErrorResponse) {
            //Backend returns unsuccessful response codes such as 404, 500 etc.				  
            console.error('Backend returned status code: ', error.status);
            console.error('Response body:', error.message);
        } 
       
        else {
            //A client-side or network error occurred.	          
            console.error('An error occurred:', error.message);
        }
    }
}