import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReflectionApiService {
  private readonly apiUrl = 'https://localhost:7152/api/reflection/importers';

  constructor(private http: HttpClient) { }

  getImporters(): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl);
  }
}
