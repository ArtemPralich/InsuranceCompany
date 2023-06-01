import { DatePipe } from '@angular/common';
import { Provider } from '@angular/core';

export const DATE_PROVIDER: Provider = {
  provide: DatePipe,
  useValue: new DatePipe('ru') // Замените 'ru' на код вашего языка, если нужно
};