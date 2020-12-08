using System.Threading;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk
{
    public class StartResult
    {
        private readonly Task connectionTask;
        private readonly Task dataTask;

        public StartResult(Task connectionTask, Task dataTask)
        {
            ConnectionAwaiter = connectionTask;
            DataAwaiter = dataTask;
        }

        public Task ConnectionAwaiter { get; }
        public Task DataAwaiter { get; }

        public void WaitForConnection()
        {
            ConnectionAwaiter.Wait();
        }

        public void WaitForFirstData()
        {
            DataAwaiter.Wait();
        }
    }
}
