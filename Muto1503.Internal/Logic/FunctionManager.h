#pragma once
#include <cstdint>
class FunctionManager
{
private:
	const uint32_t NO_RESULT = 0xBEDEEFAD; //0xDEADBEEF but scrambled

	uintptr_t m_ParseAnlageRealPointer;

	uintptr_t findParseAnlageReal();
public:

	FunctionManager();

	void Initialize();

	uintptr_t GetParseAnlageRealPointer();
};

static FunctionManager* g_FunctionManagerInstance;