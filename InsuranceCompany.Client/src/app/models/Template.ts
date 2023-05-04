export class Template {
    id : string;
    text : string;
    title : string;
    insuranceRates: string[]
    constructor(text: string) {
        this.text = text;
    }
}