using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [JsonObject]
    [Serializable]
    public class EmailAttachment 
    {
        [PrimaryKey]        
        public long EmailAttachmentID { get; set; }
                
        public long EmailNotificationID { get; set; }
        
        public string AttachmentFilePath { get; set; }
        
        public string AttachmentName { get; set; }

        public long? CreatedBy { get; set; }
        public string AttachmentFullPath { get; set; }

    }
}
