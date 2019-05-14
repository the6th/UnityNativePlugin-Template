﻿
using System.Runtime.InteropServices;

public class NativePluginSample
{
    // Unityエディタ上でもビルドターゲットをiOSにしているとUNITY_IOSがtrueとなるため
    // iOS実機ビルド時のみ __internal 読み込みとなるよう指定
#if UNITY_IOS && !UNITY_EDITOR_OSX
    public const string LIB_NAME = "__Internal";
#else
    public const string LIB_NAME = "NativePlugin";
#endif

    [DllImport(NativePluginSample.LIB_NAME, EntryPoint = "jp_the6th_NativeSample_hogeFunction")]
    private static extern void hogeFunction();
    [DllImport(NativePluginSample.LIB_NAME, EntryPoint = "jp_the6th_NativeSample_fugaFunction")]
    private static extern int fugaFunction(int arg);

    public static void HogeFunction()
    {
        hogeFunction();
    }

    public static int FugaFunction(int arg)
    {
        return fugaFunction(arg);
    }
}