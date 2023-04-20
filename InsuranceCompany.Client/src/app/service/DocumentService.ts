import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { saveAs } from 'file-saver';
import { Client } from "../models/Client";
import { Template } from "../models/Template";

@Injectable()
export class DocumentService {
    public pathBase: string = "https://localhost:7046/Document"

    constructor(private http:HttpClient){}

    public GetAllTemplates():Observable<Template[]> {
        
        return this.http.get<Template[]>(`${this.pathBase}`);
    }

    public GetClientById(id:string):Observable<Client>{

        return this.http.get<Client>(`${this.pathBase}`+ "/" + id);
    }

    public CreateTemplate(template : Template):Observable<Template> { 

        return this.http.post<Template>(`${this.pathBase}`, template);
    }

    public UpdateTemplate(template : Template):Observable<any>{
        const headers = new HttpHeaders().set('Content-Type', 'application/json');
        const body = JSON.stringify(template);
        return this.http.put<any>(`${this.pathBase}`, body, { headers });
    }

    public DeleteClient(id: string):Observable<any>{

        return this.http.delete<any>(`${this.pathBase}/${id}`);
    }
}