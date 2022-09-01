import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { catchError, first, map, Observable, of } from 'rxjs';
import { Dog } from '../models/dogs.data'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  private dogServiceUrl = 'home';  // URL to web api
  list: Dog[] = Array<Dog>();

  constructor(private client: HttpClient) {
  }

  public GetDogs() {
    const url = `${this.dogServiceUrl}/getList`;
    this.client.get<Dog[]>(url)
      .pipe(
        first(),
        map((result: Dog[]) =>
        {
          this.list = result;
        }),
        catchError(this.handleError('getList', []))
      ).subscribe();
  }

  ngOnInit() {
    this.GetDogs();
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
