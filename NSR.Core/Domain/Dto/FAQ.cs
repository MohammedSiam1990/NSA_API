using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class FAQ
    {
        public int FAQQuestionMasterId { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int FAQCategoryId { get; set; }
        public int FAQAnswerMasterId { get; set; }
    }
}
