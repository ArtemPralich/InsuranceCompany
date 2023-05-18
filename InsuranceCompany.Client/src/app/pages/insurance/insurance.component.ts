import { Component, OnInit, ViewChild } from '@angular/core';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { ActivatedRoute, Router } from '@angular/router';
import {FormBuilder, Validators} from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { DocumentService } from 'src/app/service/DocumentService';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-insurance',
  templateUrl: './insurance.component.html',
  styleUrls: ['./insurance.component.css']
})
export class InsuranceComponent implements OnInit  {
  insuranceRequest:  InsuranceRequest;
  sign: boolean = false;
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
    private _formBuilder: FormBuilder, public documentService: DocumentService, private router: Router, private toastr: ToastrService){
      
  }

  ngOnInit(){
    this.dataLoad();
  }

  dataLoad(){
    let id:string = "";
    this.route.params.subscribe(
      params => {
          id = params['id'];
      });

    this.insuranceRequestService.GetInsuranceRequestById(id).subscribe(res => {
      this.insuranceRequest = res;
      this.insuranceRequest.dateOfStart = new Date(res.dateOfStart);
      this.insuranceRequest.dateOfEnd = new Date(res.dateOfEnd);
      console.log(this.insuranceRequest);
    });
  }

  save(){
    this.insuranceRequestService.UpdateInsuranceRequest(this.insuranceRequest).subscribe(res => {
      console.log("updated");
      this.toastr.success('Успешно сохранено', 'Успешно!');
    },
    error => {
      this.toastr.error('Ошибка сохранения', 'Ошибка!');
    });
  }

  moveToSign(){
    this.insuranceRequestService.MoveToSign(this.insuranceRequest).subscribe(res => {
      this.toastr.success('Успешно подписано', 'Успешно!');
      this.toggleSign();
      this.dataLoad();
    },
    error => {
      this.toastr.error('Ошибка подписи', 'Ошибка!');
    });
  }

  moveToApprove(){
    this.insuranceRequestService.MoveToApprove(this.insuranceRequest).subscribe(res => {
      this.toastr.success('Успешно подтверждено', 'Успешно!');
      this.dataLoad();
    },
    error => {
      this.toastr.error('Ошибка подтверждения', 'Ошибка!');
    });
  }

  moveToErrorState(){
    this.insuranceRequestService.MoveToErrorState(this.insuranceRequest).subscribe(res => {
      this.toastr.success('Успешно отменено', 'Успешно!');
      this.dataLoad();
    },
    error => {
      this.toastr.error('Ошибка отмены', 'Ошибка!');
    });
  }

  documentGeneration(){
    this.documentService.GeneratePdf(this.insuranceRequest.id).subscribe();
  }

  navigateToUrl() {
    this.router.navigateByUrl('insurances');
  }

  toggleSign() {
    this.sign = true;
  }
}
