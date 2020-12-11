using System;
using System.IO;
using System.Threading;

namespace OpenIRacingTools.Sdk.Cli
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MonitorSim();
        }

        private static void MonitorSim()
        {
            var sdk = new Sdk();
            sdk.Start().WaitForConnection();

            while(true)
            {
                var data = sdk.SessionData;
                var raw = sdk.RawSessionData;

                if (!string.IsNullOrEmpty(raw)) { 
                    File.WriteAllText(@"C:\Users\matth\Downloads\iRacingSessionData\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".yaml", raw);
                }

                Thread.Sleep(10000);
            }

            sdk.Stop();

            Console.WriteLine("Hello World!");
        }

        private static void UnserializeSessionInfoFromFile()
        {
            /*
            var deserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .WithTypeConverter(new DoubleTypeConverter())
                .WithTypeConverter(new DoubleUnitTypeConverter())
                .WithTypeConverter(new BooleanTypeConverter())
                .Build();

            var result = deserializer.Deserialize<SessionInfoNg>(File.ReadAllText(@"C:\Users\matth\Documents\test.yaml"));
            */
        }
    }
}
