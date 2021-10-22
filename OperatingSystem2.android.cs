#if __ANDROID__
using Android.OS;
using Java.Lang;
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
#elif NET5_0 || NET6_0 || NET7_0
            OperatingSystem.IsAndroid();
#elif __HAVE_XAMARIN_ESSENTIALS__
            DeviceInfo.Platform == DevicePlatform.Android;
#else
            false;
#endif

#if __ANDROID__
        static readonly Lazy<bool> _IsRunningOnWSA = new(() =>
        {
            string? model = Build.Model, manufacturer = Build.Manufacturer,
                brand = Build.Brand, device = Build.Device,
                product = Build.Product, hardware = Build.Hardware;
            if (model != "Subsystem for Android(TM)") return false;
            if (manufacturer != "Microsoft Corporation") return false;
            if (brand != "Windows") return false;
            if (device == null || !device.Contains("windows")) return false;
            if (product == null || !product.Contains("windows") != true) return false;
            if (hardware == null || !hardware.Contains("windows") != true) return false;
            var osVer = JavaSystem.GetProperty("os.version");
            if (osVer == null || !osVer.Contains("windows-subsystem-for-android")) return false;
            return true;
        });
#endif
        /// <summary>
        /// 指示当前应用程序是否正在 Windows Subsystem for Android™️ 上运行。
        /// </summary>
        public static bool IsRunningOnWSA =>
#if __ANDROID__
            _IsRunningOnWSA.Value;
#else
            false;
#endif

        /// <summary>
        /// 检查 Android 版本是否大于或等于指定版本。
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

#if __ANDROID__
        /// <summary>
        /// 检查 Android 版本是否大于或等于指定版本。
        /// </summary>
        /// <param name="sdkInt"></param>
        /// <returns></returns>
        public static bool IsAndroidVersionAtLeast(BuildVersionCodes sdkInt)
        {
            return Build.VERSION.SdkInt >= sdkInt;
        }
#endif

        /// <summary>
        /// 检查 Android 版本是否大于或等于指定版本。
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool IsAndroidVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
        {
#if NET5_0 || NET6_0 || NET7_0
            return OperatingSystem.IsAndroidVersionAtLeast(major, minor, build, revision);
#elif __HAVE_XAMARIN_ESSENTIALS__
            return
#if !__ANDROID__
                IsAndroid &&
#endif
                IsVersionAtLeast(DeviceInfo.Version, major, minor, build, revision);
#else
            return false;
#endif
        }
    }
}