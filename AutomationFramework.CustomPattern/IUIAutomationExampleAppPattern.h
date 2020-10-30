#pragma once
#include "stdafx.h"

interface __declspec(uuid("DA1DA733-821A-4B97-AEE3-5D058F88E60E"))
	IUIAutomationExampleAppPattern : public IUnknown
{
	STDMETHOD(SetInputPath)(LPCWSTR path) = 0;
};