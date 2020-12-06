using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk
{
    public class StartResult
    {
        public StartResult(SdkWrapper sdk)
        {
            ConnectionAwaiter = Task.Run(() =>
            {
                while (true)
                {
                    if (sdk.IsConnected)
                    {
                        return;
                    }

                    Thread.Sleep(10);
                }
            });
        }

        public Task ConnectionAwaiter { get; }

        public void WaitForConnection()
        {
            ConnectionAwaiter.Wait();
        }
    }
}
