import { Component } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-insurance-client-info',
  templateUrl: './insurance-client-info.component.html',
  styleUrls: ['./insurance-client-info.component.css']
})
export class InsuranceClientInfoComponent {
  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required],
  });

  
  constructor(private _formBuilder: FormBuilder){
      
  }
}
