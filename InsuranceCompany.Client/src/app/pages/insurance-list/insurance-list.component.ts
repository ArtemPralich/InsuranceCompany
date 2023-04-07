import { Component, OnInit, ViewChild } from '@angular/core';
import {Router} from '@angular/router';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { CreateInsuranceRequestDto } from 'src/app/models/createModels/CreateInsuranceRequestDto';
import { CreateClientDto } from 'src/app/models/createModels/CreateClientDto';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { Client } from 'src/app/models/Client';

@Component({
  selector: 'app-insurance-list',
  templateUrl: './insurance-list.component.html',
  styleUrls: ['./insurance-list.component.css']
})
export class InsuranceListComponent implements OnInit {
  insuranceRequests:  InsuranceRequest[] = [];
  displayedColumns: string[] = ['name', 'personalCode', 'date', 'cost' , 'status'];
  dataSource = new MatTableDataSource<InsuranceRequest>();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public insuranceRequestService: InsuranceRequestService, public dialog: MatDialog, 
    private router: Router){
      
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  navigateToUrl(id: string) {
    this.router.navigateByUrl('insurance/' + id);
  }

  openDialog() {
    this.dialog.open(DialogElementsExampleDialog);
  }

  ngOnInit(){
    this.insuranceRequestService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRequests = res;
      console.log(this.insuranceRequests);
    });
  }
}


@Component({
  selector: 'CreateInsurancePopup',
  templateUrl: 'CreateInsurancePopup.html',
  styleUrls: ['./insurance-list.component.css']
})
export class DialogElementsExampleDialog {
  myControl = new FormControl('');
  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions: Observable<string[]>;
  insuranceRates: InsuranceRate[] = [];
  selected:string = 'option2';
  selectedInsuranceRate: InsuranceRate;
  checked = false;
  insuranceAmount: number;
  insuranceRequest : CreateInsuranceRequestDto;

  constructor(public insuranceRateService: InsuranceRateService, public dialogRef: MatDialogRef<DialogElementsExampleDialog>,
    public insuranceRequestService: InsuranceRequestService, private router: Router) 
  {}

  ngOnInit() {
    this.insuranceRateService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRates = res;
      console.log(this.insuranceRates);
    });
    
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

  close(){
    this.dialogRef.close();
  }

  create(){
    console.log(this.selectedInsuranceRate.id);
    this.insuranceRequest = new CreateInsuranceRequestDto();
    this.insuranceRequest.insuranceRateId = this.selectedInsuranceRate.id;
    this.insuranceRequest.client = new CreateClientDto();
    this.insuranceRequest.client.Name = "";
    this.insuranceRequest.client.Surname = "";
    this.insuranceRequest.client.PersonalCode = "";


    this.insuranceRequestService.CreateInsuranceRequest(this.insuranceRequest).subscribe((data)=>{
      this.dialogRef.close();
      this.router.navigateByUrl('/insurance/' + data);
    },
    error=>{
      alert("Creare kind failed")
    });
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }
}