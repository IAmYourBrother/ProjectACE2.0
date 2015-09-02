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

        private void btnViewCandidates_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void btnViewCandidates_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void btnManage_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void btnManage_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void btnElectoralResults_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void btnElectoralResults_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnMStudents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMTeachers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMAdmins_Click(object sender, RoutedEventArgs e)
        {

        }



    

       



    }
    
}
