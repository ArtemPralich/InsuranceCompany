export class InsuranceRequest {
    id : string;
    dateOfStart : Date;
    dateOfEnd : Date;
    agentId : string;
    insuranceRateId : string;
    insuranceStatusId : string;

    // public virtual Agent? Agent { get; set; }

    // public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

    // public virtual InsuranceRate? InsuranceRate { get; set; }

    // public virtual InsuranceStatus? InsuranceStatus { get; set; }

  
    constructor(id: string, dateOfStart: Date, dateOfEnd: Date, agentId: string, insuranceRateId: string, insuranceStatusId: string) {
        this.id = id;
        this.dateOfStart = dateOfStart;
        this.dateOfEnd = dateOfEnd;
        this.agentId = agentId;
        this.insuranceRateId = insuranceRateId;
        this.insuranceStatusId = insuranceStatusId;
    }
  }