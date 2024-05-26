#include "Logger.h"

#include <iostream>

Logger::Logger(SingletonLock)
{

}

void Logger::Log(const std::string& text) const
{
	std::cout << "[!] " << text << "\n";
}
