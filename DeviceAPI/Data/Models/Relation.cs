using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceAPI.Data.Models
{
    public class Relation
    {
        public int FromId { get; set; }
        public int ToId { get; set; }


        public virtual Device DeviceFrom { get; set; }
        public virtual Device DeviceTo { get; set; }
    }
}
