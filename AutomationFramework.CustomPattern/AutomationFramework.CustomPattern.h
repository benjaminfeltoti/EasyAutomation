#pragma once
#pragma comment(lib, "Ole32")

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Runtime::CompilerServices;

namespace AutomationFrameworkCustomPattern
{
	public ref class PatternRegistrar abstract sealed
	{
	public:
		static bool RegisterExampleAppPattern();
		static property int RegisteredExampleAppPatternId
		{
			int get();
		}
	private:
		static int registerExampleAppPatternId;
	};

	[ComImport]
	[InterfaceType(ComInterfaceType::InterfaceIsIUnknown)]
	[Guid("DA1DA733-821A-4B97-AEE3-5D058F88E60E")]
	public interface class IExampleAppPattern
	{
		[MethodImpl(MethodImplOptions::InternalCall)]
		void SetInputPath([In][MarshalAs(UnmanagedType::BStr)] String^ path);
	};
}