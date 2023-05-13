import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CreateInsuranceRequestDto } from "../models/createModels/CreateInsuranceRequestDto";
import { InsuranceRequest } from "../models/InsuranceRequest";

@Injectable()
export class InsuranceRequestService {
    public pathBase: string = "https://localhost:7046/api/InsuranceRequest"

    constructor(private http:HttpClient){}

    public GetAllInsuranceRequests():Observable<InsuranceRequest[]> {
        
        return this.http.get<InsuranceRequest[]>(`${this.pathBase}`);
    }

    public GetInsuranceRequestById(id:string):Observable<InsuranceRequest>{

        return this.http.get<InsuranceRequest>(`${this.pathBase}`+ "/" + id);
    }

    public CreateInsuranceRequest(insuranceRequest : CreateInsuranceRequestDto):Observable<string> { 

        return this.http.post<string>(`${this.pathBase}`, insuranceRequest);
    }
    
    public CreateInsuranceRequestByClient(insuranceRequest : CreateInsuranceRequestDto):Observable<string> { 

        return this.http.post<string>(`${this.pathBase}/CreateByClient`, insuranceRequest);
    }

    public UpdateInsuranceRequest(insuranceRequest : InsuranceRequest):Observable<any>{

        return this.http.put<any>(`${this.pathBase}`, insuranceRequest);
    }

    public DeleteInsuranceRequest(id: string):Observable<any>{

        return this.http.delete<any>(`${this.pathBase}/${id}`);
    }
}