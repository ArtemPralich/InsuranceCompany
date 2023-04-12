import { Question } from "./Question";

export class InsuranceSurvey {
    id : string;
    title : string;
    description : string;
    questions : Question[];

    constructor(id: string, status: string, color: string) {
        this.id = id;
    }
}