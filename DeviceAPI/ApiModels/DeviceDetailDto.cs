using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DeviceAPI.Data.Enums;

namespace DeviceAPI.ApiModels
{
    public class DeviceDetailDto
    {
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        public string Status { get; set; }
        public float Temperature { get; set; }
        public string DataUsage { get; set; }
        public IEnumerable<DeviceDto> RelatedDevices { get; set; }
    }
}
