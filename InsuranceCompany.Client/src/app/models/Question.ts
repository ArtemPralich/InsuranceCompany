import { InsuranceSurvey } from "./InsuranceSurvey";
import { QuestionType } from "./QuestionType";
import { Answer } from "./Answer";

export class Question {
    id : string;
    text : string;
    isMandatory : boolean;
    questionTypeId : string;
    insuranceSurvey : InsuranceSurvey;
    questionType :  QuestionType;
    answers :  Answer[];

    constructor(id: string, insuranceSurveyId : string,
    insuranceRateId : string,insuranceSurvey : InsuranceSurvey) {
        
        this.id = id;
    }
}