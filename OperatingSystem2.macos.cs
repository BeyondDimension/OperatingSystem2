﻿#if __HAVE_RUNTIME_INFORMATION__
using System.Runtime.InteropServices;
#endif
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 指示当前应用程序是否正在 macOS 上运行。
        /// </summary>
        public static bool IsMacOS =>
#if NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __TVOS__ || __WATCHOS__
            false;
#elif __MACOS__
            true;
#elif NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsMacOS();
#elif __HAVE_RUNTIME_INFORMATION__
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Platform == DevicePlatform.macOS;
#else
            Environment.OSVersion.Platform == PlatformID.MacOSX;
#endif

        /// <summary>
        /// 检查 macOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 macOS 版本中添加的 API。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public static bool IsMacOSVersionAtLeast(int major, int minor = 0, int build = 0)
        {
#if NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __TVOS__ || __WATCHOS__
            return false;
#elif NET5_0 || NET6_0 || NET7_0 || NET6_0_MACOS10_14
            return OperatingSystem.IsMacOSVersionAtLeast(major, minor, build);
#else
            return
#if !__MACOS__
                IsMacOS &&
#endif
                IsVersionAtLeast(
#if __HAVE_XAMARIN_ESSENTIALS__
                    DeviceInfo.Version,
#else
                    Environment.OSVersion.Version,
#endif
                    major, minor, build);
#endif
        }
    }
}