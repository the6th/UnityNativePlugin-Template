#pragma once

#ifdef UNITY_WINDOWS // Windows環境でのみ定義
#define NATIVE_API __declspec(dllexport)

#else
#define NATIVE_API

#endif


extern "C" {
	NATIVE_API void jp_the6th_NativeSample_hogeFunction();
	NATIVE_API int jp_the6th_NativeSample_fugaFunction(int);
}