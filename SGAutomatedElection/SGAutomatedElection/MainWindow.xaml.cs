using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using ProjectClasses;

namespace SGAutomatedElection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int flag = 0;
        private string usertype;
        private Student aStudent;
        private Teacher aTeacher;
        private Admin aAdmin;
        public MainWindow()
        {

            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDepartment();
            PopulateSection();
            PopulateYear();
            cmbxYrLevel.DisplayMemberPath = "Name";
            cmbxYrLevel.SelectedValuePath = "Value";
            cmbxDepartment.DisplayMemberPath = "Name";
            cmbxDepartment.SelectedValuePath = "Value";
            cmbxSection.DisplayMemberPath = "Name";
            cmbxSection.SelectedValuePath = "Value";
        }
        private void PopulateDepartment()
        {
            cmbxDepartment.Items.Clear();
            cmbxDepartment.Items.Add(new {Name = "Math", Value="Math"});
            cmbxDepartment.Items.Add(new { Name = "Science", Value = "Science" });
            cmbxDepartment.Items.Add(new { Name = "English", Value = "English" });
            cmbxDepartment.Items.Add(new { Name = "AP", Value = "AP" });
            cmbxDepartment.Items.Add(new { Name = "Filipino", Value = "Filipino" });
            cmbxDepartment.Items.Add(new { Name = "TVE", Value = "TVE" });
        }
        private void PopulateSection()
        {
            cmbxSection.Items.Add(new { Name = "A", Value = "A" });
            cmbxSection.Items.Add(new { Name = "B", Value = "B" });
            cmbxSection.Items.Add(new { Name = "C", Value = "C" });
            cmbxSection.Items.Add(new { Name = "D", Value = "D" });
            cmbxSection.Items.Add(new { Name = "E", Value = "E" });
        }
        private void PopulateYear()
        {
            for (int i = 1; i < 5; i++)
            {
                cmbxYrLevel.Items.Add(new { Name = i.ToString(), Value = i.ToString() });
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridAdmin")).Visibility = System.Windows.Visibility.Visible;
            ((Grid)FindName("gridLogin")).Visibility = System.Windows.Visibility.Collapsed;

        }
        private void btnALogout_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridAdmin")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridLogin")).Visibility = System.Windows.Visibility.Visible;
        }

       
        private void btnMStudents_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManageMain")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblMUser")).Content = "Manage Student Account";
            flag = 1;
        }

        private void btnMTeachers_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManageMain")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblMUser")).Content = "Manage Teacher Account";
            flag = 2;
        }

        private void btnMAdmins_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManageMain")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblMUser")).Content = "Manage Administrator Account";
            flag = 3;
        }

        private void btnAddPositions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPartyMembers_Click(object sender, RoutedEventArgs e)
        {

        }
        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)FindName("txtPass")).Clear();
            ((PasswordBox)FindName("txtPass")).Foreground = new SolidColorBrush(Colors.Black);
        }
        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)FindName("txtUsername")).Clear();
            ((TextBox)FindName("txtUsername")).FontStyle = FontStyles.Normal;
            ((TextBox)FindName("txtUsername")).Foreground = new SolidColorBrush(Colors.Black);
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            usertype = DetermineUser();
            ChangeAddLabel();
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("btnAddUser")).IsEnabled = false;
            ((Button)FindName("btnAddUser")).Content = "Add";
            ControlCollapse();
            EnableIfDisabled();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            usertype = DetermineUser();
            ChangeEditLabel();
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("btnAddUser")).Content = "Edit";
            ControlCollapse();
            DisableForEdit();             
        }
        private void DisableForEdit()
        {
            ((TextBox)FindName("txtName")).IsEnabled = false;
            ((PasswordBox)FindName("pbPassword")).IsEnabled = false;
            ((PasswordBox)FindName("pbConfirmPassword")).IsEnabled = false;
            ((ComboBox)FindName("cmbxYrLevel")).IsEnabled = false;
            ((ComboBox)FindName("cmbxSection")).IsEnabled = false;
            ((ComboBox)FindName("cmbxDepartment")).IsEnabled = false;
            ((Button)FindName("btnAddUser")).IsEnabled = false;
        }
        private void EnableIfDisabled()
        {
            ((TextBox)FindName("txtName")).IsEnabled = true;
            ((PasswordBox)FindName("pbPassword")).IsEnabled = true;
            ((PasswordBox)FindName("pbConfirmPassword")).IsEnabled = true;
            ((ComboBox)FindName("cmbxYrLevel")).IsEnabled = true;
            ((ComboBox)FindName("cmbxSection")).IsEnabled = true;
            ((ComboBox)FindName("cmbxDepartment")).IsEnabled = true;
            ((Button)FindName("btnAddUser")).IsEnabled = true;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            usertype = DetermineUser();
            ChangeDeleteLabel();
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridUserSearch")).Visibility = System.Windows.Visibility.Visible;
        }
        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridAdmin")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridManageMain")).Visibility = System.Windows.Visibility.Visible;
        }
        private string DetermineUser()
        {
            string userlabel = "";

            if (flag == 1)
            {
                userlabel = "Student";
            }
            else if (flag == 2)
            {
                userlabel = "Teacher";
            }
            else if(flag ==3)
            {
                userlabel = "Administrator";
            }
            return userlabel;
        }
        private void ChangeAddLabel()
        {
            ((Label)FindName("lblAddUser")).Content = "Add New " + usertype;
        }
        private void ChangeEditLabel()
        {
            ((Label)FindName("lblAddUser")).Content = "Edit Existing " + usertype;
        }
        private void ChangeDeleteLabel()
        {
            ((Label)FindName("lblDeleteUser")).Content = "Delete " + usertype + " Account";
        }
        private void ControlCollapse()
        {
            if (flag == 1)
            {
                ((ComboBox)FindName("cmbxDepartment")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblEN")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblDepartment")).Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (flag == 2)
            {
                ((ComboBox)FindName("cmbxYrLevel")).Visibility = System.Windows.Visibility.Collapsed;
                ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblYrLevel")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (flag == 3)
            {
                ((ComboBox)FindName("cmbxYrLevel")).Visibility = System.Windows.Visibility.Collapsed;
                ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((ComboBox)FindName("cmbxDepartment")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblDepartment")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblYrLevel")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Visible;
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((ComboBox)FindName("cmbxYrLevel")).Visibility = System.Windows.Visibility.Visible;
            ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Visible;
            ((ComboBox)FindName("cmbxDepartment")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblDepartment")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblYrLevel")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Visible;
        }
        //CRUD process
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
