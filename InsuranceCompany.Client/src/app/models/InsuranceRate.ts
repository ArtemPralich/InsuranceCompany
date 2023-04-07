export class InsuranceRate {
    id : string;
    title : string;
    unitPayment : number;
    countPaymentsInYear : number;
    countYears : number;
    cost: number;
    baseCoefficient: number;

    constructor(id: string, title : string, unitPayment : number,
        countPaymentsInYear : number, countYears : number, cost: number, baseCoefficient: number) 
    {
        this.title = title;
        this.unitPayment = unitPayment;
        this.countPaymentsInYear = countPaymentsInYear;
        this.countYears = countYears;
        this.cost = cost;
        this.baseCoefficient = baseCoefficient;
    }
}