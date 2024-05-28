#include "HookManager.h"

#include <intrin.h>
#include <iostream>

#include "AnlagenManager.h"
#include "FunctionManager.h"
#include "../Globals.h"
#include "../Utilities/Logger.h"

HookManager::HookManager() {
}

BOOL HookManager::parseAnlageRealHook(uintptr_t thisPointer, const char* buffer, HANDLE hFile,
    uintptr_t annoDisplayVtbl, DWORD* numberOfBytesRead) {

    std::cout << "hook\n";
	BOOL result = g_HookManager->m_ParseAnlageOriginal(thisPointer, buffer, hFile, annoDisplayVtbl,
	                                                              numberOfBytesRead);

    g_AnlagenManager->AddAnlage(thisPointer);

    return result;
}

void HookManager::Initialize() {
    MH_Initialize();
    const auto ptr = g_FunctionManager->GetParseAnlageReal();
    MH_CreateHook(reinterpret_cast<LPVOID>(ptr), &parseAnlageRealHook,
        reinterpret_cast<LPVOID*>(&m_ParseAnlageOriginal));

    MH_EnableHook(MH_ALL_HOOKS);
}