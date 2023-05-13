import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { FormControl } from '@angular/forms';
import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
@Component({
  selector: 'app-insurance-client-info',
  templateUrl: './insurance-client-info.component.html',
  styleUrls: ['./insurance-client-info.component.css']
})
export class InsuranceClientInfoComponent {
  @Input() insuranceRequest:  InsuranceRequest;
  insuranceStatus: InsuranceStatus = new InsuranceStatus();
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);


  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required]
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required],
  });

  constructor(private _formBuilder: FormBuilder){
    console.log(this.insuranceRequest);
  }

  myFunc(){
    console.log(this.insuranceRequest);
  }
}
