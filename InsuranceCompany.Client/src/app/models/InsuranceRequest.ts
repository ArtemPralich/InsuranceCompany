import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
import { Client } from 'src/app/models/Client';
import { InsuranceRate } from 'src/app/models/InsuranceRate';
import { InsuredPerson } from 'src/app/models/InsuredPerson';
import { AnswerValues } from 'src/app/models/AnswerValue';
import { Document } from './Document';

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
    benefits: number;
    basePayment: number;
    unitPayment: number;
    insuranceRate: InsuranceRate;
    insuredPersons: InsuredPerson[];
    answerValues: AnswerValues[];
    documents: Document[];
    isReadyDocuments: boolean;


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