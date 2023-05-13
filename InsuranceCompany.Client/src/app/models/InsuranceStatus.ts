export class InsuranceStatus {
    id : string;
    status : string;
    color : string;
    IsDisabledForms: boolean;

    constructor(id: string = '', status: string = '', color: string = '') {
        this.id = id;
        this.status = status;
        this.color = color;
        this.IsDisabledForms = false;
    }
}