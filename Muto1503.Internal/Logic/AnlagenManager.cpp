#include "AnlagenManager.h"

#include <format>

#include "../Utilities/Logger.h"

AnlagenManager::AnlagenManager(SingletonLock)
{
	m_Anlagen = std::vector<uintptr_t>();
}

void AnlagenManager::AddAnlage(uintptr_t anlagenPointer)
{
	if (std::ranges::find(m_Anlagen, anlagenPointer) == m_Anlagen.end())
	{
		m_Anlagen.push_back(anlagenPointer);
	}
}
