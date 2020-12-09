import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private toastService: ToastrService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      retry(1),
      catchError((err: HttpErrorResponse) => {
        let messages: Array<string> = new Array();
        if (err.status === 400) {
          if(err.error.errors) {
            for (const key of Object.keys(err.error.errors)) {
              messages = messages.concat(err.error.errors[key]);
            }
          }
          else{
            messages = [err.error];
          }
        }
        else if (err.status === 401) {
          messages = ["Login required."];
        }
        else if (err.status === 403) {
          messages = ["You do not have permissions to access this resource."];
        }
        else if (err.status === 404) {
          messages = ["Not found."]
        }
        else {
          alert('Something went wrong.');
        }

        messages.forEach(message => {
          this.toastService.error(message);
        });
        return throwError(err);
      })
    )
  }
}
