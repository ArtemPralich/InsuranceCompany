using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class InsuranceStatus
    {
        public Guid Id { get; set; }

        public string Status { get; set; }

        public string  Color { get; set; }
        public bool?  IsDisabledForms { get; set; }
        public bool?  IsDisabledDocuments { get; set; }
    }
}
