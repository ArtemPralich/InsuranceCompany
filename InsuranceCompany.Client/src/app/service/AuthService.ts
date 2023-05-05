import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { saveAs } from 'file-saver';

@Injectable()
export class AuthService {
    public pathBase: string = "https://localhost:5001/kinds"

    constructor(private http:HttpClient, private router: Router){}



    authenticated(): boolean{
      this.checkToken();
      return (localStorage.getItem("jwt") !== null)
    }
    roles():string{
      var role = localStorage.getItem("role") || "no";
      return role;
    }

    logout(){
      localStorage.removeItem('role');
      localStorage.removeItem('jwt');
      localStorage.removeItem('date');
      this.router.navigate(["/login"]);
    }

    checkToken(){
      var date = localStorage.getItem("date") || "0";
      var a = new Date()
      if((a.getTime() - (+date)) >= 14 * 3600 * 24 * 1000){
       this.logout()
      }
    }

    login(): Observable<HttpResponse<string>>{ 
      const myHeaders = new HttpHeaders({
          "Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*",
          "Access-Control-Allow-Headers": "Origin, X-Requested-With, Content-Type, Accept",
          "Access-Control-Allow-Methods": "GET, PATCH, PUT, POST, DELETE, OPTIONS"
         
        });
      return this.http.post<string>(`https://localhost:7046/api/authentication/login`, 
          JSON.stringify({
              userName: (<HTMLInputElement>document.getElementById("username")).value,
              password: (<HTMLInputElement>document.getElementById("password")).value
          }), { headers:myHeaders,observe: 'response'} );

    }
    
    register(user: any):Observable<HttpResponse<string>>{
      return this.http.post<string>(`https://localhost:7046/api/authentication/`, user , { observe: 'response'});
      
    }  
    
    downloadFile() {
        const url = 'https://localhost:7046/Document/GetPDF/'; // Replace with your MVC controller URL
        this.http.get(url, { responseType: 'blob' }).subscribe((blob: Blob) => {
          const filename = 'file.pdf';
          saveAs(blob, filename);
        });
      }

      // public downloadFiles():Observable<Document[]> {
      //   const url = 'https://localhost:7046/Document/GetPDF/';
      //   return this.http.get<Document[]>(`${url}`);
      // }
}