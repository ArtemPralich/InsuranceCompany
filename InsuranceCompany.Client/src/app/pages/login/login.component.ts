import { Component } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import { AuthService } from 'src/app/service/AuthService';
import { ClientService } from 'src/app/service/ClientService';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ActivatedRoute, Router} from '@angular/router';
import { Client } from 'src/app/models/Client';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  clients: Client[] = [];
  hide = true;
  title = 'InsuranceCompany.Client';
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  public statusAuth: boolean = true;

  constructor(private http:HttpClient, private router: Router, public auth: AuthService, 
    public clientService: ClientService){
      
  }
  login(){
    console.log("eqeweq");
    this.auth.login().subscribe((res)=> {
      
        const header = res.headers.get('roles');
        const token = (<any>res).body.token; 
        localStorage.setItem("jwt", token);
        var a = new Date();
        if(header !== null){
          localStorage.setItem("role", header);
        }
        localStorage.setItem("date",`${(new Date()).getTime()}`);

        this.router.navigate(["/"]);
    }, error =>{
        this.statusAuth = false;
    });
    
    (<HTMLInputElement>document.getElementById("password")).value = "";
  }    
  downloadFile(){
    this.auth.downloadFile();
  }

  GetClients(){
    this.clientService.GetAllClients().subscribe(res => {
      this.clients = res;
    });;
  }
}
