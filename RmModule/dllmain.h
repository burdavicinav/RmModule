// dllmain.h: объявление класса модуля.

class CRmModuleModule : public ATL::CAtlDllModuleT< CRmModuleModule >
{
public :
	DECLARE_LIBID(LIBID_RmModuleLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_RMMODULE, "{95cd2de4-25d9-4230-8788-26eb7a054301}")
};

extern class CRmModuleModule _AtlModule;
