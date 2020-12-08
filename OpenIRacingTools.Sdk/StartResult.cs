using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk
{
    public class StartResult
    {
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
