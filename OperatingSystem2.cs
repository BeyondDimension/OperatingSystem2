#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
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
        /// 当前是否使用 Mono 运行时
        /// </summary>
        public static bool IsRunningOnMono { get; } =
#if __ANDROID__ || __MACOS__ || XAMARIN_IOS || XAMARIN_WATCHOS || XAMARIN_TVOS
            true;
#else
        Type.GetType("Mono.Runtime") != null;
#endif

#if !NETSTANDARD1_0
        static Version OSVersion_() =>
#if NETSTANDARD1_1
            RtlGetVersion();
#else
            Environment.OSVersion.Version;
#endif
        static Version OSVersion =>
#if NET35
            OSVersion_();
#else
            _OSVersion.Value;
        static readonly Lazy<Version> _OSVersion = new Lazy<Version>(OSVersion_);
#endif
#endif

        static bool IsDesktop_()
        {
#if __HAVE_XAMARIN_ESSENTIALS__
            var idiom = DeviceInfo.Idiom;
            if (idiom == DeviceIdiom.Desktop) return true;
            if (idiom == DeviceIdiom.Unknown) return IsDesktop__();
            return false;
#else
            return IsDesktop__();
#endif
        }

        static bool IsDesktop__()
        {
            foreach (var typeName in new[] {
                "Avalonia.Controls.Window, Avalonia.Controls",
                "System.Windows.Forms.Form, System.Windows.Forms",
                "System.Windows.Window, PresentationFramework"})
            {
                if (Type.GetType(typeName) != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 指示当前应用程序是否正在 Desktop 上运行。
        /// </summary>
        public static bool IsDesktop =>
#if NET35
            IsDesktop_();
#else
            _IsDesktop.Value;
        static readonly Lazy<bool> _IsDesktop = new Lazy<bool>(IsDesktop_);
#endif

#if !NETFRAMEWORK
        /// <summary>
        /// 指示当前应用程序是否正在仅支持应用商店的平台上运行。
        /// </summary>
        public static bool IsOnlySupportedStore => IsIOS || IsWatchOS || IsTvOS;
#endif
    }
}