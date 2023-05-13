import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationEmployee } from 'src/app/models/auth/RegistrationEmployee';
import { AuthService } from 'src/app/service/AuthService';

@Component({
  selector: 'app-registation-employee',
  templateUrl: './registation-employee.component.html',
  styleUrls: ['./registation-employee.component.css']
})
export class RegistationEmployeeComponent {
  employee = new RegistrationEmployee();
  passwordsMatch: boolean = true;

  constructor(public auth: AuthService, private router: Router){
      
  }

  registration(){
    this.onConfirmPasswordChange();
    if(this.passwordsMatch) {
      console.log(this.employee);
      
    }
  }

  onConfirmPasswordChange() {
    if (this.employee.password !== this.employee.confirmPassword) {
      this.passwordsMatch = false;
    } else {
      this.passwordsMatch = true;
    }
  }
}
