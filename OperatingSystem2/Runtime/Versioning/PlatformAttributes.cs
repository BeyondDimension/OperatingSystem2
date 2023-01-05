// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/buyaa-n/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Runtime/Versioning/PlatformAttributes.cs

namespace System.Runtime.Versioning
{
#if !(NET6_0 || NET6_0_ANDROID || NET6_0_IOS || NET6_0_MACCATALYST || NET6_0_MACOS10_14 || NET6_0_WINDOWS || NET7_0 || NET7_0_ANDROID || NET7_0_IOS || NET7_0_MACCATALYST || NET7_0_MACOS10_14 || NET7_0_WINDOWS)
    abstract class OSPlatformAttribute : Attribute
    {
        private protected OSPlatformAttribute(string platformName)
        {
            PlatformName = platformName;
        }

        public string PlatformName { get; }
    }

    /// <summary>
    /// Annotates a custom guard field, property or method with a supported platform name and optional version.
    /// Multiple attributes can be applied to indicate guard for multiple supported platforms.
    /// </summary>
    /// <remarks>
    /// Callers can apply a <see cref="System.Runtime.Versioning.SupportedOSPlatformGuardAttribute " /> to a field, property or method
    /// and use that field, property or method in a conditional or assert statements in order to safely call platform specific APIs.
    ///
    /// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property,
                    AllowMultiple = true, Inherited = false)]
    sealed class SupportedOSPlatformGuardAttribute : OSPlatformAttribute
    {
        public SupportedOSPlatformGuardAttribute(string platformName) : base(platformName)
        {
        }
    }

    ///// <summary>
    ///// Annotates the custom guard field, property or method with an unsupported platform name and optional version.
    ///// Multiple attributes can be applied to indicate guard for multiple unsupported platforms.
    ///// </summary>
    ///// <remarks>
    ///// Callers can apply a <see cref="System.Runtime.Versioning.UnsupportedOSPlatformGuardAttribute " /> to a field, property or method
    ///// and use that  field, property or method in a conditional or assert statements as a guard to safely call APIs unsupported on those platforms.
    /////
    ///// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
    ///// </remarks>
    //[AttributeUsage(AttributeTargets.Field |
    //                AttributeTargets.Method |
    //                AttributeTargets.Property,
    //                AllowMultiple = true, Inherited = false)]
    //sealed class UnsupportedOSPlatformGuardAttribute : OSPlatformAttribute
    //{
    //    public UnsupportedOSPlatformGuardAttribute(string platformName) : base(platformName)
    //    {
    //    }
    //}
#endif
}
