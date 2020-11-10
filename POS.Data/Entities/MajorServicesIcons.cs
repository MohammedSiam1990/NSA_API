﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class MajorServicesIcons
    {
        [Key]
        public int IconId { get; set; }
        public string IconName { get; set; }
        public int ServiceId { get; set; }
        public bool IsActive { get; set; }
        public int OrderId { get; set; }
    }
}
