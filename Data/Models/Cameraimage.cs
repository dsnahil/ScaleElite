using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Cameraimage
    {
        public int CameraImageId { get; set; }
        public int CameraId { get; set; }
        public int? TransactionDetailId { get; set; }
        public string ImageLocation { get; set; } = null!;
        public int IsSelected { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Camera Camera { get; set; } = null!;
        public virtual Transactiondetail? TransactionDetail { get; set; }
    }
}
