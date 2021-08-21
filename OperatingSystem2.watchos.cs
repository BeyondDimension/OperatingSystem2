#if !NETFRAMEWORK
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 watchOS 上运行。
        /// </summary>
        public static bool IsWatchOS =>
#if __WATCHOS__
            true;
#elif NET5_0
            OperatingSystem.IsWatchOS();
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Platform == DevicePlatform.watchOS;
#else
            false;
#endif

        /// <summary>
        /// 检查 watchOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 watchOS 版本中添加的 API。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public static bool IsWatchOSVersionAtLeast(int major, int minor = 0, int build = 0)
        {
#if NET5_0
            return OperatingSystem.IsTvOSVersionAtLeast(major, minor, build);
#elif __HAVE_XAMARIN_ESSENTIALS__
            return IsWatchOS && IsVersionAtLeast(DeviceInfo.Version, major, minor, build);
#else
            return false;
#endif
        }
    }
}
#endif