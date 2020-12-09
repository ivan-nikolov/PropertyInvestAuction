import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private snackBar: MatSnackBar) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      retry(1),
      catchError((err: HttpErrorResponse) => {
        let message = '';
        if(err.status === 400){
          message = err.error;
        }
        else if(err.status === 401){
          message = "Login required.";
        }
        else if(err.status === 403){
          message = "You do not have permissions to access this resource."
        }
        else if(err.status === 404){
          message = "Not found."
        }
        else {
          alert('Something went wrong.');
        }

        this.openSnackBar(message);
        return throwError(err);
      })
    )
  }

  private openSnackBar(message: string, time: number = 10000) {
    this.snackBar.open(message, 'Ok', {
      duration: time,
    });
  }
}
