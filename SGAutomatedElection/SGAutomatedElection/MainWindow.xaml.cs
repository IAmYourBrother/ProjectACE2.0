using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGAutomatedElection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int flag = 0;
        private string usertype;
        public MainWindow()
        {

            InitializeComponent();
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
            ((Label)FindName("lblEditUser")).Content = "Edit Existing " + usertype;
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
    }
    
}
