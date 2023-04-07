import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { InsuranceRate } from "../models/InsuranceRate";

@Injectable()
export class InsuranceRateService {
    public pathBase: string = "https://localhost:7046/api/InsuranceRate"

    constructor(private http:HttpClient){}

    public GetAllInsuranceRequests():Observable<InsuranceRate[]> {
        
        return this.http.get<InsuranceRate[]>(`${this.pathBase}`);
    }
}