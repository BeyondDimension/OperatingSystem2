#if NETCOREAPP3_0 || NETCOREAPP3_1
using System.Runtime.InteropServices;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 FreeBSD 上运行。
        /// </summary>
        public static bool IsFreeBSD =>
#if NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsFreeBSD();
#elif NETCOREAPP3_0 || NETCOREAPP3_1
            RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
#else
            false;
#endif

        /// <summary>
        /// 检查 FreeBSD 版本是否大于或等于指定版本。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool IsFreeBSDVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
        {
#if NET5_0 || NET6_0 || NET7_0
            return OperatingSystem.IsFreeBSDVersionAtLeast(major, minor, build, revision);
#elif NETCOREAPP3_0 || NETCOREAPP3_1
            return IsFreeBSD && IsVersionAtLeast(Environment.OSVersion.Version, major, minor, build, revision);
#else
            return false;
#endif
        }
    }
}