// Welcome.cpp : CWelcome µÄÊµÏÖ

#include "stdafx.h"
#include "Welcome.h"


// CWelcome



STDMETHODIMP CWelcome::Greeting(BSTR name, BSTR* message)
{
	CComBSTR temp("Welcome, ");
	temp.Append(name);
	*message = temp;

	return S_OK;
}
