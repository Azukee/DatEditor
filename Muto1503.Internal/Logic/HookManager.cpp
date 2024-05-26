#include "HookManager.h"

#include <intrin.h>
#include <iostream>

#include "AnlagenManager.h"
#include "FunctionManager.h"
#include "../Utilities/Logger.h"

HookManager::HookManager()
{
    g_HookManagerInstance = this;
}

BOOL HookManager::parseAnlageRealHook(uintptr_t thisPointer, const char* buffer, HANDLE hFile,
                                      uintptr_t annoDisplayVtbl, DWORD* numberOfBytesRead)
{
    const auto& instance = g_HookManagerInstance;
    auto result = instance->m_ParseAnlageOriginal(thisPointer, buffer, hFile, annoDisplayVtbl, numberOfBytesRead);

    auto& anlagenManager = g_AnlagenManagerInstance;
    anlagenManager->AddAnlage(thisPointer);

    std::cout << "hook\n";

    return result;
}

void HookManager::Initialize()
{
    std::cout << MH_Initialize() << "\n";

    const auto ptr = g_FunctionManagerInstance->GetParseAnlageRealPointer();
    printf("%p\n", reinterpret_cast<void*>(ptr));
    std::cout << MH_CreateHook(reinterpret_cast<LPVOID>(ptr), &parseAnlageRealHook,
        reinterpret_cast<LPVOID*>(&m_ParseAnlageOriginal)) << "\n";

    std::cout << MH_EnableHook(reinterpret_cast<LPVOID>(ptr)) << "\n";
}