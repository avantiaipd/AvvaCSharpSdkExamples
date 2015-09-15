using AvvaCSharpSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AvvaCSharpSdkExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string host = "http://localhost:61773";
                string secretKey = "a9bfaef562396c30abed90577ebc00c1";

                SpectatorAlertsClient alertsClient = new SpectatorAlertsClient(
                    host, 
                    secretKey
                );

                alertsClient.OnAlertTriggered += AlertsClient_AlertTriggeredEvent;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            ReadKey();
        }

        private static void AlertsClient_AlertTriggeredEvent(object sender, 
            SpectatorAlertEventArgs e)
        {
            WriteLine($"{e.CameraName} at {e.CreatedAt}");
        }
    }
}