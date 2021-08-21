﻿#if !NETFRAMEWORK
#if __ANDROID__
using Android.OS;
#endif
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 Android 上运行。
        /// </summary>
        public static bool IsAndroid =>
#if __ANDROID__
            true;
#elif NET5_0
            OperatingSystem.IsAndroid();
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Platform == DevicePlatform.Android;
#else
            false;
#endif

        /// <summary>
        /// 检查 Android 版本是否大于或等于指定版本。 此方法可用于保护在指定版本中添加的 API。
        /// </summary>
        /// <param name="sdkInt"></param>
        /// <returns></returns>
        public static bool IsAndroidVersionAtLeast(int sdkInt)
        {
#if __ANDROID__
            return (int)Build.VERSION.SdkInt >= sdkInt;
#else
            return false;
#endif
        }

        /// <summary>
        /// 检查 Android 版本是否大于或等于指定版本。 此方法可用于保护在指定版本中添加的 API。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool IsAndroidVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
        {
#if NET5_0
            return OperatingSystem.IsAndroidVersionAtLeast(major, minor, build, revision);
#elif __HAVE_XAMARIN_ESSENTIALS__
            return IsAndroid && IsVersionAtLeast(DeviceInfo.Version, major, minor, build, revision);
#else
            return false;
#endif
        }
    }
}
#endif