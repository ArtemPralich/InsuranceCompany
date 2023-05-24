import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { InsuranceSurvey } from "../models/InsuranceSurvey";
import { Question } from "../models/Question";

@Injectable()
export class SurveyService {
    public pathBase: string = "https://localhost:7046/api/Survey"

    constructor(private http:HttpClient){}

    public GetAllInsuranceSurveys():Observable<InsuranceSurvey[]> {
        
        return this.http.get<InsuranceSurvey[]>(`${this.pathBase}`);
    }

    public GetInsuranceSurveyById(id:string):Observable<InsuranceSurvey>{

        return this.http.get<InsuranceSurvey>(`${this.pathBase}`+ "/" + id);
    }

    public CreateSurvey(insuranceSurvey : InsuranceSurvey):Observable<InsuranceSurvey> { 

        return this.http.post<InsuranceSurvey>(`${this.pathBase}`, insuranceSurvey);
    }

    // public CreateQuestion(question : Question):Observable<Question> { 

    //     return this.http.post<Question>(`${this.pathBase}`, question);
    // }

    // public CreateInsuranceSurvey(insuranceSurvey : CreateInsuranceRequestDto):Observable<string> { 

    //     return this.http.post<string>(`${this.pathBase}`, insuranceRequest);
    // }

    public UpdateInsuranceSurvey(insuranceSurvey : InsuranceSurvey):Observable<any>{

        return this.http.put<any>(`${this.pathBase}`, insuranceSurvey);
    }

    public DeleteInsuranceSurvey(id: string):Observable<any>{

        return this.http.delete<any>(`${this.pathBase}?insuranceStatusId=` + id);
    }
}