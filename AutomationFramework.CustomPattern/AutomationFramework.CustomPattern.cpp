#include "stdafx.h"
#include "AutomationFramework.CustomPattern.h"
#include "UIAutomationExampleAppPattern.h"
#include "UIAutomationExampleAppPatternHandler.h"

int AutomationFrameworkCustomPattern::PatternRegistrar::RegisteredExampleAppPatternId::get()
{
	return registerExampleAppPatternId;
}

bool AutomationFrameworkCustomPattern::PatternRegistrar::RegisterExampleAppPattern()
{
	IUIAutomationRegistrar* pUIARegistrar = nullptr;

	HRESULT result = CoCreateInstance(
		CLSID_CUIAutomationRegistrar, NULL, CLSCTX_INPROC_SERVER, IID_IUIAutomationRegistrar, (void **)&pUIARegistrar);

	if (pUIARegistrar == nullptr)
	{
		CoUninitialize();
		return false;
	}

	UIAutomationExampleAppPattern::InitPatternInfo(UIAutomationExampleAppPatternHandler::GlobalInstance);

	result = pUIARegistrar->RegisterPattern(
		&UIAutomationExampleAppPattern::PatternInfo, &UIAutomationExampleAppPattern::RegisteredPatternId,
		&UIAutomationExampleAppPattern::ExampleAppPatternAvaliablePropertyId, 0, nullptr, 0, nullptr);

	pUIARegistrar->Release();
	registerExampleAppPatternId = UIAutomationExampleAppPattern::RegisteredPatternId;
	return result == S_OK;
}