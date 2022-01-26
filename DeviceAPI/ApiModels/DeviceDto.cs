using System;
using System.ComponentModel.DataAnnotations;
using DeviceAPI.Data.Enums;

namespace DeviceAPI.ApiModels
{
    public class DeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DeviceType Type { get; set; }

        public string Status { get; set; }

        public string DataUsage { get; set; }
    }
}
