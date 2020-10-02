
namespace EasyAutomation.AutomationFramework.Test
{
    public class TestApplicationInformation
    {        
        /// <summary>
        /// Class that contains informations for starting the test application.
        /// </summary>
        /// <param name="testApplicationFileName">Name of the file to start. (Including .exe)</param>
        /// <param name="testApplicationFilePath">Path of the file, where to start it, if it is not at the same directory as this the AutomationFramework.dll</param>
        /// <param name="testApplicationArguments">Arguments to start with the test application. Optional.</param>
        /// <param name="startFullScreen">Set true if the test application has to run fullscreen.</param>
        public TestApplicationInformation(string testApplicationFileName, string testApplicationFilePath = "", string testApplicationArguments = "", bool startFullScreen = false)
        {
            TestApplicationFileName = testApplicationFileName;
            TestApplicationFilePath = testApplicationFilePath;
            TestApplicationArguments = testApplicationArguments;
            StartFullScreen = startFullScreen;
        }

        public string TestApplicationFileName { get; }

        public string TestApplicationFilePath { get; }

        public string TestApplicationArguments { get; }

        public bool StartFullScreen { get; }
    }
}
