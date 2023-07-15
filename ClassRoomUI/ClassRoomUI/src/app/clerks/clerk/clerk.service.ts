import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClerkDTO } from 'src/app/DTOS/clerk-dto';
import { Observable } from 'rxjs';

const baseUrl = "https://localhost:44325/api/";

@Injectable({
  providedIn: 'root'
})

export class ClerkService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<ClerkDTO[]> {
    return this.http.get<ClerkDTO[]>(baseUrl);
  }

  get(id: any): Observable<ClerkDTO> {
    return this.http.get(`${baseUrl}` +'Clerical/Get', id);
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
