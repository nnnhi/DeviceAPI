using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DeviceAPI.Data.Enums;

namespace DeviceAPI.Data.Models
{
    public class Device : BaseEntity
    {
        public Device()
        {
            RelatedToDevices = new HashSet<Relation>();
        }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DeviceType Type { get; set; }

        [Required]
        public DeviceStatus Status { get; set; }

        public float Temperature { get; set; }

        public string DataUsage { get; set; }


        public ICollection<Relation> RelatedToDevices { get; set; }
        public ICollection<Relation> RelatedFromDevices { get; set; }

    }
}
