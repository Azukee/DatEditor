#pragma once
#include <MinHook/MinHook.h>

class HookManager
{
	typedef BOOL(__thiscall *fnParseAnlageReal)(uintptr_t, const char*, HANDLE, uintptr_t, DWORD*);
	fnParseAnlageReal m_ParseAnlageOriginal;

	static BOOL parseAnlageRealHook(uintptr_t thisPointer, const char* buffer, HANDLE hFile, uintptr_t annoDisplayVtbl, DWORD* numberOfBytesRead);
public:

	HookManager();

	void Initialize();
};

static HookManager* g_HookManagerInstance;