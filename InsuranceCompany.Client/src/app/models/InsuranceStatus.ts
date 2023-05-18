export class InsuranceStatus {
    id : string;
    status : string;
    color : string;
    isDisabledForms: boolean;

    constructor(id: string = '', status: string = '', color: string = '') {
        this.id = id;
        this.status = status;
        this.color = color;
        this.isDisabledForms = false;
    }
}