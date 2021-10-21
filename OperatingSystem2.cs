using System.Reflection;
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif
#if WINDOWS_UWP
using Windows.System.Profile;
#endif

namespace System
{
    /// <summary>
    /// 表示有关操作系统的信息，如版本和平台标识符。
    /// </summary>
    public static partial class OperatingSystem2
    {
#if __HAVE_XAMARIN_ESSENTIALS__ || (!NET5_0 && !NET6_0 && !NET7_0)
        static int GetInt32(int value) => value < 0 ? 0 : value;

        static bool IsVersionAtLeast(int major_left, int minor_left, int build_left, int revision_left, int major_right, int minor_right, int build_right, int revision_right)
        {
            if (major_left > major_right) return true;
            if (major_left < major_right) return false;

            if (minor_left > minor_right) return true;
            if (minor_left < minor_right) return false;

            if (build_left > build_right) return true;
            if (build_left < build_right) return false;

            if (revision_left > revision_right) return true;
            if (revision_left < revision_right) return false;

            return true;
        }

        static bool IsVersionAtLeast(Version version_left, int major_right = 0, int minor_right = 0, int build_right = 0, int revision_right = 0)
        {
            var major_left = version_left.Minor;
            var minor_left = GetInt32(version_left.Minor);
            var build_left = GetInt32(version_left.Build);
            var revision_left = GetInt32(version_left.Revision);

            return IsVersionAtLeast(major_left, minor_left, build_left, revision_left
                , major_right, minor_right, build_right, revision_right);
        }
#endif

        /// <summary>
        /// 当前是否使用 Mono 运行时。
        /// </summary>
        public static bool IsRunningOnMono { get; } =
#if __XAMARIN_ANDROID_v1_0__ || XAMARIN_MAC || XAMARIN_IOS || XAMARIN_WATCHOS || XAMARIN_TVOS
            true;
#else
        Type.GetType("Mono.Runtime") != null;
#endif

#if !WINDOWS_UWP && !(NETSTANDARD1_0 || NETSTANDARD1_1 || NET35 || NET40)
        static byte isAvaloniaDesktop;
#endif
        static bool IsDesktop_()
        {
#if WINDOWS_UWP
            return AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop";
#else
#if __HAVE_XAMARIN_ESSENTIALS__
            var idiom = DeviceInfo.Idiom;
            if (idiom == DeviceIdiom.Desktop) return true;
            if (idiom != DeviceIdiom.Unknown) return false;
#endif
            if (Application.UseWindowsForms || Application.UseWPF)
            {
                return true;
            }
#if !(NETSTANDARD1_0 || NETSTANDARD1_1 || NET35 || NET40)
            else if (Application.UseAvalonia)
            {
                if (isAvaloniaDesktop == 0)
                {
                    try
                    {
                        var currentAvaloniaApplication = Application.Types.Avalonia!.GetProperty("Current", BindingFlags.Static | BindingFlags.Public)?.GetValue(null);
                        if (currentAvaloniaApplication != null)
                        {
                            var applicationLifetime = Application.Types.Avalonia.GetProperty("ApplicationLifetime", BindingFlags.Instance | BindingFlags.Public)?.GetValue(currentAvaloniaApplication);
                            if (applicationLifetime != null)
                            {
                                if (applicationLifetime.GetType().ToString().Contains("Desktop"))
                                {
                                    isAvaloniaDesktop = 1;
                                }
                            }
                        }
                    }
                    catch
                    {
                        isAvaloniaDesktop = 2;
                    }
                }
                return isAvaloniaDesktop == 1;
            }
#endif
            return false;
#endif
        }

        /// <summary>
        /// 指示当前应用程序是否正在 Desktop 上运行。
        /// </summary>
        public static bool IsDesktop =>
            _IsDesktop.Value;
        static readonly Lazy<bool> _IsDesktop = new(IsDesktop_);

        /// <summary>
        /// 指示当前应用程序是否正在仅支持应用商店的平台上运行。
        /// </summary>
        public static bool IsOnlySupportedStore =>
#if NETFRAMEWORK || __MACOS__ || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__
            false;
#else
            IsIOS || IsWatchOS || IsTvOS;
#endif

        /// <summary>
        /// 获取当前系统版本号。
        /// </summary>
        public static Version Version =>
#if NETSTANDARD1_0
            throw new PlatformNotSupportedException();
#elif NETSTANDARD1_1 || WINDOWS_UWP
            _WindowsVersion.Value;
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Version;
#else
            Environment.OSVersion.Version;
#endif
    }
}