#pragma once
#include <Singleton/Singleton.h>

class Logger : public Singleton<Logger>
{
public:
	Logger(SingletonLock);

	void Log(const std::string& text) const;
};