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
    selectedAnswersForDelete: Answer[] = [];

    constructor(text: string) {
        this.text = text;
        this.answers = [];
        this.selectedAnswersForDelete = [];
    }
}