import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClerkDTO } from 'src/app/DTOS/clerk-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
const baseUrl = 'http://localhost:8080/api/';
export class ClerkService {


  constructor(private http: HttpClient) { }

  getAll(): Observable<ClerkDTO[]> {
    return this.http.get<ClerkDTO[]>(baseUrl);
  }

  get(id: any): Observable<ClerkDTO> {
    return this.http.get(`${baseUrl}/${id}`);
  }

  add(data: any): Observable<ClerkDTO> {
    return this.http.post(baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  findByUserName(title: any): Observable<ClerkDTO[]> {
    return this.http.get<ClerkDTO[]>(`${baseUrl}?title=${title}`);
  }
}
