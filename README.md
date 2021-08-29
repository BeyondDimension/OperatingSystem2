# OperatingSystem2 [![NuGet version (OperatingSystem2)](https://img.shields.io/nuget/v/OperatingSystem2.svg)](https://www.nuget.org/packages/OperatingSystem2/)

```
OperatingSystem2.IsRunningOnMono // 当前是否使用 Mono 运行时
OperatingSystem2.IsDesktop // 指示当前应用程序是否正在 Desktop 上运行。
OperatingSystem2.IsOnlySupportedStore // 指示当前应用程序是否正在仅支持应用商店的平台上运行。

OperatingSystem2.IsWindows // 指示当前应用程序是否正在 Windows 上运行。
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


// 检查 Windows 版本是否大于或等于指定版本。 此方法可用于保护在指定 Windows 版本中添加的 API。
OperatingSystem2.IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) 

// 检查 macOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 macOS 版本中添加的 API。
OperatingSystem2.IsMacOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 FreeBSD 版本（由 Linux 命令 uname返回）是否大于或等于指定版本。 此方法可用于保护在指定版本中添加的 API。
OperatingSystem2.IsFreeBSDVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)

// 检查 Android 版本是否大于或等于指定版本。 此方法可用于保护在指定版本中添加的 API。
OperatingSystem2.IsAndroidVersionAtLeast(int sdkInt)
OperatingSystem2.IsAndroidVersionAtLeast(BuildVersionCodes sdkInt)
OperatingSystem2.IsAndroidVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)

// 检查 iOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 iOS 版本中添加的 API。
OperatingSystem2.IsIOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 tvOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 tvOS 版本中添加的 API。
OperatingSystem2.IsTvOSVersionAtLeast(int major, int minor = 0, int build = 0)

// 检查 watchOS 版本是否大于或等于指定版本。 此方法可用于保护在指定 watchOS 版本中添加的 API。
OperatingSystem2.IsWatchOSVersionAtLeast(int major, int minor = 0, int build = 0)
```
