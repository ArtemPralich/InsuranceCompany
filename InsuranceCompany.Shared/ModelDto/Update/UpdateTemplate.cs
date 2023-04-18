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
        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
