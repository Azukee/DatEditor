#include "AnlagenManager.h"

#include <iostream>

AnlagenManager::AnlagenManager()
{
	m_Anlagen = std::vector<uintptr_t>();
}

void AnlagenManager::AddAnlage(uintptr_t anlagenPointer)
{
	if (std::find(m_Anlagen.begin(), m_Anlagen.end(), anlagenPointer) == m_Anlagen.end())
	{
		m_Anlagen.push_back(anlagenPointer);

		const char* stringPointer = reinterpret_cast<const char*>(reinterpret_cast<char*>(anlagenPointer) + 0x25);
		const char* bauSoundPointer = reinterpret_cast<const char*>(reinterpret_cast<char*>(anlagenPointer) + 0x48);

		printf("%p %s %s\n", reinterpret_cast<void*>(anlagenPointer), stringPointer, bauSoundPointer);
	}
}