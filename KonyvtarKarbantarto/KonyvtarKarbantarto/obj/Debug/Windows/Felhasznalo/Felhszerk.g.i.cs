﻿#pragma checksum "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1B0DBF2D681279344E7EE8D974C1495E48CF9747897044A0D03D8F4F3438E09F"
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
    /// Felhszerk
    /// </summary>
    public partial class Felhszerk : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Griddo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetData;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Write;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Create;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
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
            System.Uri resourceLocater = new System.Uri("/KonyvtarKarbantarto;component/windows/felhasznalo/felhszerk.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
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
            this.Griddo = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.GetData = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
            this.GetData.Click += new System.Windows.RoutedEventHandler(this.GetData_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Write = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
            this.Write.Click += new System.Windows.RoutedEventHandler(this.Write_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Create = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
            this.Create.Click += new System.Windows.RoutedEventHandler(this.Create_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Windows\Felhasznalo\Felhszerk.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

