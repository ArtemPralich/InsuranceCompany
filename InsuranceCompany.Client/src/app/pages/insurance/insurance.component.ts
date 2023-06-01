import { Component, OnInit, ViewChild } from '@angular/core';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { ActivatedRoute, Router } from '@angular/router';
import {FormBuilder, Validators} from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { DocumentService } from 'src/app/service/DocumentService';
import { ToastrService } from 'ngx-toastr';
import { InsuranceClientInfoComponent } from '../insurance-pages/insurance-client-info/insurance-client-info.component';
import { InsuranceSuraveysComponent } from '../insurance-pages/insurance-suraveys/insurance-suraveys.component';
import { InsuranceBankDataComponent } from '../insurance-pages/insurance-bank-data/insurance-bank-data.component';
import { InsuredPersonsComponent } from '../insurance-pages/insured-persons/insured-persons.component';
import { SharedDataService } from 'src/app/service/SharedData';

@Component({
  selector: 'app-insurance',
  templateUrl: './insurance.component.html',
  styleUrls: ['./insurance.component.css']
})
export class InsuranceComponent implements OnInit  {
  showFiller = false;
  insuranceRequest:  InsuranceRequest;
  sign: boolean = false;
  parentProp = 'Hello, child!';
  @ViewChild(InsuranceClientInfoComponent, { static: false }) childInsuranceClientInfoComponent: InsuranceClientInfoComponent;
  @ViewChild(InsuranceSuraveysComponent, { static: false }) childInsuranceSuraveysComponent: InsuranceSuraveysComponent;
  @ViewChild(InsuranceBankDataComponent, { static: false }) childInsuranceBankDataComponent: InsuranceBankDataComponent;
  @ViewChild(InsuredPersonsComponent, { static: false }) childInsuredPersonsComponent: InsuredPersonsComponent;


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
  public requestIsProcess: boolean = false;

  constructor(public insuranceRequestService: InsuranceRequestService, private route: ActivatedRoute, 
    private _formBuilder: FormBuilder, public documentService: DocumentService, 
    private router: Router, private toastr: ToastrService, private sharedService: SharedDataService){
      
  }

  ngOnInit(){
    this.dataLoad();
  }

  checkTabOnchanges(tab: string){

    return this.sharedService.sharedData.some(i  => i.page == tab);
  }

  dataLoad(){
    this.sharedService.sharedData = [];
    let id:string = "";
    this.route.params.subscribe(
      params => {
          id = params['id'];
      });
    this.requestIsProcess = true;
    this.insuranceRequestService.GetInsuranceRequestById(id).subscribe(res => {
      this.insuranceRequest = res;
      this.insuranceRequest.dateOfStart = new Date(res.dateOfStart);
      this.insuranceRequest.dateOfEnd = new Date(res.dateOfEnd);
      console.log(this.insuranceRequest);
      this.requestIsProcess = false;
      
      this.childInsuranceClientInfoComponent.updateFieldsState(this.insuranceRequest.insuranceStatus.isDisabledForms);
      // this.childInsuranceSuraveysComponent.updateFieldsState(this.insuranceRequest.insuranceStatus.isDisabledForms);
      // this.childInsuranceBankDataComponent.updateFieldsState(this.insuranceRequest.insuranceStatus.isDisabledForms);
      // this.childInsuredPersonsComponent.updateFieldsState(this.insuranceRequest.insuranceStatus.isDisabledForms);
    }, error =>{
      
      this.requestIsProcess = false;
    });
  }

  save(){
    console.log(this.insuranceRequest)
    const userTimezoneOffset = this.insuranceRequest.dateOfStart.getTimezoneOffset() * 60000;
    if(this.insuranceRequest.dateOfStart){
      this.insuranceRequest.dateOfStart = new Date(this.insuranceRequest.dateOfStart.getTime() - userTimezoneOffset);
    }
    if(this.insuranceRequest.dateOfEnd){
      this.insuranceRequest.dateOfEnd = new Date(this.insuranceRequest.dateOfEnd.getTime() - userTimezoneOffset);
    }
    this.insuranceRequest.insuredPersons.forEach(value => {
      if(value.client.dateOfBirth != undefined && value.client.dateOfBirth != null){
        value.client.dateOfBirth = new Date(Date.parse(value.client.dateOfBirth.toString()) - userTimezoneOffset);
      }
    });

    this.insuranceRequestService.UpdateInsuranceRequest(this.insuranceRequest).subscribe(res => {
      console.log("updated");
      
    this.sharedService.sharedData = [];
      this.toastr.success('Успешно сохранено', 'Успешно!');
    },
    error => {
      this.toastr.error('Ошибка сохранения', 'Ошибка!');
    });
  }

  moveToSign(){
    this.requestIsProcess = true;
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
    this.requestIsProcess = true;
    this.insuranceRequestService.MoveToApprove(this.insuranceRequest).subscribe(res => {
      this.toastr.success('Успешно подтверждено', 'Успешно!');
      
      this.requestIsProcess = false;
      this.dataLoad();
    },
    error => {
      console.log(error);
      if (error.status == 400) {
        // Обработка ошибки статус-кода 400
        const responseBody = error.error;
        
        this.sharedService.sharedData = responseBody;
        console.log(responseBody)
        this.toastr.error('Введены некоректные данные', 'Ошибка!');
      }
      else{
        this.toastr.error('Ошибка подтверждения', 'Ошибка!');
      }
      
      this.requestIsProcess = false;
    });
  }

  moveToErrorState(){
    
    this.requestIsProcess = true;
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

  validation() {
    this.requestIsProcess = true;
    this.insuranceRequestService.Validate(this.insuranceRequest.id).subscribe(res => {
      this.toastr.success('Успешно отменено', 'Успешно!');
      this.requestIsProcess = false;
    },
    error => {
      this.toastr.error('Проверьте данные', 'Найдены ошибки!');
      this.requestIsProcess = false;
    });
  }

  toggleSign() {
    this.sign = true;
  }
}
