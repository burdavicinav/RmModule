// ApplicationOnResourceReport.cpp: реализация CApplicationOnResourceReport

#include "pch.h"
#include "module.h"
#include "ApplicationOnResourceReport.h"

using namespace RmUI::Runners;

// CApplicationOnResourceReport
HRESULT __stdcall CApplicationOnResourceReport::Run(HWND parent, HWND* created_wnd, long* error_code) {
	// вызывается при запуске задачи в системе
	
	// текущий пользователь
	int user = module::getCurrentUser();

	(gcnew ApplicationOnResourceRunner(user))->Run();

	return S_OK;
}