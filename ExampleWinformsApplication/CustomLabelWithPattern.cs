using ExampleWinformsApplication.UIASupport;
using System.Windows.Automation.Provider;
using System.Windows.Forms;

namespace ExampleWinformsApplication
{
    public class CustomLabelWithPattern : Label
    {
        protected override void WndProc(ref Message m)
        {
            const int WmGetobject = 0x003D;

            if (m.Msg == WmGetobject && (long)m.LParam == AutomationInteropProvider.RootObjectId)
            {
                m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, new CustomElementProvider(this));
                return;
            }

            base.WndProc(ref m);
        }
    }
}
