﻿#pragma checksum "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "59FD6724259077A635C821058EAB223363BFE0A49ED5F9A116586019C4BDCD7A"
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
    /// KonyvKezelo
    /// </summary>
    public partial class KonyvKezelo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Griddo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetDataKonyvek;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateBook;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBook;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
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
            System.Uri resourceLocater = new System.Uri("/KonyvtarKarbantarto;component/windows/konyv/konyvkezelo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
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
            this.GetDataKonyvek = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
            this.GetDataKonyvek.Click += new System.Windows.RoutedEventHandler(this.GetDataKonyvek_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CreateBook = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
            this.CreateBook.Click += new System.Windows.RoutedEventHandler(this.CreateBook_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditBook = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
            this.EditBook.Click += new System.Windows.RoutedEventHandler(this.EditBook_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Windows\Konyv\KonyvKezelo.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
