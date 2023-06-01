import { Component, Input } from '@angular/core';

import {FormBuilder, Validators, FormGroupDirective, NgForm,} from '@angular/forms';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
import { FormControl } from '@angular/forms';
import { SharedDataService } from 'src/app/service/SharedData';
import {ErrorStateMatcher} from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  private fieldName: string;

  constructor(fieldName: string, private sharedDataService: SharedDataService) {
    this.fieldName = fieldName;
  }
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    return this.sharedDataService.sharedData.some(item => item.key === this.fieldName);;
  }
}

@Component({
  selector: 'app-insurance-bank-data',
  templateUrl: './insurance-bank-data.component.html',
  styleUrls: ['./insurance-bank-data.component.css']
})
export class InsuranceBankDataComponent {
  createErrorStateMatcher(fieldName: string): MyErrorStateMatcher {
    return new MyErrorStateMatcher(fieldName, this.sharedDataService);
  }
  @Input() insuranceRequest:  InsuranceRequest;
  selectedBank: string;
  banks: string[] = ['Беларусбанк', 'Белагропромбанк', 'Приорбанк', 'Сбер Банк', 'Банк ВТБ', 'Банк БЕЛВЭБ'];

  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required]
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required],
  });

  constructor(private _formBuilder: FormBuilder, private sharedDataService: SharedDataService) {}
}
