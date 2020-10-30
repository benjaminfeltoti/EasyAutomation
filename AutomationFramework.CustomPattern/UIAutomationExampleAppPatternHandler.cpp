#include "stdafx.h"
#include "IUIAutomationExampleAppPatternProvider.h"
#include "UIAutomationExampleAppPattern.h"
#include "UIAutomationExampleAppPatternHandler.h"

UIAutomationExampleAppPatternHandler UIAutomationExampleAppPatternHandler::GlobalInstance;

IFACEMETHODIMP_(ULONG) UIAutomationExampleAppPatternHandler::AddRef()
{
	return InterlockedIncrement(&_refCount);
}

IFACEMETHODIMP_(ULONG) UIAutomationExampleAppPatternHandler::Release()
{
	long val = InterlockedDecrement(&_refCount);
	
	if (val == 0)
	{
		delete this;
	}

	return val;
}

IFACEMETHODIMP UIAutomationExampleAppPatternHandler::QueryInterface(REFIID riid, void** ppInterface)
{
	if (riid == __uuidof(IUnknown) || riid == __uuidof(IUIAutomationPatternHandler))
	{
		*ppInterface = static_cast<IUIAutomationPatternHandler*>(this);
	}
	else
	{
		*ppInterface = nullptr;
		return E_NOINTERFACE;
	}

	static_cast<IUnknown*>(*ppInterface)->AddRef();
	return S_OK;
}

STDMETHODIMP UIAutomationExampleAppPatternHandler::CreateClientWrapper(
	IUIAutomationPatternInstance* pPatternInstance,
	IUnknown** pClientWrapper)
{
	*pClientWrapper = new UIAutomationExampleAppPattern(pPatternInstance);

	if (*pClientWrapper == nullptr)
	{
		return E_INVALIDARG;
	}

	return S_OK;
}

STDMETHODIMP UIAutomationExampleAppPatternHandler::Dispatch(IUnknown* pTarget, UINT index, const struct UIAutomationParameter* pParams, UINT cParams)
{
	return ((IUIAutomationExampleAppPatternProvider*)pTarget)->SetInputPath(*(LPCWSTR*)pParams[0].pData);
}