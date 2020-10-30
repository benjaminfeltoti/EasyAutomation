#pragma once
#include "stdafx.h"
// PATTERN UID
// {DA1DA733-821A-4B97-AEE3-5D058F88E60E}
//static const GUID << name >> =
//{ 0xda1da733, 0x821a, 0x4b97, { 0xae, 0xe3, 0x5d, 0x5, 0x8f, 0x88, 0xe6, 0xe } };

/// PATTERN PROVIDER UID
/// // {84823B08-3DCC-4313-B3CE-1288D77FDB9C}
// static const GUID << name >> =
// { 0x84823b08, 0x3dcc, 0x4313, { 0xb3, 0xce, 0x12, 0x88, 0xd7, 0x7f, 0xdb, 0x9c } };

interface __declspec(uuid("84823B08-3DCC-4313-B3CE-1288D77FDB9C"))
	IUIAutomationExampleAppPatternProvider : public IUnknown
{
	STDMETHOD(SetInputPath)(LPCWSTR path) = 0;
};