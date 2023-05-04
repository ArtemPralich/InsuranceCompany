import { Component, Input, OnInit } from '@angular/core';
import { Document } from 'src/app/models/Document';
import { InsuranceRequest } from 'src/app/models/InsuranceRequest';
import { DocumentService } from 'src/app/service/DocumentService';




@Component({
  selector: 'app-insurance-documents',
  templateUrl: './insurance-documents.component.html',
  styleUrls: ['./insurance-documents.component.css']
})
export class InsuranceDocumentsComponent {
  constructor(public documentService: DocumentService) {}
  @Input() insuranceRequest:  InsuranceRequest;
  // documents: Document[] = [];


  // ngOnInit(){
  //   this.GetFiles();
  // }

  public GetFile(document:Document){
    console.log(this.insuranceRequest)
    this.documentService.GetFileById(document.id, document.title);
  }
}
