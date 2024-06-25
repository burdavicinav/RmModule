// ApplicationOnResourceReport.h: объявление CApplicationOnResourceReport

#pragma once
#include "resource.h"       // основные символы
#include "RmModule_i.h"

#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Однопотоковые COM-объекты не поддерживаются должным образом платформой Windows CE, например платформами Windows Mobile, в которых не предусмотрена полная поддержка DCOM. Определите _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA, чтобы принудить ATL поддерживать создание однопотоковых COM-объектов и разрешить использование его реализаций однопотоковых COM-объектов. Для потоковой модели в вашем rgs-файле задано значение 'Free', поскольку это единственная потоковая модель, поддерживаемая не-DCOM платформами Windows CE."
#endif

using namespace ATL;

// CApplicationOnResourceReport
class ATL_NO_VTABLE CApplicationOnResourceReport :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CApplicationOnResourceReport, &CLSID_ApplicationOnResourceReport>,
	public IOmpTask
{
public:
	CApplicationOnResourceReport()
	{
	}

DECLARE_REGISTRY_RESOURCEID(106)

DECLARE_NOT_AGGREGATABLE(CApplicationOnResourceReport)

BEGIN_COM_MAP(CApplicationOnResourceReport)
	COM_INTERFACE_ENTRY(IOmpTask)
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

	STDMETHOD(Run)(HWND parent, HWND* created_wnd, long* error_code);

};

OBJECT_ENTRY_AUTO(__uuidof(ApplicationOnResourceReport), CApplicationOnResourceReport)