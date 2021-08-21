#if __HAVE_RUNTIME_INFORMATION__
namespace System.Runtime.InteropServices
{
    public static class ArchitectureEnumExtensions
    {
        public static bool IsX86OrX64(this Architecture value)
            => value == Architecture.X64 || value == Architecture.X86;

        public static bool IsArmOrArm64(this Architecture value)
            => value == Architecture.Arm || value == Architecture.Arm64;
    }
}
#endif