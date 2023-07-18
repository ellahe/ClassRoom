import { Injectable } from '@angular/core'
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { ErrorHappenedException } from './error-happened-exception';

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        console.log("Before sending data")
        console.log(req);
        return next.handle(req)
            .retry(3)
            .map(resp => {
                if (resp instanceof ErrorHappenedException) {
                    console.log('Response is ::');
                    console.log(resp.message);
                    console.log(resp.detailMessage);
                    alert(resp.message);
                    alert(resp.detailMessage);
                }
                return resp;
            }).catch(err => {
                console.log(err);
                if (err instanceof HttpResponse) {
                    console.log(err.status);
                    console.log(err.body);
                }

                return Observable.of(err);
            });

    }
}  