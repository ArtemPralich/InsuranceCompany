import { Component, OnInit, ViewChild } from '@angular/core';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import { InsuranceRateService } from 'src/app/service/InsuranceRateService';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

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

  constructor(public insuranceRequestService: InsuranceRequestService, public dialog: MatDialog){
      
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
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
  checked = false;

  insuranceRequest : InsuranceRequest;

  constructor(public insuranceRateService: InsuranceRateService, public dialogRef: MatDialogRef<DialogElementsExampleDialog>,
    public insuranceRequestService: InsuranceRequestService) 
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
    this.insuranceRequestService.CreateInsuranceRequest(this.insuranceRequest).subscribe((data)=>{
      console.log("created");
      location.reload();
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