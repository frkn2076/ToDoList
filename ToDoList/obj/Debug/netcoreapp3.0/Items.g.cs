﻿#pragma checksum "..\..\..\Items.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B254990DC4144ECAE9C6FEF311E37CFB74861AC7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using ToDoList;


namespace ToDoList {
    
    
    /// <summary>
    /// Items
    /// </summary>
    public partial class Items : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ItemsGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameToInsert;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionToInsert;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DeadLineToInsert;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ToDatePicker;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FromDatePicker;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsExpiredCheckBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsCompletedCheckBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Order;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ToDoList;component/items.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Items.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\Items.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackClicked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ItemsGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Items.xaml"
            this.ItemsGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameToInsert = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DescriptionToInsert = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 33 "..\..\..\Items.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddItemClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DeadLineToInsert = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.ToDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.FromDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.IsExpiredCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.IsCompletedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 12:
            
            #line 41 "..\..\..\Items.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FilterClicked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 42 "..\..\..\Items.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveFilterClicked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Order = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\Items.xaml"
            this.Order.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\Items.xaml"
            this.Order.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 25 "..\..\..\Items.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteClicked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

