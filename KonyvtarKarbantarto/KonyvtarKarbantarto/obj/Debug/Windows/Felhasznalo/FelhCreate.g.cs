﻿#pragma checksum "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C65D8D2A02C80305DAF0B986DACB658AF4F3C37AD9D6A84AC51D439F2B15CB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KonyvtarKarbantarto.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KonyvtarKarbantarto.Windows {
    
    
    /// <summary>
    /// FelhCreate
    /// </summary>
    public partial class FelhCreate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email_Adress;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Register;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReadFromFile;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KonyvtarKarbantarto;component/windows/felhasznalo/felhcreate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Email_Adress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Register = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
            this.Register.Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ReadFromFile = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\Felhasznalo\FelhCreate.xaml"
            this.ReadFromFile.Click += new System.Windows.RoutedEventHandler(this.ReadFromFile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

