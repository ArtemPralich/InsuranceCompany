using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Update
{
    public class UpdateTemplate
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("text")]
        public string? Text { get; set; }

        public string? Title { get; set; }

        public virtual ICollection<Guid> InsuranceRates { get; set; } = new List<Guid>();
    }
}
