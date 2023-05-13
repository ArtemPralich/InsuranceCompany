import { Component, Input } from '@angular/core';

import {FormBuilder, Validators} from '@angular/forms';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuranceStatus } from 'src/app/models/InsuranceStatus';

@Component({
  selector: 'app-insurance-bank-data',
  templateUrl: './insurance-bank-data.component.html',
  styleUrls: ['./insurance-bank-data.component.css']
})
export class InsuranceBankDataComponent {
  @Input() insuranceRequest:  InsuranceRequest;
  selectedBank: string;
  insuranceStatus: InsuranceStatus = new InsuranceStatus();
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

  constructor(private _formBuilder: FormBuilder) {}
}
