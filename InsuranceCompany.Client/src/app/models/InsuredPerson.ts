import { Client } from 'src/app/models/Client';

export class InsuredPerson {
    id : string;
    client : Client;
    isMainInsuredPerson : boolean;
    isAccoridionOpen: boolean; // дополнительная переменная разворачивающегося списка

    constructor(id: string) {
        this.id = id;
    }
}