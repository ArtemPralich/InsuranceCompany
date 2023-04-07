import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
import { Client } from 'src/app/models/Client';

export class InsuranceRequest {
    id : string;
    dateOfStart : Date;
    dateOfEnd : Date;
    agentId : string;
    insuranceRateId : string;
    insuranceStatusId : string;
    mainClient : Client;
    insuranceStatus: InsuranceStatus;
    cost: number;
    сoefficient: number;
    // public virtual Agent? Agent { get; set; }

    // public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

    // public virtual InsuranceRate? InsuranceRate { get; set; }

    constructor(id: string, dateOfStart: Date, dateOfEnd: Date, agentId: string, 
        insuranceRateId: string, insuranceStatusId: string, insuranceStatus: InsuranceStatus, mainClient : Client,
        cost: number) 
    {
        this.id = id;
        this.dateOfStart = dateOfStart;
        this.dateOfEnd = dateOfEnd;
        this.agentId = agentId;
        this.insuranceRateId = insuranceRateId;
        this.insuranceStatusId = insuranceStatusId;
        this.insuranceStatus = insuranceStatus;
        this.mainClient = mainClient;
        this.cost = cost;
    }
}