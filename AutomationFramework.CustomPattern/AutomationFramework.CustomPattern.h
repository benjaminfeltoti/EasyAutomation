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

	[ComImportAttribute]
	[InterfaceTypeAttribute(ComInterfaceType::InterfaceIsIUnknown)]
	[Guid("")]
	public interface class IExampleAppPattern
	{
		[MethodImpl(MethodImplOptions::InternCall)]
		void SetInputPath([in][MarshalAs(UnmanagedType::BStr)] String^ path);
	};
}