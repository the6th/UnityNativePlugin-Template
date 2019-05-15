
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

    [DllImport(NativePluginSample.LIB_NAME, EntryPoint = "jp_the6th_NativeSample_func1")]
    private static extern void func1();
    [DllImport(NativePluginSample.LIB_NAME, EntryPoint = "jp_the6th_NativeSample_func2")]
    private static extern int func2(int arg);

    public static void Func1()
    {
        func1();
    }

    public static int Func2(int arg)
    {
        return func2(arg);
    }

}