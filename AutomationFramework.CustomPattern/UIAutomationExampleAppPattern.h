#pragma once
#include "IUIAutomationExampleAppPattern.h"

class UIAutomationExampleAppPattern : public IUIAutomationExampleAppPattern
{
	ULONG _refCount;
	IUIAutomationPatternInstance* _pInstance;

	const static GUID PatternGuid;
	const static LPCWSTR PatternName;
	static UIAutomationType ParamType;
	static LPCWSTR ParamName;
	static UIAutomationMethodInfo PatternMethods[];

public:

	UIAutomationExampleAppPattern(IUIAutomationPatternInstance* pInstance) : _refCount(1L), _pInstance(pInstance)
	{
		_pInstance->AddRef();
	}

	~UIAutomationExampleAppPattern()
	{
		_pInstance->Release();
	}

	//IUnknown
	IFACEMETHOD(ULONG, AddRef)();
	IFACEMETHOD(ULONG, Release)();
	IFACEMETHOD(QuaryInterface)(REFIID riid, void** ppInterface);

	//IExampleAppPattern
	STDMETHOD(SetInputPath)(LPCWSTR path);
	static void InitPatternInfo(IUIAutomationPatternHandler& patternHandler);
	static int RegisteredPatternId;
	static int ExampleAppPatternAvaliablePropertyId;
	static UIAutomationPatternInfo PatternInfo;
};