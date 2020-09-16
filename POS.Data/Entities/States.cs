using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class States
    {
        public int StatesId { get; set; }
        public int StateTypeId { get; set; }
        public int ObjectId { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}
