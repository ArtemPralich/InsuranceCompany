import { InsuranceSurvey } from "./InsuranceSurvey";
import { QuestionType } from "./QuestionType";

export class Question {
    id : string;
    text : string;
    isMandatory : boolean;
    questionTypeId : string;
    insuranceSurvey : InsuranceSurvey;
    questionType :  QuestionType;
    answer :  string[];

    constructor(id: string, insuranceSurveyId : string,
    insuranceRateId : string,insuranceSurvey : InsuranceSurvey) {
        
        this.id = id;
    }
}