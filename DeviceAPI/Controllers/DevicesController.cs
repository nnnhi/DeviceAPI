using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceAPI.ApiModels;
using DeviceAPI.Data;
using DeviceAPI.Data.Models;
using DeviceAPI.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _service;

        public DevicesController(IDeviceService service)
        {
            _service = service;
        }

        // GET api/devices
        [HttpGet]
        public ActionResult<IEnumerable<DeviceDto>> Get()
        {
            var devices = _service.GetAll();

            var result = devices.Select(rd => new DeviceDto()
            {
                Id = rd.Id, 
                Name = rd.Name,
                Status = rd.Status.ToString(),
                Type = rd.Type,
                DataUsage = rd.DataUsage
            });

            return Ok(result);
        }

        // GET api/devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDetailDto>> Get(int id)
        {
            var device = await _service.GetById(id);

            if (device == null)
            {
                return NotFound();
            }

            var deviceDto = new DeviceDetailDto
            {
                Name = device.Name,
                Status = device.Status.ToString(),
                Type = device.Type,
                Temperature = device.Temperature,
                DataUsage = device.DataUsage
            };

            deviceDto.RelatedDevices = device.RelatedToDevices?.Select(rd => new DeviceDto()
            {
                Name = rd.DeviceTo.Name,
                Status = rd.DeviceTo.Status.ToString(),
                Type = rd.DeviceTo.Type,
                DataUsage = rd.DeviceTo.DataUsage
            });


            return Ok(deviceDto);
        }
    }
}
