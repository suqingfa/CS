// Welcome.h : CWelcome ������

#pragma once
#include "resource.h"       // ������



#include "COM_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif

using namespace ATL;


// CWelcome

class ATL_NO_VTABLE CWelcome :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CWelcome, &CLSID_Welcome>,
	public IDispatchImpl<IWelcome, &IID_IWelcome, &LIBID_��������COMLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CWelcome()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_WELCOME)


BEGIN_COM_MAP(CWelcome)
	COM_INTERFACE_ENTRY(IWelcome)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:



	STDMETHOD(Greeting)(BSTR name, BSTR* message);
};

OBJECT_ENTRY_AUTO(__uuidof(Welcome), CWelcome)
