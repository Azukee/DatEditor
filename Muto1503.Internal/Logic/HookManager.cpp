#include "HookManager.h"

#include <intrin.h>
#include <iostream>

#include "AnlagenManager.h"
#include "FunctionManager.h"
#include "../Globals.h"

void* HookManager::m_ParseAnlageOriginal;
HookManager::HookManager()
{
	HookManager::m_ParseAnlageOriginal = nullptr;
}

DWORD __thiscall HookManager::parseAnlageRealHook(void* thisPointer, uint8_t* buffer, HANDLE hFile, DWORD* annoDisplayVtbl, LPDWORD numberOfBytesRead)
{
	DWORD result = reinterpret_cast<fnParseAnlageReal>(HookManager::m_ParseAnlageOriginal)(thisPointer, buffer, hFile, annoDisplayVtbl, numberOfBytesRead);
	
    g_AnlagenManager->AddAnlage(reinterpret_cast<uintptr_t>(thisPointer));

    return result;
}

void HookManager::Initialize()
{
    MH_Initialize();

    MH_CreateHook(reinterpret_cast<LPVOID>(g_FunctionManager->GetParseAnlageReal()), &parseAnlageRealHook, reinterpret_cast<LPVOID*>(&m_ParseAnlageOriginal));

    MH_EnableHook(MH_ALL_HOOKS);
}