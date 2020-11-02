using System;
using System.Runtime.InteropServices;

namespace ExampleWinformsApplication.UIASupport
{
    //Provider GUID
    [ComVisible(true)]
    [Guid("84823B08-3DCC-4313-B3CE-1288D77FDB9C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IExampleAppPatternProvider
    {
        void SetInputPath([MarshalAs(UnmanagedType.LPWStr)] string path);
    }
}
