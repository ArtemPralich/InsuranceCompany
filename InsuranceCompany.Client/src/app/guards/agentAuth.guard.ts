import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { AuthService } from "../service/AuthService";

@Injectable()
export class AgentAuthGuard {
    constructor(private router: Router, private auth : AuthService) { }

    canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot): boolean {
        if (this.auth.roles() != '["Agent"]') {
            this.router.navigateByUrl("/");
            return false;
        }
        return true;
    }
}