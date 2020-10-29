#pragma once
#include "stdafx.h"

class UIAutomationExampleAppPatternHandler : public IUIAutomationPatternHandler
{
	ULONG _refCount;

public:

	UIAutomationExampleAppPatternHandler() :_refCount(1L) 
	{
	
	}

	//IUnknown
	IFACEMETHOD_(ULONG, AddRef)();
	IFACEMETHOD_(ULONG, Release)();
	IFACEMETHOD(QueryInterface)(REFIID riid, void** ppInterface);

	STDMETHOD(CreateClientWrapper)(IUIAutomationPatternInstance* pPatternInstance, IUnknown** pClientWrapper);
	STDMETHOD(Dispatch)(IUnknown* pTarget, UINT index, const struct UIAutomationParameter* pParams, UINT cParams);

	static UIAutomationExampleAppPatternHandler GlobalInstance;
};