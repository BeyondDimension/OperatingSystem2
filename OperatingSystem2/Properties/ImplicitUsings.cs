#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable SA1211 // Using alias directives should be ordered alphabetically by alias name
global using System.Linq;
global using System.Text;
global using System.Reflection;
global using System.Collections.Generic;
global using System.Runtime.Versioning;
//#if __HAVE_RUNTIME_INFORMATION__ || NETCOREAPP3_0 || NETCOREAPP3_1
global using System.Runtime.InteropServices;
//#endif
global using System.Runtime.CompilerServices;
#if __ANDROID__
global using Android.OS;
global using Java.Lang;
#endif
#if __HAVE_XAMARIN_ESSENTIALS__
global using Xamarin.Essentials;
#endif
#if WINDOWS_UWP
global using Windows.System.Profile;
#endif