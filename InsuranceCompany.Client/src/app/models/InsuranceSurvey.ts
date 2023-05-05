import { Question } from "./Question";

export class InsuranceSurvey {
    id : string;
    title : string;
    description : string;
    questions : Question[];
    
    constructor(title: string) {
        this.title = title;
    }
}