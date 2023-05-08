import { Component } from '@angular/core';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { CreateClientDto } from 'src/app/models/createModels/CreateClientDto';
import { CreateInsuranceRequestDto } from 'src/app/models/createModels/CreateInsuranceRequestDto';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { DialogElementsExampleDialog } from '../insurance-list/insurance-list.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent {
  condition: boolean=true;
  insuranceRates: InsuranceRate[] = [];
  selectedInsuranceRate: InsuranceRate;
  insuranceAmount: number;
  insuranceRequest : CreateInsuranceRequestDto;

  constructor(public insuranceRateService: InsuranceRateService, 
    public insuranceRequestService: InsuranceRequestService, private toastr: ToastrService) 
  {}

  ngOnInit() {
    this.insuranceRateService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRates = res;
    });
  }
     
  toggle(): void {
      this.condition=!this.condition;
  }

  send(): void {
    console.log(this.selectedInsuranceRate.id);
    this.insuranceRequest = new CreateInsuranceRequestDto();
    this.insuranceRequest.insuranceRateId = this.selectedInsuranceRate.id;
    this.insuranceRequest.client = new CreateClientDto();
    this.insuranceRequest.client.Name = "";
    this.insuranceRequest.client.Surname = "";
    this.insuranceRequest.client.PersonalCode = "";


    this.insuranceRequestService.CreateInsuranceRequest(this.insuranceRequest).subscribe((data)=>{
      // this.dialogRef.close();
      // this.router.navigateByUrl('/insurance/' + data);
      this.toastr.success('Успешно отправлено', 'Успешно!');
    },
    error=>{
      this.toastr.error('Ошибка отправки', 'Ошибка!');
    });
  }
}
