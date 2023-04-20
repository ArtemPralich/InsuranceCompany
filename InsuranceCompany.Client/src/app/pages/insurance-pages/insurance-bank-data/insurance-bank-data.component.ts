import { Component } from '@angular/core';

import {FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-insurance-bank-data',
  templateUrl: './insurance-bank-data.component.html',
  styleUrls: ['./insurance-bank-data.component.css']
})
export class InsuranceBankDataComponent {
  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  isLinear = false;

  constructor(private _formBuilder: FormBuilder) {}
}
