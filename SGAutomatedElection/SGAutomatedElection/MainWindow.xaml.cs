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
using System.Data.SqlClient;

namespace SGAutomatedElection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int flag = 0, flag2 = 0;
        private string usertype;
        private Student aStudent;
        private Teacher aTeacher;
        private Admin aAdmin;
        private Candidate aCandidate;
        private Party aParty;
        private List<StudentListViewItem> students = new List<StudentListViewItem>();
        private List<CandidateListViewItem> candidates = new List<CandidateListViewItem>();
        public MainWindow()
        {

            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDepartment();
            PopulateSection();
            PopulateSList();
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
            cmbxSection.Items.Add(new { Name = "1A", Value = "1A" });
            cmbxSection.Items.Add(new { Name = "1B", Value = "1B" });
            cmbxSection.Items.Add(new { Name = "1C", Value = "1C" });
            cmbxSection.Items.Add(new { Name = "1D", Value = "1D" });
            cmbxSection.Items.Add(new { Name = "1E", Value = "1E" });
            cmbxSection.Items.Add(new { Name = "2A", Value = "2A" });
            cmbxSection.Items.Add(new { Name = "2B", Value = "2B" });
            cmbxSection.Items.Add(new { Name = "2C", Value = "2C" });
            cmbxSection.Items.Add(new { Name = "2D", Value = "2D" });
            cmbxSection.Items.Add(new { Name = "2E", Value = "2E" });
            cmbxSection.Items.Add(new { Name = "3A", Value = "3A" });
            cmbxSection.Items.Add(new { Name = "3B", Value = "3B" });
            cmbxSection.Items.Add(new { Name = "3C", Value = "3C" });
            cmbxSection.Items.Add(new { Name = "3D", Value = "3D" });
            cmbxSection.Items.Add(new { Name = "3E", Value = "3E" });
            cmbxSection.Items.Add(new { Name = "4A", Value = "4A" });
            cmbxSection.Items.Add(new { Name = "4B", Value = "4B" });
            cmbxSection.Items.Add(new { Name = "4C", Value = "4C" });
            cmbxSection.Items.Add(new { Name = "4D", Value = "4D" });
            cmbxSection.Items.Add(new { Name = "4E", Value = "4E" });
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (txtPass.Password == GetPass(Convert.ToInt32(txtUsername.Text)))
                {
                    ((Grid)FindName("gridLogin")).Visibility = System.Windows.Visibility.Collapsed;
                    if (GetUType(Convert.ToInt32(txtUsername.Text))== "Admin")
                    {
                        ((Grid)FindName("gridAdmin")).Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (GetUType(Convert.ToInt32(txtUsername.Text))== "Teacher")
                    {
                        ((Grid)FindName("gridTeacher")).Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (GetUType(Convert.ToInt32(txtUsername.Text))== "Student")
                    {
                        ((Grid)FindName("gridStudent")).Visibility = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username/Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Do not leave empty fields!");
            }
            
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


        private void btnAddPartyMembers_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridRegisterParty")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridAddPartyMembers")).Visibility = System.Windows.Visibility.Visible;
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
            flag2 = 4;
            usertype = DetermineUser();
            ChangeAddLabel();
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Collapsed; //gridAddPartyMembers
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("btnAddUser")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("btnEditUser")).Visibility = System.Windows.Visibility.Collapsed;
            ControlCollapse();
            EnableIfDisabled();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            flag2 = 5;
            usertype = DetermineUser();
            ChangeEditLabel();
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Visible;
            ((Button)FindName("btnAddUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((Button)FindName("btnEditUser")).Visibility = System.Windows.Visibility.Visible;
            ControlCollapse();
            DisableForEdit();             
        }
        private void DisableForEdit()
        {
            ((TextBox)FindName("txtName")).IsEnabled = false;
            ((PasswordBox)FindName("pbPassword")).IsEnabled = false;
            ((PasswordBox)FindName("pbConfirmPassword")).IsEnabled = false;
            ((ComboBox)FindName("cmbxSection")).IsEnabled = false;
            ((ComboBox)FindName("cmbxDepartment")).IsEnabled = false;
            ((Button)FindName("btnAddUser")).IsEnabled = false;
        }
        private void EnableIfDisabled()
        {
            ((TextBox)FindName("txtName")).IsEnabled = true;
            ((PasswordBox)FindName("pbPassword")).IsEnabled = true;
            ((PasswordBox)FindName("pbConfirmPassword")).IsEnabled = true;
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
                ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (flag == 3)
            {
                ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Collapsed;
                ((ComboBox)FindName("cmbxDepartment")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblDepartment")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Collapsed;
                ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManagementUser")).Visibility = System.Windows.Visibility.Visible;
            ((Grid)FindName("gridAddUser")).Visibility = System.Windows.Visibility.Collapsed;
            ((ComboBox)FindName("cmbxSection")).Visibility = System.Windows.Visibility.Visible;
            ((ComboBox)FindName("cmbxDepartment")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblDepartment")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblSN")).Visibility = System.Windows.Visibility.Visible;
            ((Label)FindName("lblSection")).Visibility = System.Windows.Visibility.Visible;
            ClearFields();
        }
        //CRUD process
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                aStudent = new Student(Convert.ToInt32(txtNumber.Text), txtName.Text, cmbxSection.Text, pbPassword.Password, false);
                aStudent.Insert();
            }
            else if (flag == 2)
            {
                aTeacher = new Teacher(Convert.ToInt32(txtNumber.Text), txtName.Text, cmbxDepartment.Text, pbPassword.Password);
                aTeacher.Insert();
            }
            else if (flag == 3)
            {
                aAdmin = new Admin(Convert.ToInt32(txtNumber.Text), txtName.Text, pbPassword.Password);
                aAdmin.Insert();
            }
            ClearFields();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                aStudent = new Student(Convert.ToInt32(txtNumber.Text), txtName.Text,  cmbxSection.Text, pbPassword.Password, false);
                aStudent.Update();
            }
            else if (flag == 2)
            {
                aTeacher = new Teacher(Convert.ToInt32(txtNumber.Text), txtName.Text, cmbxDepartment.Text, pbPassword.Password);
                aTeacher.Update();
            }
            else if (flag == 3)
            {
                aAdmin = new Admin(Convert.ToInt32(txtNumber.Text), txtName.Text, pbPassword.Password);
                aAdmin.Update();
            }
        }

        private void txtNumber_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (flag2 == 4) // add window ito
            {
                DoNothing();
            }
            else if (flag2 == 5)//edit ito, do something 
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    ToggleControls(true);
                    if (flag == 1)
                    {
                        try
                        {
                            GetStudent(Convert.ToInt32(txtNumber.Text));
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }                       
                    }
                    else if (flag == 2)
                    {
                        try
                        {
                            GetTeacher(Convert.ToInt32(txtNumber.Text));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString()); 
                        }
                    }
                    else if (flag ==3)
                    {
                        try
                        {
                            GetAdmin(Convert.ToInt32(txtNumber.Text));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
        public void GetStudent(int number)
        {
            string comstr = "SELECT * from Student WHERE ID = '" + number.ToString() + "'";
            string comstr2 = "SELECT * from Accounts WHERE ID = '" + number.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    cmbxSection.Text = reader["YearSection"].ToString();
                }
                reader.Close();
                SqlCommand command2= new SqlCommand(comstr2, connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    pbPassword.Password = reader2["PW"].ToString();
                    pbConfirmPassword.Password = reader2["PW"].ToString();
                }
                reader2.Close();
            }
        }
        public void GetTeacher(int number)
        {
            string comstr = "SELECT * from Teacher WHERE ID = '" + number.ToString() + "'";
            string comstr2 = "SELECT * from Accounts WHERE ID = '" + number.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    cmbxSection.Text = reader["Department"].ToString();
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand(comstr2, connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    pbPassword.Password = reader2["PW"].ToString();
                    pbConfirmPassword.Password = reader2["PW"].ToString();
                }
                reader2.Close();
            }
        }
        public string GetUType(int number)
        {
            string Utype = "";

            string comstr = "SELECT * from Accounts WHERE ID ='" + number.ToString()+"'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Utype = reader["Utype"].ToString();
                }
            }
            return Utype;
        }
        public void GetAdmin(int number)
        {
            string comstr = "SELECT * from Admin WHERE ID = '" + number.ToString() + "'";
            string comstr2 = "SELECT * from Accounts WHERE ID = '" + number.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand(comstr2, connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    pbPassword.Password = reader2["PW"].ToString();
                    pbConfirmPassword.Password = reader2["PW"].ToString();
                }
                reader2.Close();
            }
        }
        public string GetPass(int number)
        {
            string pass ="";
            string comstr = "SELECT * from Accounts WHERE ID = '" + number.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     pass = reader["PW"].ToString();
                }
                reader.Close();
            }
            return pass;
        }
        private void ToggleControls(bool isEnabled)
        {
            cmbxDepartment.IsEnabled =
            cmbxSection.IsEnabled =
            txtName.IsEnabled =
            pbPassword.IsEnabled =
            pbConfirmPassword.IsEnabled = isEnabled;
        }
        private void DoNothing()
        {
            //amazingly does NOTHING!!!
        }

        private void txtDeleteNumber_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //write some code
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                string usertype = GetUType(Convert.ToInt32(txtDeleteNumber.Text));
                if (usertype == "Student")
                {
                    aStudent = new Student(Convert.ToInt32(txtDeleteNumber.Text));
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        aStudent.Delete();
                    }
                    else if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                    {
                        DoNothing();
                    }
                }
                else if (usertype == "Teacher")
                {
                    aTeacher = new Teacher(Convert.ToInt32(txtDeleteNumber.Text));
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        aTeacher.Delete();
                    }
                    else if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                    {
                        DoNothing();
                    }
                }
                else if (usertype == "Admin")
                {
                    aAdmin = new Admin(Convert.ToInt32(txtDeleteNumber.Text));
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        aAdmin.Delete();
                    }
                    else if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                    {
                        DoNothing();
                    }
                }
                //PopulateSList();
            }
        }
        private void txtDeleteNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)FindName("txtDeleteNumber")).Clear();
            ((TextBox)FindName("txtDeleteNumber")).FontStyle = FontStyles.Normal;
            ((TextBox)FindName("txtDeleteNumber")).Foreground = new SolidColorBrush(Colors.Black);
        }
        public int ID {//for data binding only ni Students pero okay na to. move on to Name
            get 
            { 
                return Convert.ToInt32(txtDeleteNumber.Text); 
            } 
            set
            {  
                txtDeleteNumber.Text = value.ToString();
            }
        }
        public void PopulateSList()
        {
            students.Clear();
            string comStr =
                "SELECT " +
                    "Student.ID AS ID, " +
                    "Student.Name AS Name, " +
                    "Student.YearSection AS YearSection " +
                "FROM Student";

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comStr, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new StudentListViewItem()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        YearSection = reader["YearSection"].ToString()
                    });
                }
                reader.Close();
                lstVoters.ItemsSource = students;
            }
        }
        public void PopulateCList()
        {
            candidates.Clear();
            string comStr =
                "SELECT " +
                    "Candidates.ID AS ID, " +
                    "Candidates.Name AS Name, " +
                    "Candidates.Party AS Party " +
                    "Candidates.Position AS Party"+
                "FROM Candidates";

            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comStr, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    candidates.Add(new CandidateListViewItem()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Party = reader["Party"].ToString(),
                        Position = reader["Position"].ToString()//pdeng di ko muna iretrieve ung votes
                    });
                }
                  lstCandidates.ItemsSource = students;
            }
        }
        public void ClearFields()
        {
            ((TextBox)FindName("txtName")).Clear();
            ((TextBox)FindName("txtNumber")).Clear();
            ((TextBox)FindName("txtName")).Clear();
            ((PasswordBox)FindName("pbPassword")).Clear();
            ((PasswordBox)FindName("pbConfirmPassword")).Clear();
            ((ComboBox)FindName("cmbxSection")).SelectedIndex = -1;
            ((ComboBox)FindName("cmbxDepartment")).SelectedIndex = -1;
        }

        private void btnAddCandidate_Click(object sender, RoutedEventArgs e)
        {
            students.Clear();//if i dont put this, it shits so bad
            //aStudent = new Student(Convert.ToInt32(txtAddCandidate.Text)); no need
            string comStr =
                "SELECT " +
                    "Student.ID AS ID, " +
                    "Student.Name AS Name, " +
                    "Student.YearSection AS YearSection " +
                "FROM Student WHERE ID = '"+txtAddCandidate.Text+"'";//try lang
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comStr, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new StudentListViewItem()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        YearSection = reader["YearSection"].ToString()
                    });
                }
                reader.Close();
                lstAddPartyMembers.ItemsSource = students;
            }
        }

        private void btnViewCandidates_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridAdmin")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridViewer")).Visibility = System.Windows.Visibility.Visible;
        }

        private void btnListStudents_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridViewer")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridVoters")).Visibility = System.Windows.Visibility.Visible;
            PopulateSList();
        }

        private void btnParties_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridViewer")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridParties")).Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCandidates_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridViewer")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridCandidates")).Visibility = System.Windows.Visibility.Visible;
            PopulateCList();
        }

        private void btnCancelCandidate_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridAddPartyMembers")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridCandidates")).Visibility = System.Windows.Visibility.Visible;
        }

        private void btnMParties_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManageMain")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridManagementParty")).Visibility = System.Windows.Visibility.Visible;
            //no need to change label
        }

        private void btnAddParty_Click(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("gridManagementParty")).Visibility = System.Windows.Visibility.Collapsed;
            ((Grid)FindName("gridRegisterParty")).Visibility = System.Windows.Visibility.Visible;
        }

        private void btnEditParty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteParty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirmParty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelParty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeletePartyMembers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditPartyMembers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
//gridAddPartyMembers