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
#if NET5_0
            OperatingSystem.IsLinux();
#elif __HAVE_RUNTIME_INFORMATION__
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#elif NETSTANDARD1_0
            false;
#else
            Environment.OSVersion.Platform == PlatformID.Unix;
#endif
    }
}