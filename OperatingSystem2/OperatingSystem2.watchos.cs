namespace System;

partial class OperatingSystem2
{
    /// <summary>
    /// 指示当前应用程序是否正在 watchOS 上运行。
    /// </summary>
    [SupportedOSPlatformGuard("watchos")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWatchOS() =>
#if __MACOS__ || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __TVOS__ || __IOS__
        false;
#elif __WATCHOS__
        true;
#elif NET5_0 || NET6_0 || NET7_0
        OperatingSystem.IsWatchOS();
#elif __HAVE_XAMARIN_ESSENTIALS__
        DeviceInfo.Platform == DevicePlatform.watchOS;
#else
        false;
#endif

    /// <summary>
    /// 检查 watchOS 版本是否大于或等于指定版本。
    /// </summary>
    /// <param name="major"></param>
    /// <param name="minor"></param>
    /// <param name="build"></param>
    /// <returns></returns>
    [SupportedOSPlatformGuard("watchos")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWatchOSVersionAtLeast(int major, int minor = 0, int build = 0)
    {
#if __MACOS__ || NET5_0_WINDOWS || NET6_0_WINDOWS || NET7_0_WINDOWS || __ANDROID__ || __TVOS__ || __IOS__
        return false;
#elif NET5_0 || NET6_0 || NET7_0
        return OperatingSystem.IsTvOSVersionAtLeast(major, minor, build);
#elif __HAVE_XAMARIN_ESSENTIALS__
        return
#if !__WATCHOS__
            IsWatchOS() &&
#endif
            IsVersionAtLeast(DeviceInfo.Version, major, minor, build);
#else
        return false;
#endif
    }
}