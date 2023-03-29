import { Component, OnInit, ViewChild } from '@angular/core';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { InsuranceRequestService } from 'src/app/service/InsuranceRequestService';
import {MatTable} from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

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

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(public insuranceRequestService: InsuranceRequestService){
      
  }

  ngOnInit(){
    this.insuranceRequestService.GetAllInsuranceRequests().subscribe(res => {
      this.insuranceRequests = res;
      console.log(this.insuranceRequests);
    });
    // this.dataSource = [
    //   { Id: 'John', AgentId: "qew" },
    //   { Id: 'Jane', AgentId: "ewqe" },
    //   { Id: 'Bob', AgentId: "qwe" },
    // ]
  }
}