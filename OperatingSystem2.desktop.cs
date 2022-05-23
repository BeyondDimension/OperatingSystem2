using System.Reflection;
#if __HAVE_XAMARIN_ESSENTIALS__
using Xamarin.Essentials;
#endif
#if WINDOWS_UWP
using Windows.System.Profile;
#endif
using System.Runtime.CompilerServices;

namespace System
{
    partial class OperatingSystem2
    {
#if !WINDOWS_UWP && !(NETSTANDARD1_0 || NETSTANDARD1_1 || NET35 || NET40 || NET45)
        static byte isAvaloniaDesktop;
#endif
        static EDesktopType GetDesktopType()
        {
#if WINDOWS_UWP
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
                return EDesktopType.WindowsDesktop;
#else
#if __HAVE_XAMARIN_ESSENTIALS__
            var idiom = DeviceInfo.Idiom;
            if (idiom == DeviceIdiom.Desktop) return EDesktopType.DeviceIdiomDesktop;
            if (idiom != DeviceIdiom.Unknown) return EDesktopType.Unknown;
#endif
            if (Application.UseWindowsForms() || Application.UseWPF())
            {
                return EDesktopType.WinFormsOrWPF;
            }
#if !(NETSTANDARD1_0 || NETSTANDARD1_1 || NET35 || NET40 || NET45)
            else if (Application.UseAvalonia())
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
                if (isAvaloniaDesktop == 1)
                {
                    return EDesktopType.AvaloniaDesktop;
                }
            }
#endif
#endif
            return EDesktopType.Unknown;
        }

        /// <summary>
        /// 指示当前应用程序是否正在 Desktop 上运行。
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDesktop() => DesktopType != EDesktopType.Unknown;

        /// <summary>
        /// 
        /// </summary>
        public static EDesktopType DesktopType =>
            _DesktopType.Value;
        static readonly Lazy<EDesktopType> _DesktopType = new(GetDesktopType);

        /// <summary>
        /// 
        /// </summary>
        public enum EDesktopType
        {
            /// <summary>
            /// 
            /// </summary>
            Unknown,

            /// <summary>
            /// UWP(Windows.Desktop)
            /// </summary>
            WindowsDesktop,

            /// <summary>
            /// 
            /// </summary>
            WinFormsOrWPF,

            /// <summary>
            /// 
            /// </summary>
            AvaloniaDesktop,

            /// <summary>
            /// 
            /// </summary>
            DeviceIdiomDesktop,
        }
    }
}
