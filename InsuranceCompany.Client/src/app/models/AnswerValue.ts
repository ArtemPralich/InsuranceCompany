export class AnswerValues {
    id : string;
    value : string;
    questionId : string;
    insuranceRequestId : string;
    insuranceSurveyId : string;

    constructor(id: string, title : string, unitPayment : number,
        countPaymentsInYear : number, countYears : number, cost: number, baseCoefficient: number) 
    {
    }
}