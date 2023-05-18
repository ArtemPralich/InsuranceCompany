using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public Guid? InsuranceRequestId { get; set; }
        public Guid? TemplateId { get; set; }

    }
}
