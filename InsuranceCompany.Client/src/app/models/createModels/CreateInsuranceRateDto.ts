import { InsuranceStatus } from 'src/app/models/InsuranceStatus';
import { CreateClientDto } from 'src/app/models/createModels/CreateClientDto';

export class CreateInsuranceRateDto {
    id : string;
    dateOfStart : Date;
    dateOfEnd : Date;
    agentId : string;
    insuranceRateId : string;
    insuranceStatusId : string;
    mainClient : CreateClientDto;
    insuranceStatus: InsuranceStatus;
    cost: number;
    сoefficient: number;

    constructor() 
    {
    }
}