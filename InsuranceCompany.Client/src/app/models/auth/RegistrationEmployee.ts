export class RegistrationEmployee {
    firstName : string;
    lastName : string;
    personalCode : string;
    phoneNumber: string;
    email : string;
    password : string;
    confirmPassword : string;

    constructor() 
    {
        this.firstName = "";
        this.lastName = "";
        this.personalCode = "";
        this.phoneNumber = "";
        this.email = "";
        this.password = "";
        this.confirmPassword = "";
    }
}