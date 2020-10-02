using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.AutomationFramework.Test
{
    public static class TestApplication
    {
        static Process process;

        internal static Process CurrentRunningProcess()
        {
            return process;
        }

        public static void Start(TestApplicationInformation testApplicationInformation)
        {
            var processStartInfo = new ProcessStartInfo(testApplicationInformation.TestApplicationFileName, testApplicationInformation.TestApplicationArguments);
            processStartInfo.WindowStyle = testApplicationInformation.StartFullScreen ? ProcessWindowStyle.Maximized : default(ProcessWindowStyle);
            processStartInfo.WorkingDirectory = testApplicationInformation.TestApplicationFilePath;
            
            try
            {
                process = Process.Start(processStartInfo);
                Log.Write("The test application has been started!", TextType.Warning);
                process.Exited += OnApplicationExit;
            }
            catch (Exception e)
            {
                Log.Write($"Could not start the test application! {e.Message}", TextType.Error);
                throw;
            }
        }

        /*public static void StartOrAttach
        { 
        
        }*/

        public static void KillCurrentApplication()
        {
            if (process == null)
            {
                return;
            }

            try
            {
                if (process.HasExited)
                {
                    return;
                }
                
                process.Kill();
                process.WaitForExit();
                process.Exited -= OnApplicationExit;
                process.Dispose();
            }
            catch 
            {
            
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Log.Write("The application has exited!", TextType.Warning);
        }
    }
}
