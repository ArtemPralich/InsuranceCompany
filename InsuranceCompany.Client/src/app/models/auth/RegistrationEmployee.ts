export class RegistrationEmployee {
    firstName : string;
    lastName : string;
    personalCode : string;
    numberPhone: string;
    email : string;
    password : string;
    confirmPassword : string;

    constructor() 
    {
        this.firstName = "";
        this.lastName = "";
        this.personalCode = "";
        this.numberPhone = "";
        this.email = "";
        this.password = "";
        this.confirmPassword = "";
    }
}