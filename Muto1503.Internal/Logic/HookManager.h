#pragma once
#include <MinHook/MinHook.h>
#include <Singleton/Singleton.h>

class HookManager : public Singleton<HookManager>
{
	typedef BOOL(__thiscall *fnParseAnlageReal)(uintptr_t, const char*, HANDLE, uintptr_t, DWORD*);
	fnParseAnlageReal m_ParseAnlageOriginal;

	static BOOL __thiscall parseAnlageRealHook(uintptr_t thisPointer, const char* buffer, HANDLE hFile, uintptr_t annoDisplayVtbl, DWORD* numberOfBytesRead);
public:
	HookManager(SingletonLock);

	void Initialize();
};

//BOOL __thiscall parseAnlageReal(
//    tAnlageDisplay* this,
//    const char* buffer,
//    HANDLE hFile,
//    int annoDisplayVtbl,
//    _DWORD* numberOfBytesRead) {