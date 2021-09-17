using System.Runtime.InteropServices;
using System.Text;
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif
#if WINDOWS_UWP
using Windows.System.Profile;
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
#elif NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || WINDOWS_UWP
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
                IsVersionAtLeast(Version, major, minor, build, revision);
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
#elif WINDOWS_UWP
        static readonly Lazy<Version> _WindowsVersion = new(WindowsVersion_);
        static Version WindowsVersion_()
        {
            var sv = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
            var v = ulong.Parse(sv);
            var major = (v & 0xFFFF000000000000L) >> 48;
            var minor = (v & 0x0000FFFF00000000L) >> 32;
            var build = (v & 0x00000000FFFF0000L) >> 16;
            var revision = v & 0x000000000000FFFFL;
            return new Version(
                Convert.ToInt32(major),
                Convert.ToInt32(minor),
                Convert.ToInt32(build),
                Convert.ToInt32(revision));
        }
#endif

#if !(NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__)

        static bool IsWindows10AtLeast_() => IsWindowsVersionAtLeast(10);

        static bool IsWindows11AtLeast_() => IsWindowsVersionAtLeast(10, 0, 22000);
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 7(NT 6.1) 上运行。
        /// </summary>
        public static bool IsWindows7 =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__ || WINDOWS_UWP
            false;
#else
#if !(NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS)
            IsWindows &&
#endif
            _IsWindows7.Value;
        static readonly Lazy<bool> _IsWindows7 = new(IsWindows7_);
        static bool IsWindows7_() => Version.Major == 6 && Version.Minor == 1;
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows Server 上运行。
        /// </summary>
        public static bool IsWindowsServer =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
            _IsWindowsServer.Value;
        static readonly Lazy<bool> _IsWindowsServer = new(IsWindowsServer_);
        const int OS_ANYSERVER = 29;

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        static extern bool IsOS(int os);
        static bool IsWindowsServer_() => IsOS(OS_ANYSERVER);
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 10 或更高版本上运行。
        /// </summary>
        public static bool IsWindows10AtLeast =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
            _IsWindows10AtLeast.Value;
        static readonly Lazy<bool> _IsWindows10AtLeast = new(IsWindows10AtLeast_);
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Windows 11 或更高版本上运行。
        /// </summary>
        public static bool IsWindows11AtLeast =>
#if NETSTANDARD1_0 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
            _IsWindows11AtLeast.Value;
        static readonly Lazy<bool> _IsWindows11AtLeast = new(IsWindows11AtLeast_);
#endif

#if __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__ || WINDOWS_UWP
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
            int versionMajor = Version.Major;
            int versionMinor = Version.Minor;
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
#if WINDOWS_UWP
            true;
#elif __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#else
            _IsRunningAsUwp.Value;
        static readonly Lazy<bool> _IsRunningAsUwp = new(IsRunningAsUwp_);
#endif

#if WINDOWS_UWP
        static readonly Lazy<bool> _IsRunningOnXbox = new(IsRunningOnXbox_);
        static bool IsRunningOnXbox_() => AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox";
#endif

        /// <summary>
        /// 指示当前应用程序是否正在 Xbox 上运行。
        /// </summary>
        public static bool IsRunningOnXbox =>
#if NETSTANDARD1_0 || NETSTANDARD1_1 || __MACOS__ || __ANDROID__ || __IOS__ || __WATCHOS__ || __TVOS__
            false;
#elif WINDOWS_UWP
        _IsRunningOnXbox.Value;
#else
        Environment.OSVersion.Platform == PlatformID.Xbox;
#endif
    }
}