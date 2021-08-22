#if __HAVE_RUNTIME_INFORMATION__
using System.Runtime.InteropServices;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 Linux 上运行。
        /// </summary>
        public static bool IsLinux =>
#if NETSTANDARD1_0 || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __MACOS__
            false;
#elif NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsLinux();
#elif __HAVE_RUNTIME_INFORMATION__
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#else
        Environment.OSVersion.Platform == PlatformID.Unix;
#endif
    }
}