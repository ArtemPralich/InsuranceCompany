﻿using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceRequestDto
    {
        public Guid? Id { get; set; }
        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd { get; set; }


        public Guid? AgentId { get; set; }
        public decimal Cost { get; set; }
        public decimal? BasePayment { get; set; }
        public decimal? UnitPayment { get; set; }
        public decimal? Benefits { get; set; }
        public string? BankName { get; set; }
        public string? CardAccount { get; set; }
        public string? CardPeriod { get; set; }
        public string? CardCode { get; set; }

        public Guid? InsuranceRateId { get; set; }

        public Guid? InsuranceStatusId { get; set; }
        
        public bool IsReadyDocuments { get; set; }
        public virtual Agent? Agent { get; set; }

        public virtual ICollection<AnswerValueDto> AnswerValues { get; } = new List<AnswerValueDto>();

        public virtual InsuranceRateDto? InsuranceRate { get; set; }
        public virtual InsuranceStatusDto? InsuranceStatus { get; set; }
        public virtual ICollection<InsuredPersonDto> InsuredPersons { get; } = new List<InsuredPersonDto>();
        public virtual ICollection<Document> Documents { get; } = new List<Document>();
        public ClientDto MainClient { get;set; }
    }
}
