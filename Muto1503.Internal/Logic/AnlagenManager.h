#pragma once
#include <memory>
#include <algorithm>
#include <vector>

class AnlagenManager
{
	std::vector<uintptr_t> m_Anlagen;
public:

	AnlagenManager();

	void AddAnlage(uintptr_t anlagenPointer);
};