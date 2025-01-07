using Metalama.Framework.Aspects;

namespace metalama_demo.metalama
{
    public class Log : OverrideMethodAspect
    {
        public override dynamic? OverrideMethod()
        {
            Console.WriteLine($"Executing {meta.Target.Method}.");

            try
            {
                return meta.Proceed();
            }
            finally
            {
                Console.WriteLine($"Exiting {meta.Target.Method}.");
            }
        }
    }
}
