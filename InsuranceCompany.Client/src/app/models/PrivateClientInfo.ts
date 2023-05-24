import { InsuranceRequest } from "./InsuranceRequest";

export class PrivateClientInfo {
    id : string;
    name : string;
    surname : string;
    gender : boolean;
    dateOfBirth : Date;
    personalCode: string;
    address: string;
    phoneNumber: string;
    email: string;
    insuranceRequests: InsuranceRequest[];
    // PositionClients { get; } = new List<PositionClient>();
  
    // constructor(id: string, name: string, surname: string, gender: boolean, dateOfBirth: Date, personalCode: string) {
    //     this.id = id;
    //     this.name = name;
    //     this.surname = surname;
    //     this.gender = gender;
    //     this.dateOfBirth = dateOfBirth;
    //     this.personalCode = personalCode;
    // }

    constructor(){

    }
}
  