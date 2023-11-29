using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Config;

namespace TesterLog
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static async Task TaskFunc()
        {
            int count = 5;
            while (count > 0)
            {
                int delayTimeMS = 1000;
                await Task.Delay(delayTimeMS);
                log.InfoFormat("count: {0}", count);
                log.InfoFormat("Delay ms: {0}", delayTimeMS);
                count--;
            }
        }

        static void Main(string[] args)
        {
            // Initialize log4net
            XmlConfigurator.Configure();

            log.Info("Main app started");

            // block while the task completes
            var task = Task.Run( async () => { await TaskFunc(); } );
            task.Wait();

            log.Info("Main app ended");
        }
    }
}
