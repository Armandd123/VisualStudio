﻿using System.Windows;
using System.Windows.Controls;
using GitHub.VisualStudio.TeamExplorerHome;
using GitHub.UI.Helpers;
using NullGuard;

namespace GitHub.VisualStudio.UI.Views
{
    /// <summary>
    /// Interaction logic for GitHubHomeSection.xaml
    /// </summary>
    public partial class GitHubInvitationContent : UserControl
    {
        public GitHubInvitationContent()
        {
            SharedDictionaryManager.Load("GitHub.VisualStudio");
            SharedDictionaryManager.Load("GitHub.UI");
            InitializeComponent();

            DataContextChanged += (s, e) => ViewModel = e.NewValue as IGitHubInvitationSection;
        }

        [AllowNull]
        public IGitHubInvitationSection ViewModel
        {
            [return: AllowNull]
            get { return GetValue(ViewModelProperty) as IGitHubInvitationSection; }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(
                "ViewModel",
                typeof(IGitHubInvitationSection),
                typeof(GitHubInvitationContent));

        void connect_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Connect();
        }

        void signup_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SignUp();
        }
    }
}
