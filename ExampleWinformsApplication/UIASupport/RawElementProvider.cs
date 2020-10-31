using ExampleWinformsApplication.UIASupport.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Automation.Provider;
using System.Windows.Forms;

namespace ExampleWinformsApplication.UIASupport
{
    public class CustomElementProvider : IRawElementProviderSimple
    {
        private const string patternRegistrarClassName = @"PatternRegistrar";
        private const string customPatternAssembly = @"AutomationFramework.CustomPattern, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        private const string registeredPatternIdPropertyName = @"RegisteredExampleAppPatternId";
        private const string patternRegisterMethod = @"RegisterExampleAppPattern";

        private readonly Dictionary<int, object> supportedProviders;
        private readonly Control control;
        private readonly int controlTypeId;

        private static int? ExampleAppPatternId { get; set; }

        static CustomElementProvider()
        {
            RegisterExampleAppPattern();
        }

        static void RegisterExampleAppPattern() 
        {
            try
            {
                Assembly assembly = Assembly.Load(customPatternAssembly);
                var registrarClass = assembly.GetTypes().FirstOrDefault(c => c.Name == patternRegistrarClassName);
                var registrarMethod = registrarClass.GetMethod(patternRegisterMethod);
                bool patternRegistered = (bool)registrarMethod.Invoke(null, null);
                var propertyInfo = registrarClass.GetProperty(registeredPatternIdPropertyName);

                ExampleAppPatternId = (int)propertyInfo.GetValue(registrarClass);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CustomElementProvider(Control control, int controlTypeId = 50033)// 50033 = pane
        {
            this.control = control;
            this.controlTypeId = controlTypeId;
            supportedProviders = new Dictionary<int, object>();

            var provider = new ExampleAppPatternProvider(control);
            AddSupportedProvider((int)ExampleAppPatternId, provider);
        }

        public object GetPatternProvider(int patternId)
        {
            object result = null;

            supportedProviders.TryGetValue(patternId, out result);
            return result;
        }

        public object GetPropertyValue(int propertyId)
        {
            if (control.IsDisposed)
            {
                return null;
            }

            switch (propertyId)
            {
                case UIAPropertyID.AutomationId:
                    return control.AccessibleName;

                case UIAPropertyID.BoundingRectangle:
                    return control.Bounds;

                case UIAPropertyID.ControlType:
                    return controlTypeId;

                case UIAPropertyID.HelpText:
                    return control.Text;

                case UIAPropertyID.IsEnabled:
                    return control.Enabled;

                // Needs to be implemented
                case UIAPropertyID.IsOffscreen:
                    return false;

                case UIAPropertyID.LocalizedControlType:
                    return "Custom Control Type";

                case UIAPropertyID.Name:
                    return control.AccessibleName;

                default: return null;
            }
        }

        public ProviderOptions ProviderOptions => ProviderOptions.ServerSideProvider;

        public IRawElementProviderSimple HostRawElementProvider => AutomationInteropProvider.HostProviderFromHandle(control.Handle);

        void AddSupportedProvider(int patternId, object provider)
        {
            supportedProviders.Add(patternId, provider);
        }
    }
}
