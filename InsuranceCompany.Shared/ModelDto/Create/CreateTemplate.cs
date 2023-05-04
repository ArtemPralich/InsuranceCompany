using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Create
{
    public class CreateTemplate
    {
        public string? Text { get; set; }

        public string? Title { get; set; }

        public virtual ICollection<Guid> InsuranceRates { get; set; } = new List<Guid>();
    }
}
