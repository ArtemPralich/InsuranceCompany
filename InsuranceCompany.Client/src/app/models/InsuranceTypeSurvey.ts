import { InsuranceSurvey } from "./InsuranceSurvey";

export class InsuranceTypeSurvey {
    id : string;
    insuranceSurveyId : string;
    insuranceRateId : string;
    insuranceSurvey : InsuranceSurvey;

    constructor(id: string, insuranceSurveyId : string,
    insuranceRateId : string,insuranceSurvey : InsuranceSurvey) {
        
        this.id = id;
        this.insuranceSurveyId = insuranceSurveyId;
        this.insuranceRateId = insuranceRateId;
        this.insuranceSurvey = insuranceSurvey;
    }
}