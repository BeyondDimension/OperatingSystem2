#if __HAVE_RUNTIME_INFORMATION__
using System.Runtime.InteropServices;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 Windows 上运行。
        /// </summary>
        public static bool IsWindows =>
#if NET5_0
            OperatingSystem.IsWindows();
#elif __HAVE_RUNTIME_INFORMATION__
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#elif NETSTANDARD1_0
            false;
#else
            Environment.OSVersion.Platform == PlatformID.Win32NT;
#endif

        /// <summary>
        /// 检查 Windows 版本是否大于或等于指定版本。 此方法可用于保护在指定 Windows 版本中添加的 API。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
        {
#if NET5_0
            return OperatingSystem.IsWindowsVersionAtLeast(major, minor, build, revision);
#elif NETSTANDARD1_0
            return false;
#else
            return IsWindows && IsVersionAtLeast(OSVersion, major, minor, build, revision);
#endif
        }

#if NETSTANDARD1_1
        [StructLayout(LayoutKind.Sequential)]
        struct RTL_OSVERSIONINFOEX
        {
            internal uint dwOSVersionInfoSize;
            internal uint dwMajorVersion;
            internal uint dwMinorVersion;
            internal uint dwBuildNumber;
            internal uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string szCSDVersion;
        }

        [DllImport("ntdll")]
        static extern int RtlGetVersion(ref RTL_OSVERSIONINFOEX lpVersionInformation);

        static Version RtlGetVersion()
        {
            RTL_OSVERSIONINFOEX v = new RTL_OSVERSIONINFOEX();
            v.dwOSVersionInfoSize = (uint)Marshal.SizeOf(v);
            if (RtlGetVersion(ref v) == 0)
            {
                return new Version((int)v.dwMajorVersion, (int)v.dwMinorVersion, (int)v.dwBuildNumber);
            }
            else
            {
                throw new Exception("RtlGetVersion failed!");
            }
        }
#endif

#if !NETSTANDARD1_0
        static bool IsWindows7_() => OSVersion.Major == 6 && OSVersion.Minor == 1;

        static bool IsWindows10AtLeast_() => IsWindowsVersionAtLeast(10);

        static bool IsWindows11AtLeast_() => IsWindowsVersionAtLeast(10, 0, 22000);
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 7 上运行。
        /// </summary>
        public static bool IsWindows7 =>
#if NETSTANDARD1_0
            false;
#else
            IsWindows &&
#if NET35
            IsWindows7_();
#else
            _IsWindows7.Value;
        static readonly Lazy<bool> _IsWindows7 = new Lazy<bool>(IsWindows7_);
#endif
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 10 或更高版本上运行。
        /// </summary>
        public static bool IsWindows10AtLeast =>
#if NETSTANDARD1_0
            false;
#else
            IsWindows &&
#if NET35
            IsWindows10AtLeast_();
#else
            _IsWindows10AtLeast.Value;
        static readonly Lazy<bool> _IsWindows10AtLeast = new Lazy<bool>(IsWindows10AtLeast_);
#endif
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 11 或更高版本上运行。
        /// </summary>
        public static bool IsWindows11AtLeast =>
#if NETSTANDARD1_0
            false;
#else
            IsWindows &&
#if NET35
            IsWindows11AtLeast_();
#else
            _IsWindows11AtLeast.Value;
        static readonly Lazy<bool> _IsWindows11AtLeast = new Lazy<bool>(IsWindows11AtLeast_);
#endif
#endif
    }
}