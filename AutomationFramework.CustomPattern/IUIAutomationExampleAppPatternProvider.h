#pragma once
#include "stdafx.h"

interface __declspec(uuid(""))
	IUIAutomationExampleAppPatternProvider : public IUnknown
{
	STDMETHOD(SetInputPath)(LPCWSTR path) = 0;
};