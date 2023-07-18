import { Injectable } from '@angular/core'  
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';  
import { Observable } from 'rxjs/Rx';

@Injectable()  
export class ResponseInterceptor implements HttpInterceptor {  
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {  
  
       console.log("Before sending data")  
        console.log(req);  
        return next.handle(req)  
            .retry(3)  
            .map(resp => {  
                if (resp instanceof HttpResponse) {  
                   console.log('Response is ::');  
                    console.log(resp.body)  
                }  
                return resp;  
            }).catch(err => {  
                console.log(err);  
                if (err instanceof HttpResponse)  
 {  
                    console.log(err.status);  
                    console.log(err.body);  
                }  
  
                return Observable.of(err);  
            });  
  
    }  
}  