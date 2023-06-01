import { Injectable } from '@angular/core';
import { ValidationModel } from '../models/ValidationModel';

@Injectable()
export class SharedDataService {
  public sharedData: ValidationModel[] = [];

  constructor() {
    var a = new ValidationModel();
    a.key = "1";
    a.value = "2";
    this.sharedData.push(a);
  }
}