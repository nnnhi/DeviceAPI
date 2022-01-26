using DeviceAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAPI.Data.Services
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAll();
        Task<Device> GetById(int id);
    }
}
