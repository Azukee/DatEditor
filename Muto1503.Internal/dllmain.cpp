#include <iostream>
#include <Windows.h>
#include "Logic/FunctionManager.h"
#include "Logic/HookManager.h"

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        AllocConsole();
        FILE* dummy;
        freopen_s(&dummy, "conout$", "w", stdout);
        freopen_s(&dummy, "conout$", "w", stderr);
        std::cout << "[x] Hello from Muto1503.Internal!\n";

        auto functionManager = FunctionManager();
        functionManager.Initialize();

        auto hookManager = HookManager();
        hookManager.Initialize();
        break;
    }
    return TRUE;
}