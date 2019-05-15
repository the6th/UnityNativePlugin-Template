#pragma once

#ifdef WINDOWSDLL_EXPORTS // Windows環境でのみ定義
#define NATIVE_API __declspec(dllexport)

#else
#define NATIVE_API

#endif


extern "C" {
	NATIVE_API void jp_the6th_NativeSample_func1();
	NATIVE_API int jp_the6th_NativeSample_func2(int);
}