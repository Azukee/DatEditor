#include "HookManager.h"

#include <intrin.h>

#include "AnlagenManager.h"
#include "FunctionManager.h"
#include "../Utilities/Logger.h"

HookManager::HookManager(SingletonLock)
{

}

BOOL HookManager::parseAnlageRealHook(uintptr_t thisPointer, const char* buffer, HANDLE hFile,
                                      uintptr_t annoDisplayVtbl, DWORD* numberOfBytesRead)
{
	const auto& instance = Get();
    auto result = instance.m_ParseAnlageOriginal(thisPointer, buffer, hFile, annoDisplayVtbl, numberOfBytesRead);

    auto& anlagenManager = AnlagenManager::Get();
    anlagenManager.AddAnlage(thisPointer);

    return result;
}

void HookManager::Initialize()
{
    MH_Initialize();

    const auto ptr = FunctionManager::Get().GetParseAnlageRealPointer();
    MH_CreateHook(reinterpret_cast<LPVOID>(ptr), &parseAnlageRealHook, 
        reinterpret_cast<LPVOID*>(&m_ParseAnlageOriginal));

    MH_EnableHook(reinterpret_cast<LPVOID>(ptr));
}