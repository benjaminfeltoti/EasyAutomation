#pragma once
#include "stdafx.h"

interface __declspec(uuid(""))
	IUIAutomationExampleAppPattern : public IUnknown
{
	STDMETHOD(SetInputPath)(LPCWSTR path) = 0;
};