import { Question } from "./Question";
import { InsuranceRate } from "./InsuranceRate";

export class InsuranceSurvey {
    id : string;
    title : string;
    description : string;
    questions : Question[];
    insuranceRates: InsuranceRate[];
    constructor(title: string) {
        this.title = title;
    }
}