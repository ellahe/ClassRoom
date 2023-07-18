import { HttpErrorResponse } from "@angular/common/http";

export class ErrorHappenedException extends HttpErrorResponse {

    public detailMessage: string = '';

}
