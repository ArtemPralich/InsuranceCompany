import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { AuthService } from "../service/AuthService";

@Injectable()
export class AdminAuthGuard {
    constructor(private router: Router, private auth : AuthService) { }

    canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot): boolean {
        if (this.auth.roles() != 'Administrator') {
            this.router.navigateByUrl("/not-access");
            return false;
        }
        return true;
    }
}