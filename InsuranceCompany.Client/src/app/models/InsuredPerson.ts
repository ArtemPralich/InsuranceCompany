import { Client } from 'src/app/models/Client';

export class InsuredPerson {
    id : string;
    client : Client;
    isMainInsuredPerson : boolean;

    constructor(id: string) {
        this.id = id;
    }
}