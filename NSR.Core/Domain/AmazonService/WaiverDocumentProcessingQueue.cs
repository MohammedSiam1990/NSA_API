
using System;

namespace NSR.Core.Domain.AmazonService
{
    /// <summary>
    /// Class for vehicle document details queue
    /// </summary>
    public class WaiverDocumentProcessingQueue
    {
        public long WaiverDocumentProcessingQueueID { get; set; }

        public long WaiverDocumentDetailID { get; set; }

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
