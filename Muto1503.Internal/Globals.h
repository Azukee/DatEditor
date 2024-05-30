#pragma once
#include "Logic/AnlagenManager.h"
#include "Logic/FunctionManager.h"
#include "Logic/HookManager.h"

static FunctionManager* g_FunctionManager = new FunctionManager();
//static HookManager* g_HookManager = new HookManager();
static AnlagenManager* g_AnlagenManager = new AnlagenManager();