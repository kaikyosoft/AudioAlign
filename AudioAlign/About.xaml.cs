﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioAlign {
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window {
        public About() {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            InitializeComponent();

            var assembly = Assembly.GetEntryAssembly();
            var assemblyInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            appName.Text = assemblyInfo.ProductName;
            appVersion.Text = assemblyInfo.ProductVersion + " (" + assemblyInfo.FileVersion + " / " + assembly.GetName().Version + ")";
            appCopyright.Text = assemblyInfo.LegalCopyright;

            licenseTextBox.Text = Aurio.License.Info;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}