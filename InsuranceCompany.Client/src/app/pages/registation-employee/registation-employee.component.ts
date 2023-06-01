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
      this.auth.registerAgent(this.employee).subscribe((res)=> {
        console.log(res);
        //const header = res.headers.get('roles');
        
        const header = (<any>res).body.role;
        const token = (<any>res).body.token; 
        localStorage.setItem("jwt", token);
        var a = new Date();
        if(header !== null){
          localStorage.setItem("role", header);
        }
        localStorage.setItem("date",`${(new Date()).getTime()}`);
        
        this.router.navigateByUrl("/insurances");
    }, error =>{
    });
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
