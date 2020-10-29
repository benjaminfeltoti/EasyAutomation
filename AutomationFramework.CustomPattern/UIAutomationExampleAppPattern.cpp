#include "stdafx.h"
#include "UIAutomationExampleAppPattern.h"
#include "IUIAutomationExampleAppPatternProvider.h"

const GUID UIAutomationExampleAppPattern::PatternGuid = { {} };

const LPCWSTR UIAutomationExampleAppPattern::PatternName = L"ExampleAppPattern";
UIAutomationType UIAutomationExampleAppPattern::ParamType = { UIAutomationType_String };
LPCWSTR UIAutomationExampleAppPattern::ParamName = { L"path" };
UIAutomationMethodInfo UIAutomationExampleAppPattern::PatternMethods[] =
{
	{L"ExampleAppPattern.SetInputPath",TRUE,1,0,&UIAutomationExampleAppPattern::ParamType, &UIAutomationExampleAppPattern::ParamName}
};
int UIAutomationExampleAppPattern::RegisteredPatternId = -1;
int UIAutomationExampleAppPattern::ExampleAppPatternAvaliablePropertyId = -1;
UIAutomationPatternInfo UIAutomationExampleAppPattern::PatternInfo;

IFACEMETHODIMP_(ULONG) UIAutomationExampleAppPattern::AddRef()
{
	return InterlockedIncrement(&_refCount);
}

IFACEMETHODIMP_(ULONG) UIAutomationExampleAppPattern::Release()
{
	long val = InterlockedDecrement(&_refCount);

	if (val == 0)
	{
		delete this;
	}

	return val;
}

IFACEMETHODIMP UIAutomationExampleAppPattern::QueryInterface(REFIID riid, void** ppInterface)
{
	if (riid == __uuidof(IUnknown) || riid == __uuidof(IUIAutomationExampleAppPattern))
	{
		*ppInterface = static_cast<IUIAutomationExampleAppPattern*>(this);
	}
	else
	{
		*ppInterface = nullptr;
		return E_NOINTERFACE;
	}

	static_cast<IUnknown*>(*ppInterface)->AddRef();
	return S_OK;
}

STDMETHODIMP UIAutomationExampleAppPattern::SetInputPath(LPCWSTR path)
{
	UIAutomationParameter uiaParameter = { UIAutomationType_String, &path };

	HRESULT result = _pInstance->CallMethod(0, &uiaParameter, 1);
	return result;
}

void UIAutomationExampleAppPattern::InitPatternInfo(IUIAutomationPatternHandler& patternHandler)
{
	PatternInfo.guid = PatternGuid;
	PatternInfo.pProgrammaticName = PatternName;
	PatternInfo.clientInterfaceId = __uuidof(IUIAutomationExampleAppPattern);
	PatternInfo.providerInterfaceId = __uuidof(IUIAutomationExampleAppPatternProvider);
	PatternInfo.pMethods = &UIAutomationExampleAppPattern::PatternMethods[0];
	PatternInfo.cMethods = ARRAYSIZE(UIAutomationExampleAppPattern::PatternMethods);
	PatternInfo.cProperties = 0;
	PatternInfo.pProperties = nullptr;
	PatternInfo.cEvents = 0;
	PatternInfo.pEvents = nullptr;
	PatternInfo.pPatternHandler = &patternHandler;
}