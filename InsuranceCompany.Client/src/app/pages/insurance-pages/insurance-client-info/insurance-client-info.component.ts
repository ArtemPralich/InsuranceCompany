import { Component, Input, OnChanges, SimpleChanges, OnInit } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { FormControl } from '@angular/forms';
import { ClientService } from 'src/app/service/ClientService';
import { Client } from 'src/app/models/Client';
import {Observable} from 'rxjs';

import {map, startWith} from 'rxjs/operators';

import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
@Component({
  selector: 'app-insurance-client-info',
  templateUrl: './insurance-client-info.component.html',
  styleUrls: ['./insurance-client-info.component.css']
})
export class InsuranceClientInfoComponent implements OnInit {
  @Input() insuranceRequest: InsuranceRequest;

  myControl = new FormControl('');
  filteredOptions: Observable<Client[]>;

  private _filter(value: string): Client[] {
    const filterValue = value.toLowerCase();

    return this.clients.filter(client => client.personalCode.toLowerCase().includes(filterValue));
  }
  
  clients: Client[] = [];
  insuranceStatus: InsuranceStatus = new InsuranceStatus();
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  ngOnInit(){
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

  constructor(private _formBuilder: FormBuilder, public clientService: ClientService){
    console.log(this.insuranceRequest);
  }

  onInputBenefits() {
    this.insuranceRequest.cost = this.insuranceRequest.benefits / (this.insuranceRequest.insuranceRate.baseCoefficient || 0)
    this.onInputBasePayment();
  }

  onInputBasePayment() {
    this.insuranceRequest.unitPayment = (this.insuranceRequest.cost - this.insuranceRequest.basePayment)  / (this.insuranceRequest.insuranceRate.countYears * this.insuranceRequest.insuranceRate.countPaymentsInYear)
  }

  onInputDateOfStart() {
    console.log(this.insuranceRequest.dateOfStart.getFullYear()  + this.insuranceRequest.insuranceRate.countYears)
    console.log(this.insuranceRequest.insuranceRate.countYears)
    this.insuranceRequest.dateOfEnd.setFullYear(this.insuranceRequest.dateOfStart.getFullYear() + this.insuranceRequest.insuranceRate.countYears);
    console.log(this.insuranceRequest.dateOfEnd)
  }

  onBMOptionSelected() {
    console.log("something")
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
    console.log(this.insuranceRequest);
  }
}
