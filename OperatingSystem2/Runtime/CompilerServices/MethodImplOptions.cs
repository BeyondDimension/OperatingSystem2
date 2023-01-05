#if NET35 || NET40
using EMethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

static class MethodImplOptions
{
    /// <summary>
    /// The method should be inlined if possible.
    /// </summary>
    public const EMethodImplOptions AggressiveInlining = (EMethodImplOptions)256;
}
#endif