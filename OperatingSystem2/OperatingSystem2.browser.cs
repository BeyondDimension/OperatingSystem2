namespace System;

partial class OperatingSystem2
{
    /// <summary>
    /// 指示当前应用程序是否在浏览器中作为 WASM 运行。
    /// </summary>
    [SupportedOSPlatformGuard("browser")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBrowser() =>
#if NET5_0 || NET6_0 || NET7_0
        OperatingSystem.IsBrowser();
#elif __HAVE_RUNTIME_INFORMATION__
        RuntimeInformation.ProcessArchitecture.IsWasm();
#else
        false;
#endif
}