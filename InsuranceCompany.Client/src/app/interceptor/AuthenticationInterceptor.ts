import { Observable } from 'rxjs';
import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import { AuthService } from '../service/AuthService';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    public token : any; // = localStorage.getItem("jwt");    
    constructor(private auth: AuthService){
    }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(localStorage.getItem('jwt') !== null){
            this.auth.checkToken();
            this.token = localStorage.getItem("jwt");
            console.log("tokken " + this.token)
            req = req.clone({
                headers: req.headers.set('Authorization', `Bearer ${this.token}`),
              });
             
        }
        //req.headers.append('Authorization', `Bearer ${this.token}`)
        return next.handle(req);
    }
}