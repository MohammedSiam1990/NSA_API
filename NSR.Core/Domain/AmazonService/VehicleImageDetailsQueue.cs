using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain.AmazonService
{
    /// <summary>
    /// Class for vehicle image detail queue
    /// </summary>
    public class VehicleImageDetailsQueue
    {
        public long VehicleImageDetailProcessingQueueID { get; set; }

        public long VehicleImageDetailID { get; set; }

        public long VehicleID { get; set; }

        public bool HasThumbnailImage { get; set; }

        public bool HasCompressImage { get; set; }

        public byte? ImageCompressionType { get; set; }

        public DateTime? ProcessedOn { get; set; }

        public int? NoOfRetry { get; set; }

        public DateTime? NextRetryTime { get; set; }

        public bool? NotProcessed { get; set; }

        public string ImageTitle { get; set; }

        public string ImageMediaLink { get; set; }

        public string ImageType { get; set; }

        public bool IsCompressed { get; set; }

        public bool HasThumbnail { get; set; }

        public bool IsProcessed { get; set; }

        public short ActionID { get; set; }

        public bool IsWatermarked { get; set; }
    }
}
