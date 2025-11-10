import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { catchError, finalize, of } from 'rxjs';

import { CounterService } from '../../services/counter.service';
import { ReflectionApiService } from './reflection-api.service';

@Component({
  selector: 'app-reflection',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reflection.component.html',
  styleUrl: './reflection.component.css'
})
export class ReflectionComponent implements OnInit {
  importers: string[] = [];
  isLoading = false;
  error: string | null = null;
  fetchAttempted = false;

  constructor(
    public counterService: CounterService,
    private reflectionApi: ReflectionApiService
  ) {}

  ngOnInit(): void {
    this.counterService.increment();
  }

  fetchImporters(): void {
    this.isLoading = true;
    this.error = null;
    this.fetchAttempted = true;

    this.reflectionApi.getImporters().pipe(
      catchError(err => {
        console.error('API Error:', err);
        this.error = 'Falló la carga de los importadores. Revise la consola del backend y del navegador (problemas de CORS?).';
        return of([]);
      }),
      finalize(() => {
        this.isLoading = false;
      })
    ).subscribe(data => {
      this.importers = data;
    });
  }
}
