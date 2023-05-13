import { Component, ElementRef } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Client } from 'src/app/models/Client';
import { AuthService } from 'src/app/service/AuthService';
import { ClientService } from 'src/app/service/ClientService';

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
  condition: number = 1;
  isDisabled = true;
  client: Client = new Client();

  constructor(public dialog: MatDialog, private router: Router, public auth: AuthService, public clientService: ClientService, private toastr: ToastrService, private el: ElementRef) {}

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

  ngOnInit(){
    this.getClientInfo();
  }

  getClientInfo() {
    this.clientService.GetClientPrivateInfo().subscribe(res => {
      this.client = res;
      console.log(this.client);
    });
  }

  save(){
    // if(this.client.dateOfBirth.getHours() === 0){
    //   console.log(this.client.dateOfBirth);
    //   this.client.dateOfBirth.setHours(23);
    // }

    this.clientService.UpdateClient(this.client).subscribe(res => {
      this.enableInputTrue();
      this.toastr.success('Успешно сохранено', 'Успешно!');
    },
    error => {
      this.toastr.error('Ошибка сохранения', 'Ошибка!');
    });
    this.getClientInfo();
  }

  sendRequest(): void {
    this.router.navigateByUrl("/request");
  }

  openDialogChangeEmail(){
    const dialogRef = this.dialog.open(DialogChangeEmailPopup);

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

  openDialogChangePassword(){
    const dialogRef = this.dialog.open(DialogChangePasswordPopup);

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

  toggleClass() {
    const element = this.el.nativeElement.querySelector('.menu-line-ph');
    if (element.classList.contains('disp')) {
      element.classList.remove('disp');
    } else {
      element.classList.add('disp');
    }
  }

  logout(): void {
    this.auth.logout();
  }

  GetFiles(){
    this.auth.downloadFile();
  }

  toggleOne(): void {
    this.condition=1;
  }

  toggleTwo(): void {
    this.condition=2;
  }

  toggleThree(): void {
    this.condition=3;
  }

  enableInput() {
    this.isDisabled = false;
  }

  enableInputTrue() {
    this.getClientInfo();
    this.isDisabled = true;
  }
}

@Component({
  selector: 'ChangeEmail',
  templateUrl: 'ChangeEmail.html',
  styleUrls: ['./room-client.component.css']
})
export class DialogChangeEmailPopup {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  constructor(private router: Router, public auth: AuthService, public dialogRef: MatDialogRef<DialogChangeEmailPopup>) {}
  
  close(){
    this.dialogRef.close();
  }

  create(){
    
  }
}

@Component({
  selector: 'ChangePassword',
  templateUrl: 'ChangePassword.html',
  styleUrls: ['./room-client.component.css']
})
export class DialogChangePasswordPopup {
  newPassword: string;
  confirmPassword: string;
  passwordsMatch: boolean = true;

  constructor(private router: Router, public auth: AuthService, public dialogRef: MatDialogRef<DialogChangePasswordPopup>) {}
  
  close(){
    this.dialogRef.close();
  }

  create(){
    this.onConfirmPasswordChange();

  }

  onConfirmPasswordChange() {
    if (this.newPassword !== this.confirmPassword) {
      this.passwordsMatch = false;
    } else {
      this.passwordsMatch = true;
    }
  }
}