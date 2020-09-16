﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain.AmazonService
{
    /// <summary>
    /// Class for vehicle document details queue
    /// </summary>
    public class VehicleDocumentDetailsQueue
    {
        public long VehicleDocumentDetailProcessingQueueID { get; set; }

        public long VehicleDocumentDetailID { get; set; }

        public long VehicleID { get; set; }

        public bool HasThumbnailImage { get; set; }

        public bool HasCompressImage { get; set; }

        public byte? ImageCompressionType { get; set; }

        public DateTime? ProcessedOn { get; set; }

        public int? NoOfRetry { get; set; }

        public DateTime? NextRetryTime { get; set; }

        public bool? NotProcessed { get; set; }

        public string DocumentTitle { get; set; }

        public string DocumentLink { get; set; }

        public string DocumentType { get; set; }

        public bool IsCompressed { get; set; }

        public bool HasThumbnail { get; set; }

        public bool IsProcessed { get; set; }
    }
}
