#include "FunctionManager.h"

#include <iostream>

#include "../Utilities/Logger.h"
#include <windows.h>

FunctionManager::FunctionManager()
{
	g_FunctionManagerInstance = this;
}

uintptr_t FunctionManager::findParseAnlageReal()
{
	auto ptr = reinterpret_cast<uintptr_t>(reinterpret_cast<char*>(GetModuleHandleA("AnnoGame.dll")) + 0xA680);
	printf("%p\n", reinterpret_cast<void*>(ptr));
	return ptr;
}

void FunctionManager::Initialize()
{
	m_ParseAnlageRealPointer = findParseAnlageReal();
	std::cout << "[x] FunctionManager::Initialize\n";
}

uintptr_t FunctionManager::GetParseAnlageRealPointer()
{
	return m_ParseAnlageRealPointer;
}
