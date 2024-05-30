#pragma once
#include <memory>
#include <cstdint>
#include <MinHook/MinHook.h>

class HookManager
{
	typedef DWORD(__thiscall *fnParseAnlageReal)(void*, uint8_t*, HANDLE, DWORD*, LPDWORD);
	static void* m_ParseAnlageOriginal;

	static DWORD __thiscall parseAnlageRealHook(void* thisPointer, uint8_t* buffer, HANDLE hFile, DWORD* annoDisplayVtbl, LPDWORD numberOfBytesRead);

public:
	HookManager();

	static void Initialize();
};