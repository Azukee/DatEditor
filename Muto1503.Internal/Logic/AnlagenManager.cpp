#include "AnlagenManager.h"

#include "../Utilities/Logger.h"

AnlagenManager::AnlagenManager(SingletonLock)
{
	m_Anlagen = std::vector<uintptr_t>();
}

void AnlagenManager::AddAnlage(uintptr_t anlagenPointer)
{
	if (std::find(m_Anlagen.begin(), m_Anlagen.end(), anlagenPointer) == m_Anlagen.end())
	{
		m_Anlagen.push_back(anlagenPointer);
	}
}
