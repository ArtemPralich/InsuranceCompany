import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { InsuranceSurvey } from "../models/InsuranceSurvey";
import { Question } from "../models/Question";
import { QuestionType } from "../models/QuestionType";

@Injectable()
export class QuestionTypeService {
    public pathBase: string = "https://localhost:7046/api/QuestionType"

    constructor(private http:HttpClient){}

    public GetAllQuestionType():Observable<QuestionType[]> {
        
        return this.http.get<QuestionType[]>(`${this.pathBase}`);
    }

}