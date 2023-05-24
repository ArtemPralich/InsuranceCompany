import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CreateInsuranceRequestDto } from "../models/createModels/CreateInsuranceRequestDto";
import { InsuranceRequest } from "../models/InsuranceRequest";

@Injectable()
export class InsuranceRequestService {
    public pathBase: string = "https://localhost:7046/api/InsuranceRequest"

    constructor(private http:HttpClient){}

    public MoveToSign(insuranceRequest : InsuranceRequest):Observable<InsuranceRequest>{

        return this.http.get<InsuranceRequest>(`${this.pathBase}`+ "/MoveToSign/" + insuranceRequest.id);
    }

    public MoveToApprove(insuranceRequest : InsuranceRequest):Observable<InsuranceRequest>{

        return this.http.get<InsuranceRequest>(`${this.pathBase}`+ "/MoveToApprove/" + insuranceRequest.id);
    }

    public MoveToErrorState(insuranceRequest : InsuranceRequest):Observable<InsuranceRequest>{

        return this.http.get<InsuranceRequest>(`${this.pathBase}`+ "/MoveToErrorState/" + insuranceRequest.id);
    }

    public Validate(id:string):Observable<any[]> {
        
        return this.http.get<any[]>(`${this.pathBase}`+ "/Validate?id=" + id);
    }

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