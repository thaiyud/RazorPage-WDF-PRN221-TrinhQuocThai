using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Candidate_Service.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Candidate_GUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService _hrAccountService;
        public MainWindow()
        {
            InitializeComponent();
            _hrAccountService = new HRAccountService();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }
        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = _hrAccountService.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password) && hraccount.MemberRole == 1)
            {
                JobPostingWindow jobPosting = new JobPostingWindow();
                jobPosting.Show();
            }
            else
                MessageBox.Show("Email or Password is incorrect");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}