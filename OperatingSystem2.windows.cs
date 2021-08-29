using System.Runtime.InteropServices;
using System.Text;
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 Windows 上运行。
        /// </summary>
        public static bool IsWindows =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#elif NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS
            true;
#elif NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsWindows();
#elif __HAVE_RUNTIME_INFORMATION__
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#else
        Environment.OSVersion.Platform == PlatformID.Win32NT;
#endif

        /// <summary>
        /// 检查 Windows 版本是否大于或等于指定版本。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
        {
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            return false;
#elif NET5_0 || NET6_0 || NET7_0 || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS
            return OperatingSystem.IsWindowsVersionAtLeast(major, minor, build, revision);
#else
            return
#if !(NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS)
                IsWindows &&
#endif
                IsVersionAtLeast(WindowsVersion, major, minor, build, revision);
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

        static readonly Lazy<Version> _WindowsVersion = new(RtlGetVersion);
#endif

#if !NETSTANDARD1_0
        static Version WindowsVersion =>
#if NETSTANDARD1_1
            _WindowsVersion.Value;
#else
            Environment.OSVersion.Version;
#endif
#endif

#if !(NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__)
        static bool IsWindows7_() => WindowsVersion.Major == 6 && WindowsVersion.Minor == 1;

        static bool IsWindows10AtLeast_() => IsWindowsVersionAtLeast(10);

        static bool IsWindows11AtLeast_() => IsWindowsVersionAtLeast(10, 0, 22000);
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 7 上运行。
        /// </summary>
        public static bool IsWindows7 =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
#if !(NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS)
            IsWindows &&
#endif
#if NET35
            IsWindows7_();
#else
            _IsWindows7.Value;
        static readonly Lazy<bool> _IsWindows7 = new(IsWindows7_);
#endif
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 10 或更高版本上运行。
        /// </summary>
        public static bool IsWindows10AtLeast =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
#if NET35
            IsWindows10AtLeast_();
#else
            _IsWindows10AtLeast.Value;
        static readonly Lazy<bool> _IsWindows10AtLeast = new(IsWindows10AtLeast_);
#endif
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 11 或更高版本上运行。
        /// </summary>
        public static bool IsWindows11AtLeast =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
#if NET35
            IsWindows11AtLeast_();
#else
            _IsWindows11AtLeast.Value;
        static readonly Lazy<bool> _IsWindows11AtLeast = new(IsWindows11AtLeast_);
#endif
#endif

#if __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
#else
#if !NETSTANDARD1_0
        // https://github.com/qmatteoq/DesktopBridgeHelpers/blob/master/DesktopBridge.Helpers/Helpers.cs

        const long APPMODEL_ERROR_NO_PACKAGE = 15700L;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder packageFullName);
#endif
        static bool IsRunningAsUwp_()
        {
#if __HAVE_XAMARIN_ESSENTIALS__
            if (DeviceInfo.Platform == DevicePlatform.UWP)
            {
                return true;
            }
#endif
#if !NETSTANDARD1_0
            int versionMajor = WindowsVersion.Major;
            int versionMinor = WindowsVersion.Minor;
            double version = versionMajor + (double)versionMinor / 10;
            if (version <= 6.1)
            {
                return false;
            }
            else
            {
                int length = 0;
                StringBuilder sb = new StringBuilder(0);
                int result = GetCurrentPackageFullName(ref length, sb);

                sb = new StringBuilder(length);
                result = GetCurrentPackageFullName(ref length, sb);

                return result != APPMODEL_ERROR_NO_PACKAGE;
            }
#else
            return false;
#endif
        }
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 UWP 上运行。
        /// </summary>
        public static bool IsRunningAsUwp =>
#if __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
#if NET35
            IsRunningAsUwp_();
#else
            _IsRunningAsUwp.Value;
        static readonly Lazy<bool> _IsRunningAsUwp = new(IsRunningAsUwp_);
#endif
#endif
    }
}