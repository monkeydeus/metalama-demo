using System.Diagnostics;
using Metalama.Framework.Aspects;

namespace metalama_library
{
    public class Profile : OverrideMethodAspect
    {
        public override dynamic? OverrideMethod()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                return meta.Proceed();
            }
            finally
            {
                Console.WriteLine(
                    $"{meta.Target.Method} completed in {stopwatch.ElapsedMilliseconds}.");
            }
        }
    }
}
