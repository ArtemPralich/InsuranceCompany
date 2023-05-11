import { Component } from '@angular/core';
import { RegistrationClient } from 'src/app/models/auth/RegistrationClient';
import { AuthService } from 'src/app/service/AuthService';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  client = new RegistrationClient();
  passwordsMatch: boolean = true;
  constructor(public auth: AuthService, private router: Router){
      
  }

  registration(){
    this.onConfirmPasswordChange();
    if(this.passwordsMatch) {
      console.log(this.client);
      this.auth.register(this.client).subscribe((res)=> {
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
          
          this.router.navigateByUrl("/room-client");
      }, error =>{
      });
    }
  }

  onConfirmPasswordChange() {
    if (this.client.password !== this.client.confirmPassword) {
      this.passwordsMatch = false;
    } else {
      this.passwordsMatch = true;
    }
  }
}
