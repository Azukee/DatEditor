#pragma once
#include <vector>

class AnlagenManager
{
	std::vector<uintptr_t> m_Anlagen;
public:

	AnlagenManager();

	void AddAnlage(uintptr_t anlagenPointer);
};

static AnlagenManager* g_AnlagenManagerInstance;