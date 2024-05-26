#pragma once
#include <vector>
#include <Singleton/Singleton.h>

class AnlagenManager : public Singleton<AnlagenManager>
{
	std::vector<uintptr_t> m_Anlagen;
public:
	AnlagenManager(SingletonLock);

	void AddAnlage(uintptr_t anlagenPointer);
};