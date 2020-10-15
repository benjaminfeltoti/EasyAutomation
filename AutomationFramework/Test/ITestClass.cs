namespace EasyAutomation.AutomationFramework.Test
{
    public interface ITestClass
    {
        /// <summary>
        /// TestMethods to run. IMPORTANT! Add testmethods only as methods, not as delegates!!!
        /// </summary>
        ITest[] Tests { get; }

        void SetupClass();

        void CleanupClass();
    }
}
