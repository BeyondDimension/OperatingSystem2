#if __HAVE_RUNTIME_INFORMATION__
namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Enum 扩展 <see cref="Architecture"/>
    /// </summary>
    public static class ArchitectureEnumExtensions
    {
        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.X86"/> 或 <see cref="Architecture.X64"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsX86OrX64(this Architecture value)
            => value == Architecture.X64 || value == Architecture.X86;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.Arm"/> 或 <see cref="Architecture.Arm64"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsArmOrArm64(this Architecture value)
            => value == Architecture.Arm || value == Architecture.Arm64;

#pragma warning disable CS1574 // XML 注释中有无法解析的 cref 特性

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.Wasm"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWasm(this Architecture value) => (int)value == 4;

        /// <summary>
        /// 处理器体系结构是否为 <see cref="Architecture.S390x"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsS390x(this Architecture value) => (int)value == 5;

#pragma warning restore CS1574 // XML 注释中有无法解析的 cref 特性
    }
}
#endif