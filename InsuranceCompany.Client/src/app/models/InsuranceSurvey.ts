import { Question } from "./Question";
import { InsuranceRate } from "./InsuranceRate";

export class InsuranceSurvey {
    id : string;
    title : string;
    description : string;
    isDeactivated : boolean;
    questions : Question[];
    insuranceRates: InsuranceRate[];
    constructor(title: string) {
        this.title = title;
        this.isDeactivated = false;
    }
}