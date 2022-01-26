using DeviceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAPI.Data.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationContext _context;
        public DeviceService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices;
        }


        public async Task<Device> GetById(int id)
        {
            var device = await _context.Devices.Where(x => x.Id == id)
                .Include(d => d.RelatedToDevices)
                                .ThenInclude(r => r.DeviceTo)

                .FirstOrDefaultAsync();
            return device;
        }
    }
}