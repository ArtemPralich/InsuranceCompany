import { CreateClientDto } from 'src/app/models/createModels/CreateClientDto';
import { Client } from 'src/app/models/Client';

export class CreateInsuranceRequestDto {
    dateOfStart : Date;
    dateOfEnd : Date;
    agentId : string;
    insuranceRateId : string;
    insuranceStatusId : string;
    client : CreateClientDto;
    cost: number;
    basePayment: number;
    unitPayment: number;
    сoefficient: number;

    constructor() 
    {
    }
}