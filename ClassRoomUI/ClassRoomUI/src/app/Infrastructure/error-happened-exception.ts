import { HttpErrorResponse } from "@angular/common/http";

export class ErrorDetails extends HttpErrorResponse {

    public detailMessage: string = '';

}
