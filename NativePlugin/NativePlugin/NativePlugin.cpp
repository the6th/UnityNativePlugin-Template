
#ifdef UNITY_WINDOWS // Windows環境でのみ定義
#define NATIVE_API __declspec(dllexport)

#else
#define NATIVE_API

#endif

#include "NativePlugin.h"

NATIVE_API void jp_the6th_NativeSample_hogeFunction()
{
	return;
}

NATIVE_API int jp_the6th_NativeSample_fugaFunction(int)
{
	return 12;
}

