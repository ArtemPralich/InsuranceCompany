import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { AuthService } from "../service/AuthService";

@Injectable()
export class AuthGuard {
    constructor(private router: Router, private auth : AuthService) { }

    canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot): boolean {
        if (!this.auth.authenticated()) {
        this.router.navigateByUrl("/login");
        return false;
        }
        else if (this.auth.roles() != 'Client') {
        this.router.navigateByUrl("/not-access");
        return false;
        }
        return true;
    }    
}