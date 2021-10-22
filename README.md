# OperatingSystem2 [![NuGet version (OperatingSystem2)](https://img.shields.io/nuget/v/OperatingSystem2.svg)](https://www.nuget.org/packages/OperatingSystem2/)

```
OperatingSystem2.Version // 获取当前系统版本号。

OperatingSystem2.IsRunningOnMono // 当前是否使用 Mono 运行时。
OperatingSystem2.IsDesktop // 指示当前应用程序是否正在 Desktop 上运行。
OperatingSystem2.IsOnlySupportedStore // 指示当前应用程序是否正在仅支持应用商店的平台上运行。
OperatingSystem2.IsRunningAsUwp // 指示当前应用程序是否正在 UWP 上运行。
OperatingSystem2.IsRunningOnXbox // 指示当前应用程序是否正在 Xbox 上运行。
OperatingSystem2.IsRunningOnWSA // 指示当前应用程序是否正在 Windows Subsystem for Android™️ 上运行。

OperatingSystem2.IsWindows // 指示当前应用程序是否正在 Windows 上运行。
OperatingSystem2.IsWindowsServer // 指示当前应用程序是否正在 Windows Server 上运行。
OperatingSystem2.IsWindows7 // 指示当前应用程序是否正在 Windows 7 上运行。
OperatingSystem2.IsWindows10AtLeast // 指示当前应用程序是否正在 Windows 10 或更高版本上运行。
OperatingSystem2.IsWindows11AtLeast // 指示当前应用程序是否正在 Windows 11 或更高版本上运行。
OperatingSystem2.IsLinux // 指示当前应用程序是否正在 Linux 上运行。
OperatingSystem2.IsMacOS // 指示当前应用程序是否正在 macOS 上运行。
OperatingSystem2.IsFreeBSD // 指示当前应用程序是否正在 FreeBSD 上运行。
OperatingSystem2.IsAndroid // 指示当前应用程序是否正在 Android 上运行。
OperatingSystem2.IsIOS // 指示当前应用程序是否正在 iOS 上运行。
OperatingSystem2.IsTvOS // 指示当前应用程序是否正在 tvOS 上运行。
OperatingSystem2.IsWatchOS // 指示当前应用程序是否正在 watchOS 上运行。
OperatingSystem2.IsBrowser // 指示当前应用程序是否在浏览器中作为 WASM 运行。


// 检查 Windows 版本是否大于或等于指定版本。
OperatingSystem2.IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) 

// 检查 macOS 版本是否大于或等于指定版本。
OperatingSystem2.IsMacOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 FreeBSD 版本是否大于或等于指定版本。
OperatingSystem2.IsFreeBSDVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)

// 检查 Android 版本是否大于或等于指定版本。
OperatingSystem2.IsAndroidVersionAtLeast(int sdkInt)
OperatingSystem2.IsAndroidVersionAtLeast(BuildVersionCodes sdkInt)
OperatingSystem2.IsAndroidVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)

// 检查 iOS 版本是否大于或等于指定版本。
OperatingSystem2.IsIOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 tvOS 版本是否大于或等于指定版本。
OperatingSystem2.IsTvOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 watchOS 版本是否大于或等于指定版本。
OperatingSystem2.IsWatchOSVersionAtLeast(int major, int minor = 0, int build = 0)

// ----------------------------------------

using System.Runtime.InteropServices;

// 正在其上运行当前应用的平台体系结构为 X86 或 X64
bool RuntimeInformation.OSArchitecture.IsX86OrX64()

// 当前正在运行的应用的进程架构为 X86 或 X64
bool RuntimeInformation.ProcessArchitecture.IsX86OrX64()

bool IsArmOrArm64();
bool IsWasm();
bool IsS390x();

// ----------------------------------------

bool OperatingSystem2.Application.UseAvalonia
bool OperatingSystem2.Application.UseXamarinForms
bool OperatingSystem2.Application.UseMaui
bool OperatingSystem2.Application.UseWindowsForms
bool OperatingSystem2.Application.UseWPF
bool OperatingSystem2.Application.UseUno
```
