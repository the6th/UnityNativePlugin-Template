using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using size_t = System.UIntPtr;

static class ZSTD
{
    // Unityエディタ上でもビルドターゲットをiOSにしているとUNITY_IOSがtrueとなるため
    // iOS実機ビルド時のみ __internal 読み込みとなるよう指定
#if UNITY_IOS && !UNITY_EDITOR_OSX
    public const string LIB_NAME = "__Internal";
#elif UNITY_ANDROID && !UNITY_EDITOR
    public const string LIB_NAME = "zstd";
#else
    public const string LIB_NAME = "libzstd";
#endif

    [DllImport(ZSTD.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern size_t ZSTD_compress(IntPtr dst, size_t dstCapacity, IntPtr src, size_t srcSize, int compressionLevel);

    [DllImport(ZSTD.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern size_t ZSTD_compressBound(size_t srcSize);

    [DllImport(ZSTD.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong ZSTD_getDecompressedSize(IntPtr src, size_t srcSize);

    [DllImport(ZSTD.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern size_t ZSTD_decompress(IntPtr dst, size_t dstSize, IntPtr src, size_t srcSize);


    /*
     * 		// *2, because according to zstd documentation, increasing the size of the output buffer above a 
    // bound should speed up the compression.
    int cBuffSize = ZSTD_compressBound(size) * 2;
    vector<char> compressedBuffer(cBuffSize);
    int cSize = ZSTD_compress(compressedBuffer.data(), cBuffSize, buffer.data(), size, m_iCompressionLevel);
    size = cSize;
    buffer = compressedBuffer;

     */
    public static byte[] Compress(byte[] array)
    {
        int size = array.Count();
        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.Copy(array, 0, ptr, size);

        int outSize = (int)ZSTD_compressBound((size_t)size) / 2;

        IntPtr outPtr = Marshal.AllocHGlobal(outSize);
        //ZSTD_decompress(outPtr, (size_t)outSize, ptr, (size_t)size);
        ZSTD_compress(outPtr, (size_t)outSize, ptr, (size_t)size, 2);


        byte[] outArray = new byte[outSize];
        Marshal.Copy(outPtr, outArray, 0, outSize);

        Marshal.FreeHGlobal(ptr);
        Marshal.FreeHGlobal(outPtr);
        return outArray;
    }

    public static byte[] Decompress(byte[] array)
    {
        int size = array.Count();
        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.Copy(array, 0, ptr, size);

        int outSize = (int)ZSTD_getDecompressedSize(ptr, (size_t)size);

        IntPtr outPtr = Marshal.AllocHGlobal(outSize);
        ZSTD_decompress(outPtr, (size_t)outSize, ptr, (size_t)size);

        byte[] outArray = new byte[outSize];
        Marshal.Copy(outPtr, outArray, 0, outSize);

        Marshal.FreeHGlobal(ptr);
        Marshal.FreeHGlobal(outPtr);
        return outArray;
    }

}