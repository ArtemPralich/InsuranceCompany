import { Component, Input, OnChanges, SimpleChanges, OnInit, ChangeDetectorRef } from '@angular/core';
import {FormBuilder, Validators, FormGroupDirective, NgForm,} from '@angular/forms';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { FormControl } from '@angular/forms';
import { ClientService } from 'src/app/service/ClientService';
import { Client } from 'src/app/models/Client';
import {Observable} from 'rxjs';
import {ErrorStateMatcher} from '@angular/material/core';
import {map, startWith} from 'rxjs/operators';
import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
import { SharedDataService } from 'src/app/service/SharedData';


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
  selector: 'app-insurance-client-info',
  templateUrl: './insurance-client-info.component.html',
  styleUrls: ['./insurance-client-info.component.css']
})
export class InsuranceClientInfoComponent implements OnInit {
  @Input() insuranceRequest: InsuranceRequest;


  
  myControl = new FormControl('');
  filteredOptions: Observable<Client[]>;
  createErrorStateMatcher(fieldName: string): MyErrorStateMatcher {
    return new MyErrorStateMatcher(fieldName, this.sharedDataService);
  }

  private _filter(value: string): Client[] {
    const filterValue = value.toLowerCase();
    
    return this.clients.filter(client => client.personalCode.toLowerCase().includes(filterValue));
  }
  
  clients: Client[] = [];
  insuranceStatus: InsuranceStatus = new InsuranceStatus();
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  public updateFieldsState(isDisable: boolean) {
    if(isDisable){
      this.myControl.disable();
      this.emailFormControl.disable();
    }
    else{
      this.myControl.enable();
      this.emailFormControl.enable();
    }
    this.cdr.markForCheck();
  }

  ngOnInit(){
    this.updateFieldsState(this.insuranceRequest.insuranceStatus.isDisabledForms)
    this.clientService.GetAllClients().subscribe(res => {
      this.clients = res;
    });
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }


  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required]
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required],
  });

  constructor(private _formBuilder: FormBuilder, public clientService: ClientService, 
    private cdr: ChangeDetectorRef, private sharedDataService: SharedDataService){

  }



  onInputBenefits() {
    this.insuranceRequest.cost = this.insuranceRequest.benefits / (this.insuranceRequest.insuranceRate.baseCoefficient || 0)
    this.onInputBasePayment();
  }

  onInputBasePayment() {
    this.insuranceRequest.unitPayment = (this.insuranceRequest.cost - this.insuranceRequest.basePayment)  / (this.insuranceRequest.insuranceRate.countYears * this.insuranceRequest.insuranceRate.countPaymentsInYear)
  }

  onInputDateOfStart() {
    this.insuranceRequest.dateOfEnd.setFullYear(this.insuranceRequest.dateOfStart.getFullYear() + this.insuranceRequest.insuranceRate.countYears);
    this.insuranceRequest.dateOfEnd.setMonth(this.insuranceRequest.dateOfStart.getMonth());
    this.insuranceRequest.dateOfEnd.setDate(this.insuranceRequest.dateOfStart.getDay());
  }

  onBMOptionSelected() {
    this.insuranceRequest.insuredPersons.forEach(element => {
      if(element.isMainInsuredPerson){
        this.clients.forEach(client => {
          if(client.personalCode == element.client.personalCode){
            element.client = client;
          }
        })
      }
    }); 
  }

  myFunc(){
  }
}
