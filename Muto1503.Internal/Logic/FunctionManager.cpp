#include "FunctionManager.h"
#include "../Utilities/Logger.h"
#include <windows.h>

FunctionManager::FunctionManager(SingletonLock)
{
}

uintptr_t FunctionManager::findParseAnlageReal()
{
	return reinterpret_cast<uintptr_t>(GetModuleHandleA("AnnoGame.dll") + 0xA680);
}

void FunctionManager::Initialize()
{
	m_ParseAnlageRealPointer = findParseAnlageReal();
}

uintptr_t FunctionManager::GetParseAnlageRealPointer()
{
	return m_ParseAnlageRealPointer;
}
