import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { saveAs } from 'file-saver';
import { Client } from "../models/Client";

@Injectable()
export class ClientService {
    public pathBase: string = "https://localhost:7046/Client"

    constructor(private http:HttpClient){}

    public GetAllClients():Observable<Client[]> {
        
        return this.http.get<Client[]>(`${this.pathBase}`);
    }

    public GetClientPrivateInfo():Observable<Client>{

        return this.http.get<Client>(`${this.pathBase}`+ "/GetClientPrivateInfo");
    }

    public GetClientResetPassword(email: string):Observable<Client>{

        return this.http.get<Client>(`${this.pathBase}`+ "/ResetPassword?email=" + email);
    }

    public UpdateEmail(email: string):Observable<Client>{

        return this.http.post<Client>(`${this.pathBase}`+ "/UpdateEmail?email=" + email, email);
    }

    public UpdatePassword(password: string, oldPassword: string):Observable<Client>{

        return this.http.post<Client>(`${this.pathBase}`+ "/UpdatePassword", { password, oldPassword } );
    }

    public CreateClient(client : Client):Observable<Client> { 

        return this.http.post<Client>(`${this.pathBase}`, client);
    }

    public UpdateClient(client : Client):Observable<any>{

        return this.http.put<any>(`${this.pathBase}`, client);
    }

    public DeleteClient(id: string):Observable<any>{

        return this.http.delete<any>(`${this.pathBase}/${id}`);
    }
}