import { Component, ElementRef, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Client } from 'src/app/models/Client';
import { Document } from 'src/app/models/Document';
import { PrivateClientInfo } from 'src/app/models/PrivateClientInfo';
import { AuthService } from 'src/app/service/AuthService';
import { ClientService } from 'src/app/service/ClientService';
import { DocumentService } from 'src/app/service/DocumentService';



@Component({
  selector: 'app-room-client',
  templateUrl: './room-client.component.html',
  styleUrls: ['./room-client.component.css']
})
export class RoomClientComponent {
  panelOpenState = false;
  condition: number = 1;
  isDisabled = true;
  client: PrivateClientInfo = new PrivateClientInfo();

  constructor(public dialog: MatDialog, private router: Router, public documentService: DocumentService,  
    public auth: AuthService, public clientService: ClientService, 
    private toastr: ToastrService, private el: ElementRef) {}

  documents: Document[] = [];

  ngOnInit(){
    this.getClientInfo();
  }

  getClientInfo() {
    this.clientService.GetClientPrivateInfo().subscribe(res => {
      this.client = res;
      this.documents = this.client.insuranceRequests.flatMap(item => item.documents);
      console.log(this.client);
    });
  }

  save(){
    // if(this.client.dateOfBirth.getDate()){
    //    console.log(this.client.dateOfBirth);
    //    this.client.dateOfBirth.setHours(23);
    // }
    if(this.client.dateOfBirth){
      const userTimezoneOffset = this.client.dateOfBirth.getTimezoneOffset() * 60000;
      this.client.dateOfBirth = new Date(this.client.dateOfBirth.getTime() - userTimezoneOffset);

    }

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

  public GetFile(document:Document){
    this.documentService.GetFileById(document.id, document.title);
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
  email: string;
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  constructor(private router: Router, public auth: AuthService, public dialogRef: MatDialogRef<DialogChangeEmailPopup>, public clientService: ClientService, private toastr: ToastrService) {}
  
  close(){
    this.dialogRef.close();
  }

  save(){
    this.clientService.UpdateEmail(this.email).subscribe(res => {
      this.toastr.success('Успешно сохранено', 'Успешно!');
      this.close()
    },
    error => {
      this.toastr.error('Ошибка сохранения', 'Ошибка!');
    });
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
  oldPassword: string;
  passwordsMatch: boolean = true;

  constructor(private router: Router, public auth: AuthService, public dialogRef: MatDialogRef<DialogChangePasswordPopup>, public clientService: ClientService, private toastr: ToastrService) {}
  
  close(){
    this.dialogRef.close();
  }

  save(){
    this.onConfirmPasswordChange();

    if(this.passwordsMatch){
      this.clientService.UpdatePassword(this.newPassword, this.oldPassword).subscribe(res => {
        this.toastr.success('Успешно сохранено', 'Успешно!');
        this.close()
      },
      error => {
        this.toastr.error('Ошибка сохранения', 'Ошибка!');
      });
    }
  }

  onConfirmPasswordChange() {
    if (this.newPassword !== this.confirmPassword) {
      this.passwordsMatch = false;
    } else {
      this.passwordsMatch = true;
    }
  }
}