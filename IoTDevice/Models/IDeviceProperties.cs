namespace IoTDevice.Models
{
    public interface IDeviceProperties
    {
        Task UpdateDeviceProperties(ReportedProperties reportedProperties);
        Task UpdateDesiredProperties(string deviceName);
       
    }
}
