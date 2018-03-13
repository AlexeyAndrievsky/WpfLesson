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
using WpfLesson.DataAccess;

namespace WpfLesson
{
    public partial class MainWindow : Window
    {
        private IEmployersModel EmployersModel;

        public MainWindow()
        {
            InitializeComponent();
            EmployersModel = new EmployersModel(new DataServiceStub());
        }

        private void ShowEmployersButton_Click(object sender, RoutedEventArgs e)
        {
            EmployersView view = new EmployersView();
            view.DataContext
                = new EmployersViewModel(EmployersModel);
            view.Owner = this;
            view.Show();
        }

        private void ShowDepartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
