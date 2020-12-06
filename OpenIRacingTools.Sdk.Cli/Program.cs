using System;
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
            var sdk = new SdkWrapper();
            sdk.Start().WaitForConnection();

            Thread.Sleep(10000);

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
