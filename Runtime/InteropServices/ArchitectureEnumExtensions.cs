using System.Runtime.CompilerServices;

#if __HAVE_RUNTIME_INFORMATION__
namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Enum 扩展 <see cref="Architecture"/>
    /// </summary>
    public static class ArchitectureEnumExtensions
    {
        /// <summary>
        /// The WebAssembly platform.
        /// </summary>
        public const Architecture Architecture_Wasm =
#if NET5_0 || NET6_0 || NET5_0_WINDOWS || NET6_0_WINDOWS || NET6_0_MACOS10_14
        Architecture.Wasm;
#else
        (Architecture)4;
#endif

        /// <summary>
        /// The S390x platform architecture.
        /// </summary>
        public const Architecture Architecture_S390x =
#if NET6_0 || NET6_0_WINDOWS || NET6_0_MACOS10_14
        Architecture.S390x;
#else
        (Architecture)5;
#endif

        /// <summary>
        /// 
        /// </summary>
        public const Architecture Architecture_LoongArch64 =
#if NET7_0 || NET7_0_WINDOWS || NET7_0_MACOS10_14
        Architecture.LoongArch64;
#else
        (Architecture)6;
#endif

        /// <summary>
        /// 
        /// </summary>
        public const Architecture Architecture_Armv6 =
#if NET7_0 || NET7_0_WINDOWS || NET7_0_MACOS10_14
        Architecture.Armv6;
#else
        (Architecture)7;
#endif

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.X86"/> 或 <see cref="Architecture.X64"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsX86OrX64(this Architecture value)
            => value == Architecture.X64 || value == Architecture.X86;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.Arm"/> 或 <see cref="Architecture.Arm64"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsArmOrArm64(this Architecture value)
            => value == Architecture.Arm || value == Architecture.Arm64;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.Arm"/> 或 <see cref="Architecture.Arm64"/> 或 <see cref="Architecture_Armv6"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsArmOrArm64OrArmv6(this Architecture value)
            => value == Architecture.Arm || value == Architecture.Arm64 || value == Architecture_Armv6;

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable CS1574 // XML 注释中有无法解析的 cref 特性

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture_Wasm"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWasm(this Architecture value) => value == Architecture_Wasm;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture_S390x"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsS390x(this Architecture value) => value == Architecture_S390x;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture_LoongArch64"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLoongArch64(this Architecture value) => value == Architecture_LoongArch64;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.Armv6"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsArmv6(this Architecture value) => value == Architecture_Armv6;

#pragma warning restore CS1574 // XML 注释中有无法解析的 cref 特性
#pragma warning restore IDE0079 // 请删除不必要的忽略
    }
}
#endif