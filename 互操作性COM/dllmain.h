// dllmain.h: ģ�����������

class CCOMModule : public ATL::CAtlDllModuleT< CCOMModule >
{
public :
	DECLARE_LIBID(LIBID_��������COMLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_COM, "{4C2D1507-08B0-44D2-9C14-6224D9B0A0C7}")
};

extern class CCOMModule _AtlModule;
