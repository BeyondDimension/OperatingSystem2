#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 tvOS 上运行。
        /// </summary>
        public static bool IsTvOS =>
#if __MACOS__ || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __IOS__ || __WATCHOS__
            false;
#elif __TVOS__
            true;
#elif NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsTvOS();
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Platform == DevicePlatform.tvOS;
#else
            false;
#endif

        /// <summary>
        /// 检查 tvOS 版本是否大于或等于指定版本。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public static bool IsTvOSVersionAtLeast(int major, int minor = 0, int build = 0)
        {
#if __MACOS__ || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __IOS__ || __WATCHOS__
            return false;
#elif NET5_0 || NET6_0 || NET7_0
            return OperatingSystem.IsTvOSVersionAtLeast(major, minor, build);
#elif __HAVE_XAMARIN_ESSENTIALS__
            return
#if !__TVOS__
                IsTvOS &&
#endif
                IsVersionAtLeast(DeviceInfo.Version, major, minor, build);
#else
            return false;
#endif
        }
    }
}