import { Component } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import { AuthService } from 'src/app/service/AuthService';
import { ClientService } from 'src/app/service/ClientService';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ActivatedRoute, Router} from '@angular/router';
import { Client } from 'src/app/models/Client';
import { RegistrationClient } from 'src/app/models/auth/RegistrationClient';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  client = new RegistrationClient();
  
  hide = true;
  title = 'InsuranceCompany.Client';
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  public statusAuth: boolean = true;

  constructor(private http:HttpClient, private router: Router, public auth: AuthService, 
    public clientService: ClientService){
      
  }
  login(){
    this.auth.login(this.client.email, this.client.password).subscribe((res)=> {
        console.log(res);
      
        //const header = res.headers.get('roles');
        //console.log(header)
        const token = (<any>res).body.token;

        const header = (<any>res).body.role; 
        localStorage.setItem("jwt", token);
        var a = new Date();
        localStorage.setItem("date",`${(new Date()).getTime()}`);
        console.log(header)
        if(header !== null){
          localStorage.setItem("role", header);
          if(header == "Client")
            this.router.navigateByUrl("/room-client");
          else if(header == "Agent")
            this.router.navigateByUrl("/insurances");
          else if(header == "Administrator")
            this.router.navigateByUrl("/documents");
        }
    }, error =>{
        this.statusAuth = false;
    });
    
  }    
}
