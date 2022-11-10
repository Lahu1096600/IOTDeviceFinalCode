using System;
using Microsoft.Azure.Devices.Client;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace IoTDevice.Models
{
    public class IoTDeviceTelemetryMessage
    {
        //public  DeviceClient s_deviceClient;
        private static string s_connectionString01 = "HostName=IoTHub1310.azure-devices.net;DeviceId=IoTtest1;SharedAccessKey=cL15RUboK3kItXQ86k9FdbPoIwHu+69J2x76MfKFIeY=";

        public static async void SendDeviceToCloudMessagesAsync()
        {
            try
            {
                DeviceClient _deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString01, TransportType.Mqtt);
                double minTemperature = 20;
                double minHumidity = 60;
                Random rand = new Random();

                while (true)
                {
                    double currentTemperature = minTemperature + rand.NextDouble() * 15;
                    double currentHumidity = minHumidity + rand.NextDouble() * 20;

                    // Create JSON message  

                    var telemetryDataPoint = new
                    {

                        temperature = currentTemperature,
                        humidity = currentHumidity
                    };

                    string messageString = "";



                    messageString = JsonConvert.SerializeObject(telemetryDataPoint);

                    var message = new Message(Encoding.ASCII.GetBytes(messageString));

                    // Add a custom application property to the message.  
                    // An IoT hub can filter on these properties without access to the message body.  
                    //message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");  

                    // Send the telemetry message  
                    await _deviceClient.SendEventAsync(message);
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
                    await Task.Delay(1000 * 10);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}