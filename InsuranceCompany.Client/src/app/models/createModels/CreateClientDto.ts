export class CreateClientDto {
    Name : string;
    Surname : string;
    PersonalCode : string;
    Gender : boolean;
    DateOfBirth : Date;
    address: string;
    phoneNumber: string;
    email: string;
  
    constructor() {

    }
  }