import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private headers: HttpHeaders;
  private url = 'http://localhost:56091/api/values';
  constructor(private httpClient: HttpClient) { 
  this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  }
  get() {
    return this.httpClient.get<any>(this.url)
    .pipe(catchError(error => {
      return throwError({
        message: 'No access to resource'
      });
    }));
  }
  update(item) {
    return this.httpClient.put<any>(this.url, item, { headers: this.headers });
  }
  create(item) {
    return this.httpClient.post<any>(this.url, item, { headers: this.headers });
  }
  delete(id) {
    return this.httpClient.delete<any>(`${this.url}/${id}`, { headers: this.headers });
  }

}
