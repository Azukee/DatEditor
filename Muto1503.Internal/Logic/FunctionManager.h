#pragma once
#include <Singleton/Singleton.h>

class FunctionManager : public Singleton<FunctionManager>
{
private:
	const uint32_t NO_RESULT = 0xBEDEEFAD; //0xDEADBEEF but scrambled

	uintptr_t m_ParseAnlageRealPointer;

	uintptr_t findParseAnlageReal();
public:
	FunctionManager(SingletonLock);

	void Initialize();

	uintptr_t GetParseAnlageRealPointer();
};