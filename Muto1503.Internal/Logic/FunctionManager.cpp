#include "FunctionManager.h"
#include "../Utilities/Logger.h"

using namespace sigmatch_literals;

FunctionManager::FunctionManager(SingletonLock)
{
	m_Target = sigmatch::this_process_target();
	m_SearchContext = m_Target.in_module("AnnoGame.dll");
}

uintptr_t FunctionManager::findParseAnlageReal()
{
	auto result = m_SearchContext.search("48 8B C4 55 57 41 55 41 56 41 57 48 8D 6C 24 90"_sig);
	if (result.matches().empty())
		return NO_RESULT;
	Logger::Get().Log("Found 'parseAnlageReal'");
	return reinterpret_cast<uintptr_t>(result.matches().at(0));
}

void FunctionManager::Initialize()
{
	m_ParseAnlageRealPointer = findParseAnlageReal();
}

uintptr_t FunctionManager::GetParseAnlageRealPointer()
{
	return m_ParseAnlageRealPointer;
}
