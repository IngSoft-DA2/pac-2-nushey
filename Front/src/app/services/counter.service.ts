import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CounterService {
  private visitCount = 0;

  constructor() { }

  increment(): void {
    this.visitCount++;
    console.log(`Reflection page visited ${this.visitCount} times.`);
  }

  getCount(): number {
    return this.visitCount;
  }
}
