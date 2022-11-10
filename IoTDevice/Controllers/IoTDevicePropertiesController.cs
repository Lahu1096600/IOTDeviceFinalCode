using IoTDevice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace IoTDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IoTDevicePropertiesController : ControllerBase
    {
        public readonly IDeviceProperties _deviceProperties;
        public IoTDevicePropertiesController(IDeviceProperties deviceProperties)
        {
            _deviceProperties = deviceProperties;
        }
       

        

        [HttpPost]
        [Route("UpdateReportedProperties")]
        public IActionResult UpdateDeviceProperty(ReportedProperties iOTReportedProperties)
        {
            return Ok(_deviceProperties.UpdateDeviceProperties(iOTReportedProperties));
        }

        [HttpPost]
        [Route("UpdateDesiredProperties")]
        public IActionResult UpdateDesiredProperties(string deviceName)
        {
            return Ok(_deviceProperties.UpdateDesiredProperties(deviceName));
        }
    }
}
