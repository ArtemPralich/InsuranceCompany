import { Component, OnInit, ViewChild } from '@angular/core';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { ActivatedRoute } from '@angular/router';
import {FormBuilder, Validators} from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { DocumentService } from 'src/app/service/DocumentService';

@Component({
  selector: 'app-insurance',
  templateUrl: './insurance.component.html',
  styleUrls: ['./insurance.component.css']
})
export class InsuranceComponent implements OnInit  {
  insuranceRequest:  InsuranceRequest;
  parentProp = 'Hello, child!';

  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required],
  });
  isLinear = false;


  constructor(public insuranceRequestService: InsuranceRequestService, private route: ActivatedRoute, 
    private _formBuilder: FormBuilder, public documentService: DocumentService){
      
  }

  ngOnInit(){

    let id:string = "";
    this.route.params.subscribe(
      params => {
          id = params['id'];
      });

    this.insuranceRequestService.GetInsuranceRequestById(id).subscribe(res => {
      this.insuranceRequest = res;
      console.log(this.insuranceRequest);
    });
  }

  save(){
    this.insuranceRequestService.UpdateInsuranceRequest(this.insuranceRequest).subscribe(res => {
      console.log("updated");
    });
  }

  documentGeneration(){
    this.documentService.GeneratePdf(this.insuranceRequest.id).subscribe();
  }
}
