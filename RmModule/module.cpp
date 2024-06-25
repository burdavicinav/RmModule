#include "pch.h"
#include "module.h"

#import "p_sysinf.tlb"

using namespace P_SYSINFLib;

int module::getCurrentUser()
{
	IOmpUserPtr user;

	HRESULT result = CoCreateInstance(
		__uuidof(OmpUser),
		NULL,
		CLSCTX_INPROC_SERVER,
		__uuidof(IOmpUserPtr),
		(LPVOID*)&user
	);

	if (result == S_OK)
	{
		tagOmpUserData* userData;
		user->GetUserData(&userData);

		return user->Id;
	}

	return -1;
}