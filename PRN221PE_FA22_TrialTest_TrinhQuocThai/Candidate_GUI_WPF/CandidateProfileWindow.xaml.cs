using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Candidate_Service.Services;
using System.Windows;
using System.Windows.Controls;

namespace Candidate_GUI_WPF
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private int? roleId = 0;
        private ICandidateProfileService _candidateProfileService;
        private IJobPostingService _jobPostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobPostingService = new JobPostingService();
        }
        public CandidateProfileWindow(int? roleId)
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobPostingService = new JobPostingService();
            this.roleId = roleId;
            switch (roleId)
            {
                case 1:
                    break;
                case 2:
                    this.btnAdd.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to quit window?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void dtgCandidate_Loaded(object sender, RoutedEventArgs e)
        {
            dtgCandidateProfile.ItemsSource = _candidateProfileService.GetCandidateProfiles();
            cbJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbJobPosting.SelectedValuePath = "PostingId";
        }

        private void LoadData()
        {
            this.dtgCandidateProfile.ItemsSource = null;
            this.dtgCandidateProfile.ItemsSource = _candidateProfileService.GetCandidateProfiles().Select(x => new
            {
                x.CandidateId,
                x.Fullname,
                x.Birthday,
                x.ProfileShortDescription,
                x.ProfileUrl
            });
            cbJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbJobPosting.SelectedValuePath = "PostingId";
        }

        private void ResetForm()
        {
            txtCandidateID.Text = string.Empty;
            txtFullName.Text = string.Empty;
            cbJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbJobPosting.SelectedValuePath = "PostingId";
            txtDescription.Text = string.Empty;
            txtImgUrl.Text = string.Empty;
            dpBirthDay.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.PostingId = cbJobPosting.SelectedValue.ToString();
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.ProfileUrl = txtImgUrl.Text;
            candidateProfile.Birthday = DateTime.Parse(dpBirthDay.Text);

            if (_candidateProfileService.AddCandidateProfile(candidateProfile))
            {
                this.LoadData();
                this.ResetForm();
                MessageBox.Show("Add Successful!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something wrong!", "Add", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = _candidateProfileService.GetCandidateProfileById(txtCandidateID.Text);
            if (candidateProfile != null)
            {
                candidateProfile.Fullname = txtFullName.Text;
                candidateProfile.ProfileShortDescription = txtDescription.Text;
                candidateProfile.ProfileUrl = txtImgUrl.Text;
                candidateProfile.Birthday = DateTime.Parse(dpBirthDay.Text);
                candidateProfile.PostingId = cbJobPosting.SelectedValue.ToString();
                if (_candidateProfileService.UpdateCandidateProfile(candidateProfile))
                {
                    this.LoadData();
                    this.ResetForm();
                    MessageBox.Show("Update Successful!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something wrong!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Something wrong, please select a certain Candidate Profile to edit!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                CandidateProfile candidate = _candidateProfileService.GetCandidateProfileById(txtCandidateID.Text);
                if (candidate != null)
                {
                    if (_candidateProfileService.DeleteCandidateProfile(candidate))
                    {
                        this.LoadData();
                        this.ResetForm();
                        MessageBox.Show("Delete Successful!", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something wrong!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Something wrong, please select a certain Candidate Profile to delete!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
            if (row != null)
            {
                DataGridCell rowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)rowColumn.Content).Text;
                CandidateProfile candidateProfile = _candidateProfileService.GetCandidateProfileById(id);
                if (candidateProfile != null)
                {
                    txtCandidateID.Text = candidateProfile.CandidateId;
                    txtFullName.Text = candidateProfile.Fullname;
                    cbJobPosting.SelectedValue = candidateProfile.PostingId;
                    txtDescription.Text = candidateProfile.ProfileShortDescription;
                    txtImgUrl.Text = candidateProfile.ProfileUrl;
                    dpBirthDay.Text = candidateProfile.Birthday.ToString();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPosting = new JobPostingWindow();
            jobPosting.Show();
        }
    }
}
