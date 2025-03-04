using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Camera
    {
        public Camera()
        {
            Cameraimages = new HashSet<Cameraimage>();
        }

        public int CameraId { get; set; }
        public string CameraName { get; set; } = null!;
        public int? WeightBridgeId { get; set; }
        public string? CameraType { get; set; }
        public string? Ipaddress { get; set; }
        public string? Port { get; set; }
        public string? VideosourceUrl { get; set; }
        public string? UserName { get; set; }
        public string? CameraPassword { get; set; }
        public int Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<Cameraimage> Cameraimages { get; set; }
    }
}
