#include "FunctionManager.h"

#include <iostream>
#include <windows.h>

FunctionManager::FunctionManager()
{
}

uintptr_t FunctionManager::GetParseAnlageReal()
{
	return reinterpret_cast<uintptr_t>(reinterpret_cast<char*>(GetModuleHandleA("AnnoGame.dll")) + 0xA680);
}