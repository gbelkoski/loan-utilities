using System.Threading;

namespace FinanceUtilities.UITestsOldapp
{
    public static class DemoHelper
    {
        public static void Pause(int secondsToPause = 3000)
        {
            Thread.Sleep(secondsToPause);
            
        }
    }
}
