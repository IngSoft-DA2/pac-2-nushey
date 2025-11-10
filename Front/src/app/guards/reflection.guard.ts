import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CounterService } from '../services/counter.service';

export const reflectionGuard: CanActivateFn = (route, state) => {
  const counterService = inject(CounterService);
  const router = inject(Router);
  const currentCount = counterService.getCount();

  if (currentCount >= 20) {
    console.warn(`Acceso bloqueado. Límite de 20 visitas alcanzado.`);
    router.navigate(['/']);
    return false;
  }

  return true;
};
