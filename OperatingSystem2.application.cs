using System.Collections.Generic;
using System.Linq;

namespace System
{
    partial class OperatingSystem2
    {
        /// <summary>
        /// 
        /// </summary>
        public static class Application
        {
            /// <summary>
            /// Application TypeNames
            /// </summary>
            public static class TypeNames
            {
                /// <summary>
                /// https://github.com/AvaloniaUI/Avalonia
                /// </summary>
                public const string Avalonia = "Avalonia.Application, Avalonia.Controls";

                /// <summary>
                /// https://github.com/xamarin/Xamarin.Forms
                /// </summary>
                public const string XamarinForms = "Xamarin.Forms.Application, Xamarin.Forms.Core";

                /// <summary>
                /// https://github.com/dotnet/maui
                /// </summary>
                public const string Maui = "Microsoft.Maui.Controls.Application, Microsoft.Maui.Controls";

                /// <summary>
                /// https://github.com/dotnet/winforms
                /// <para></para>
                /// https://github.com/mono/winforms
                /// </summary>
                public const string WindowsForms = "System.Windows.Forms.Application, System.Windows.Forms";

                /// <summary>
                /// https://github.com/dotnet/wpf
                /// </summary>
                public const string WPF = "System.Windows.Application, PresentationFramework";

                ///// <summary>
                ///// https://github.com/microsoft/microsoft-ui-xaml
                ///// </summary>
                //public const string UWP = "Windows.UI.Xaml.Application, Windows.Foundation.UniversalApiContract";

                /// <summary>
                /// https://github.com/unoplatform/uno
                /// </summary>
                public const string Uno = "Windows.UI.Xaml.Application, Uno.UI";
            }

            /// <summary>
            /// Application Types
            /// </summary>
            public static class Types
            {
                static readonly Dictionary<string, Lazy<Type?>> _ApplicationTypes = new[]
                {
                    TypeNames.Avalonia,
                    TypeNames.XamarinForms,
                    TypeNames.Maui,
                    TypeNames.WindowsForms,
                    TypeNames.WPF,
                }.ToDictionary(k => k, v => new Lazy<Type?>(() => Type.GetType(v)));

                /// <inheritdoc cref="TypeNames.Avalonia"/>
                public static Type? Avalonia => _ApplicationTypes[TypeNames.Avalonia].Value;

                /// <inheritdoc cref="TypeNames.XamarinForms"/>
                public static Type? XamarinForms => _ApplicationTypes[TypeNames.XamarinForms].Value;

                /// <inheritdoc cref="TypeNames.Maui"/>
                public static Type? Maui => _ApplicationTypes[TypeNames.Maui].Value;

                /// <inheritdoc cref="TypeNames.WindowsForms"/>
                public static Type? WindowsForms => _ApplicationTypes[TypeNames.WindowsForms].Value;

                /// <inheritdoc cref="TypeNames.WPF"/>
                public static Type? WPF => _ApplicationTypes[TypeNames.WPF].Value;

                /// <inheritdoc cref="TypeNames.Uno"/>
                public static Type? Uno => _ApplicationTypes[TypeNames.Uno].Value;
            }

            /// <inheritdoc cref="TypeNames.Avalonia"/>
            public static bool UseAvalonia => Types.Avalonia != null;

            /// <inheritdoc cref="TypeNames.XamarinForms"/>
            public static bool UseXamarinForms => Types.XamarinForms != null;

            /// <inheritdoc cref="TypeNames.Maui"/>
            public static bool UseMaui => Types.Maui != null;

            /// <inheritdoc cref="TypeNames.WindowsForms"/>
            public static bool UseWindowsForms => Types.WindowsForms != null;

            /// <inheritdoc cref="TypeNames.WPF"/>
            public static bool UseWPF => Types.WPF != null;

            /// <inheritdoc cref="TypeNames.Uno"/>
            public static bool UseUno => Types.Uno != null;
        }
    }
}
