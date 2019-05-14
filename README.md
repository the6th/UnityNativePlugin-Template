# UnityNativePlugin-Template

## THE GOAL
This project goal is to build a Unity native plugin to call simple c++ code,then it works on multiplatform.

c++ code is simple.

```
//NativePlugin.cpp
#include "NativePlugin.h"

NATIVE_API void jp_the6th_NativeSample_hogeFunction()
{
	return;
}

NATIVE_API int jp_the6th_NativeSample_fugaFunction(int)
{
	return 12;
}

```

## Target Platform (trying now)

|Platform|status|
|---|---|
|Unity Editor(Windows)| :white_check_mark: Success|
|Windows Standalone| :white_check_mark: Success|
|HoloLens 1(UWP/x86)| :white_check_mark: Success|
|HoloLens 2(UWP/ARM64)|Not yet|
|Android (ARM64)| :white_check_mark: Success|
|LuminOS(Magic Leap/ARM64)|:white_check_mark: Success|
|Mac OS|Not yet|
|iOS|Not yet|

---

## System requirement
* Windows 10
* Unity 2019.1.0f1
* Visual Studio 2017
