﻿#pragma checksum "..\..\..\Pages\FileListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5350C81D37189D08E7B4F2090CC07A61A73E2E6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RMP.Pages;
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


namespace RMP.Pages {
    
    
    /// <summary>
    /// FileListPage
    /// </summary>
    public partial class FileListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\Pages\FileListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvImages;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\FileListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvVideos;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Pages\FileListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvMusic;
        
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
            System.Uri resourceLocater = new System.Uri("/RMP;component/pages/filelistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\FileListPage.xaml"
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
            this.lvImages = ((System.Windows.Controls.ListView)(target));
            
            #line 45 "..\..\..\Pages\FileListPage.xaml"
            this.lvImages.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvImages_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lvVideos = ((System.Windows.Controls.ListView)(target));
            
            #line 68 "..\..\..\Pages\FileListPage.xaml"
            this.lvVideos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvVideos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lvMusic = ((System.Windows.Controls.ListView)(target));
            
            #line 89 "..\..\..\Pages\FileListPage.xaml"
            this.lvMusic.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvVideos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

