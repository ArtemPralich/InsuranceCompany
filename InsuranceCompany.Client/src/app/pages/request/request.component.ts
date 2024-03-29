import { Component } from '@angular/core';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { CreateClientDto } from 'src/app/models/createModels/CreateClientDto';
import { CreateInsuranceRequestDto } from 'src/app/models/createModels/CreateInsuranceRequestDto';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { ClientService } from 'src/app/service/ClientService';
import { DialogElementsExampleDialog } from '../insurance-list/insurance-list.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Client } from 'src/app/models/Client';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent {
  condition: boolean=true;
  insuranceRates: InsuranceRate[] = [];
  selectedInsuranceRate: InsuranceRate;
  clientInfo: Client;
  insuranceAmount: number;
  insuranceRequest : CreateInsuranceRequestDto = new CreateInsuranceRequestDto();

  constructor(public insuranceRateService: InsuranceRateService, public clientService: ClientService,
    public insuranceRequestService: InsuranceRequestService, private toastr: ToastrService, private router: Router) 
  {}

  ngOnInit() {
    this.insuranceRateService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRates = res;
    });
    this.clientService.GetClientPrivateInfo().subscribe(res => {
      this.clientInfo = res;
    });
  }
     
  toggle(): void {
      this.condition=!this.condition;
  }

  send(): void {
    console.log(this.selectedInsuranceRate.id);
    this.insuranceRequest = new CreateInsuranceRequestDto();
    this.insuranceRequest.cost = this.insuranceAmount;
    this.insuranceRequest.insuranceRateId = this.selectedInsuranceRate.id;
    this.insuranceRequest.client = new CreateClientDto();
    this.insuranceRequest.client.Name = "";
    this.insuranceRequest.client.Surname = "";
    this.insuranceRequest.client.PersonalCode = "";
    this.insuranceRequest.benefits =  this.insuranceRequest.cost * (this.selectedInsuranceRate?.baseCoefficient || 0)


    this.insuranceRequestService.CreateInsuranceRequestByClient(this.insuranceRequest).subscribe((data)=>{
      // this.dialogRef.close();
      // this.router.navigateByUrl('/insurance/' + data);
      this.toastr.success('Успешно отправлено', 'Успешно!');
      this.router.navigateByUrl("/room-client");
    },
    error=>{
      this.toastr.error('Ошибка отправки', 'Ошибка!');
    });
  }
}
