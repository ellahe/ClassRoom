import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClerkDTO } from 'src/app/DTOS/clerk-dto';
import { Observable, observable } from 'rxjs';

const baseUrl = "https://localhost:44325/api/";

@Injectable({
  providedIn: 'root'
})

export class ClerkService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<ClerkDTO[]> {
    return this.http.get<ClerkDTO[]>(baseUrl);
  }

  getByUserNameAndPassword(userName: string, password : string) : Observable<ClerkDTO> {
    const params = new HttpParams()
   .set('userName', userName)
   .set('password', password);

    return this.http.get<ClerkDTO>(`${baseUrl}` +'Clerical/Get', {params});
  }

  add(data: any) : Observable<any>{
    return this.http.post<any>(`${baseUrl}` +'Clerical/Add', data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.post<any>(`${baseUrl}` +'Clerical/update', data);
  }

  delete(id: any): Observable<any> {
    return this.http.get(`${baseUrl}` +'Clerical/Delete', id);
  }

  findByUserName(title: any): Observable<ClerkDTO[]> {
    return this.http.get<ClerkDTO[]>(`${baseUrl}?title=${title}`);
  }

}
