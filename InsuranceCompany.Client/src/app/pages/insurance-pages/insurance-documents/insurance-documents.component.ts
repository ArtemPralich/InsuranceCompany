import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/AuthService';


export class Document {
  name: string;
  url: string;

  constructor(name: string, url: string) {
    this.name = name;
    this.url = url;
  }
}

@Component({
  selector: 'app-insurance-documents',
  templateUrl: './insurance-documents.component.html',
  styleUrls: ['./insurance-documents.component.css']
})
export class InsuranceDocumentsComponent {
  constructor(public auth: AuthService) {}

  // documents: Document[] = [];
  documents: Document[] = [
    {
      name: 'привет.pdf',
      url: "assets/doc/привет.pdf",
    },
    {
      name: 'hi.pdf',
      url: "assets/doc/hi.pdf",
    },
  ];

  // ngOnInit(){
  //   this.GetFiles();
  // }

  GetFiles(){
    this.auth.downloadFile();
  }
}
