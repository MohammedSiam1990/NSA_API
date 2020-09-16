using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class FAQHomeMaster
    {
        public int FAQHomeID { get; set; }
        public string QuestionEnglish { get; set; }
        public string QuestionArabic { get; set; }
        public string AnswerEnglish { get; set; }
        public string AnswerArabic { get; set; }
    }
}
