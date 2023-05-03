import { Component } from '@angular/core';
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
  selector: 'app-room-client',
  templateUrl: './room-client.component.html',
  styleUrls: ['./room-client.component.css']
})
export class RoomClientComponent {
  condition: boolean=true;
  isDisabled = true;

  constructor(public auth: AuthService) {}

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

  GetFiles(){
    this.auth.downloadFile();
  }

  toggleTrue(): void {
    this.condition=true;
  }

  toggleFalse(): void {
    this.condition=false;
  }

  enableInput() {
    this.isDisabled = false;
  }

  enableInputTrue() {
    this.isDisabled = true;
  }
}
