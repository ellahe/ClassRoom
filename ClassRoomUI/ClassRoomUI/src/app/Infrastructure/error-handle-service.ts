import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogOverviewDialog } from './dialog-viwer/dialog-viwer.component';
import {
    HttpEvent,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class ErrorHandleService implements HttpInterceptor {

    constructor(private injector: Injector, private dialog: MatDialog) { }

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                retry(1),
                catchError((error: HttpErrorResponse) => {
                    let errorMessage = '';
                    if (error) {

                        if (error.error instanceof ErrorEvent) {
                            // client-side error
                            errorMessage = `Error: ${error.error.message}`;

                        } else {
                            // server-side error
                            errorMessage = `Error Status: ${error.status}\nMessage: ${error.message}`;
                            // this.dialog.open(DialogOverviewDialog, {

                            //     data: { message: errorMessage, detailMessage: 'detailMessage' }
                            // });

                        }
                    }
                    return throwError(errorMessage);
                })
            )
    }


    //     counter: number =0;
    //    async handleError(error: any) {
    //         let router =  this.injector.get(Router);
    //         if (error instanceof HttpErrorResponse) {
    //             //Backend returns unsuccessful response codes such as 404, 500 etc.				  

    //             if(error.error != null){
    //                 this.openDialog();
    //             }
    //         } 
    //         else {
    //             //A client-side or network error occurred.	          
    //             console.error('An error occurred:', error.message);

    //         }

    //     }
    // async openDialog(){

    // }
}