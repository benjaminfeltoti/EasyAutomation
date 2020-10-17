using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Diagnostics;

namespace EasyAutomation.AutomationFramework.Test
{
    public static class TestApplication
    {
        static Process process;

        internal static Process GetCurrentRunningProcess
        {
            get
            {
                if (process == null)
                {
                    var errorMessage = "ERROR : There is no application running!";
                    Log.Write(errorMessage, TextType.FatalError);
                    throw new Exception(errorMessage);
                }

                return process;
            }
        }

        public static void Start(TestApplicationInformation testApplicationInformation)
        {
            var processStartInfo = new ProcessStartInfo(testApplicationInformation.TestApplicationFileName, testApplicationInformation.TestApplicationArguments);
            processStartInfo.WindowStyle = testApplicationInformation.StartFullScreen ? ProcessWindowStyle.Maximized : default(ProcessWindowStyle);
            processStartInfo.WorkingDirectory = testApplicationInformation.TestApplicationFilePath;

            try
            {
                process = Process.Start(processStartInfo);
                process.EnableRaisingEvents = true;
                process.Exited += OnApplicationExit;
                Log.Write("The test application has been started!", TextType.Warning);
            }
            catch (Exception e)
            {
                Log.Write($"Could not start the test application! {e.Message}", TextType.Error);
                throw;
            }
        }

        public static void StartOrAttach(TestApplicationInformation testApplicationInformation)
        {
            var processes = Process.GetProcessesByName(testApplicationInformation.TestApplicationProcessName);

            if (processes.Length == 0)
            {
                Start(testApplicationInformation);
                return;
            }
            else if (processes.Length > 1)
            {
                var errorMessage = "Multiple processes of the same test application are running! This is not supported! Killing all processes...";

                foreach (var proc in processes)
                {
                    proc.Kill();
                }

                Log.Write(errorMessage, TextType.FatalError);
                throw new Exception(errorMessage);
            }

            if (process != processes[0])
            {
                process = processes[0];
                Log.Write("Attached to the new process!", TextType.SuccessfulAct);
            }
        }

        public static void KillCurrentApplication()
        {
            if (process == null)
            {
                Log.Write("WARNING : There was no process to kill!", TextType.Warning);
                return;
            }

            try
            {
                if (process.HasExited)
                {
                    Log.Write("WARNING : There was no process to kill!", TextType.Warning);
                    return;
                }

                process.Kill();
                process.WaitForExit();
                Log.Write("SUCCEEDED : Application was killed successfully!", TextType.SuccessfulAct);
            }
            catch (Exception e)
            {
                Log.Write($"WARNING : Failed to kill the application! : {e.Message}", TextType.Warning);
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Log.Write("The application has exited!", TextType.Warning);
            process.Exited -= OnApplicationExit;
            process.Dispose();
            process = null;
        }
    }
}
